using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Input;
using Core.Forms;
using Minder.Annotations;
using Minder.Engine.Parse;
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
using Minder.Engine.Settings;
using Minder.Forms.Settings;

namespace Minder.Forms
{
    /// <summary>
    /// Description of SettingsFromPreparer.
    /// </summary>
    public class SettingsFormController : IController
    {
        readonly SettingsWpfForm _form = null;
        readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(SettingsFormController));
        private bool _existChanges = false;

        public SettingsFormController()
        {
            _form = new SettingsWpfForm { Title = "Settings", DataContext = this };
        }

        public Window Window
        {
            get
            {
                return _form;
            }
        }

        public Engine.Settings.Settings Settings
        {
            get { return Minder.Static.StaticData.Settings; }
        }

        public void PrepareWindow()
        {
            AddDataToControlls();
            SetEvents();
            _form.DataContext = this;
            _form.Show();
        }

        

        #region Commands
        public ICommand DefaultsCommand
        {
            get { return new DelegateCommand(RestoreDefaultSettings); }
        }

        public ICommand GenerateIdCommand
        {
            get { return new DelegateCommand(GenerateSyncId); }
        }

        private void RestoreDefaultSettings()
        {
            if (MessageBox.Show("Do you realy want restore default settings?",
                               "Settings", MessageBoxButton.YesNo,
                               MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                new SettingsLoader().CreateDefaultSettingsFile();
                new SettingsLoader().LoadSettings();
                _existChanges = true;
            }
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

        public ICommand SyncNowCommand
        {
            get
            {
                return new DelegateCommand(SyncNow);
            }
        }

        private void SyncNow()
        {
            using (new WaitingForm2("Syncing...", "Please wait", false))
            {
                new SyncController().Sync();
            }
        }
        #endregion

        public void SetEvents()
        {
            StaticData.Settings.PropertyChanged += (sender, args) => _existChanges = true;

            _form.Closing += FormClosing;

            _form.MSkinListBox.SelectionChanged += delegate
            {
                _form.MSkinPreviewPictureBox.Source = new Images()
                    .GetBitmapImage(Minder.Static.StaticData.Settings.SkinsUniqueCodes.SelectedSkin.ToUpper());
            };

            _form.MEnableSyncCheckBox.Click += delegate
            {
                var isChecked = _form.MEnableSyncCheckBox.IsChecked != null && _form.MEnableSyncCheckBox.IsChecked.Value;
                _form.MSyncGenerateIdButton.IsEnabled = isChecked;
                _form.MSyncIdTextBox.IsEnabled = isChecked;
                _form.MSyncIntervalNumeric.IsEnabled = isChecked;
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

        private void FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Check or exist changes
            if (_existChanges != true) return;
            if (MessageBox.Show("Do you want to save changes?", "Settings",
                MessageBoxButton.YesNo) != MessageBoxResult.Yes) return;

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
