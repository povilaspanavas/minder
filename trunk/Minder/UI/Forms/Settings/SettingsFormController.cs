﻿using System;
using System.Diagnostics;
using System.IO;
using Core.Forms;
using Minder.Engine.Parse;
using Minder.Engine.Settings;
using Minder.Engine.Sync;
using Minder.Tools;
using Minder.UI.Forms.TaskShow;
using Minder.UI.Forms;
using Minder.UI.Forms.Settings;
using System.Windows;
using Minder.Forms.TaskShow;
using System.Collections.Generic;
using Minder.Static;
using WPF.Themes;
using System.Windows.Controls;
using System.ComponentModel;

namespace Minder.Forms.Settings
{
    /// <summary>
    /// Description of SettingsFromPreparer.
    /// </summary>
    public class SettingsFormController : IController
    {
        SettingsWpfForm _form = null;
        private bool _existChanges = false;
        log4net.ILog _log = log4net.LogManager.GetLogger(typeof(SettingsFormController));

        public SettingsFormController()
        {
            _form = new SettingsWpfForm {Title = "Settings", DataContext = this};
        }

        public Window Window
        {
            get
            {
                return _form;
            }
        }

        public void PrepareWindow()
        {
            AddDataToControlls();
            SetEvents();
            _form.DataContext = this;
            _form.Show();

        }

        public void SetEvents()
        {
            StaticData.Settings.PropertyChanged += (sender, args) => _existChanges = true;

            _form.Closing += FormClosing;

            _form.MSkinListBox.SelectionChanged += delegate
            {
                _form.MSkinPreviewPictureBox.Source = new Images()
                    .GetBitmapImage(Minder.Static.StaticData.Settings.SkinsUniqueCodes.SelectedSkin.ToUpper());
            };

            _form.MDefaultsButton.Click += delegate
            {
                if (MessageBox.Show("Do you realy want restore default settings?",
                                   "Settings", MessageBoxButton.YesNo,
                                   MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    new SettingsLoader().CreateDefaultSettingsFile();
                    new SettingsLoader().LoadSettings();
                    _existChanges = true;
                }
            };

            _form.MEnableSyncCheckBox.Click += delegate
            {
                var isChecked = _form.MEnableSyncCheckBox.IsChecked != null && _form.MEnableSyncCheckBox.IsChecked.Value;
                _form.MSyncGenerateIdButton.IsEnabled = isChecked;
                _form.MSyncIdTextBox.IsEnabled = isChecked;
                _form.MSyncIntervalNumeric.IsEnabled = isChecked;
            };

            _form.MSyncGenerateIdButton.Click += delegate { GenerateSyncId(); };

            _form.MSyncNowButton.Click += delegate
            {
                using (new WaitingForm2("Syncing...", "Please wait", false))
                {
                    new SyncController().Sync();
                }
            };

            if (Static.StaticData.Settings.Sync.Enable == false)
            {
                _form.MSyncGenerateIdButton.IsEnabled = false;
                _form.MSyncIdTextBox.IsEnabled = false;
                _form.MSyncIntervalNumeric.IsEnabled = false;
            }

            _form.MSyncIdTextBox.ManipulationCompleted += delegate { _form.MSyncIdTextBox.Text = _form.MSyncIdTextBox.Text.ToUpper(); };

            _form.MThemeComboBox.SelectionChanged += MThemeComboBox_SelectionChanged;
        }

        void MThemeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (sender == null || sender is ComboBox == false)
                return;
            var themeName = (string)(sender as ComboBox).SelectedItem;
            Application.Current.ApplyTheme(themeName);
        }

        private void AddDataToControlls()
        {
            _form.MSkinPreviewPictureBox.Source = new Images().GetBitmapImage(
                StaticData.Settings.SkinsUniqueCodes.SelectedSkin.ToUpper());
        }

        private void GenerateSyncId()
        {
            string rStr = Path.GetRandomFileName();
            rStr = rStr.Replace(".", ""); // For Removing the .
            rStr = rStr.ToUpper();
            if (string.IsNullOrEmpty(_form.MSyncIdTextBox.Text))
                _form.MSyncIdTextBox.Text = rStr;
            else
            {
                if (MessageBox.Show("Do you really want generate new ID and lose your current ID?", "Warrning",
                                   MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    _form.MSyncIdTextBox.Text = rStr;
            }

        }

        private void FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Check or exist changes
            if (_existChanges != true) return;
            if (MessageBox.Show("Do you want to save changes?", "Settings",
                MessageBoxButton.YesNo) != MessageBoxResult.Yes) return;
            // not sure if it will work. There are two properties for RemindLaterValue
            //if (_form.MComboBoxRemindMeLater.SelectedItem != null &&
            //    _form.MComboBoxRemindMeLater.SelectedItem is RemindLaterValue)
            //    Minder.Static.StaticData.Settings.RemindMeLaterDecimalValue = (_form.MComboBoxRemindMeLater.SelectedItem as RemindLaterValue).Value;
            new SettingsLoader().SaveSettingsToFile();
            if (MessageBox.Show("You need restart application to take efect. Do you want restart application now?", "Settings",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                string workingPath = new PathCutHelper()
                    .CutExecutableFileFromPath(System.Reflection.Assembly
                        .GetExecutingAssembly().Location);
                string starterPath = workingPath + @"\Minder.Starter.exe";
                string minderPath = workingPath + @"\Minder.exe";

                minderPath = minderPath.Insert(0, "\"");
                minderPath = minderPath.Insert(minderPath.Length, "\"");

                Process.Start(starterPath, string.Format("--openform --run {0} --sleep 2", minderPath));

                Process[] proc = Process.GetProcessesByName("Minder");
                if (proc.Length > 0)
                {
                    foreach (Process proces in proc)
                    {
                        proces.Kill();
                    }
                }
            }
        }
    }
}