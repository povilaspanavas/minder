using System;
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
    public class SettingsFormController : IController, INotifyPropertyChanged
    {
        SettingsWpfForm _form = null;
        private bool _existChanges = false;
        private string _selectedTheme;
        log4net.ILog _log = log4net.LogManager.GetLogger(typeof(SettingsFormController));

        public string SelectedTheme
        {
            get { return _selectedTheme; }
            set { _selectedTheme = value; }
        }

        public SettingsFormController()
        {
            _form = new SettingsWpfForm();
            _form.Title = "Settings";
            _form.DataContext = StaticData.Settings;
        }

        public Window Window
        {
            get
            {
                return _form;
            }
        }

        public string[] Themes
        {
            get
            {
                return ThemeManager.GetThemes;
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
            _form.MAltCheckBox.Click += delegate { _existChanges = true; };
            _form.MCtrlCheckBox.Click += delegate { _existChanges = true; };
            _form.MShiftCheckBox.Click += delegate { _existChanges = true; };
            _form.MWinCheckBox.Click += delegate { _existChanges = true; };
            _form.MKeysComboBox.SelectionChanged += delegate { _existChanges = true; };

            _form.MSkinListBox.SelectionChanged += delegate { _existChanges = true; };

            _form.MSyncGenerateIdButton.Click += delegate { _existChanges = true; };
            _form.MSyncIdTextBox.TextChanged += delegate { _existChanges = true; };
            _form.MSyncIntervalNumeric.ValueChanged += delegate { _existChanges = true; };
            _form.MEnableSyncCheckBox.Click += delegate { _existChanges = true; };

            _form.Closing += FormClosing;

            _form.MSkinListBox.SelectionChanged += delegate
            {
                string skinUniqueCode = Minder.Static.StaticData.Settings
                    .SkinsUniqueCodes.SkinsUniqueCodesAndNames[_form.MSkinListBox.Items[_form.MSkinListBox.SelectedIndex]
                                                               .ToString()];
                _form.MSkinPreviewPictureBox.Source = new Images()
                    .GetBitmapImage(skinUniqueCode.ToUpper());
            };

            _form.MDefaultsButton.Click += delegate
            {
                if (MessageBox.Show("Do you realy want restore default settings?",
                                   "Settings", MessageBoxButton.YesNo,
                                   MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    new SettingsLoader().CreateDefaultSettingsFile();
                    new SettingsLoader().LoadSettings();
                    AddDataToControlls();
                    _existChanges = true;
                }
            };

            _form.MEnableSyncCheckBox.Click += delegate
            {
                _form.MSyncGenerateIdButton.IsEnabled = (bool)_form.MEnableSyncCheckBox.IsChecked;
                _form.MSyncIdTextBox.IsEnabled = (bool)_form.MEnableSyncCheckBox.IsChecked;
                _form.MSyncIntervalNumeric.IsEnabled = (bool)_form.MEnableSyncCheckBox.IsChecked;
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
            string themeName = (string)(sender as ComboBox).SelectedItem;
            ThemeManager.ApplyTheme(App.Current, themeName);
            _existChanges = true;
        }

        private void AddDataToControlls()
        {
            foreach (string key in Minder.Static.StaticData.KeysDic.Keys)
            {
                _form.MKeysComboBox.Items.Add(key);
            }

            _form.MAltCheckBox.IsChecked = Minder.Static.StaticData.Settings.NewTaskHotkey.Alt;
            _form.MCtrlCheckBox.IsChecked = Minder.Static.StaticData.Settings.NewTaskHotkey.Ctrl;
            _form.MShiftCheckBox.IsChecked = Minder.Static.StaticData.Settings.NewTaskHotkey.Shift;
            _form.MWinCheckBox.IsChecked = Minder.Static.StaticData.Settings.NewTaskHotkey.Win;

            for (int i = 0; i < _form.MKeysComboBox.Items.Count; i++)
            {
                if (Minder.Static.StaticData.Settings.NewTaskHotkey.Key
                   .Equals(_form.MKeysComboBox.Items[i].ToString()))
                    _form.MKeysComboBox.SelectedIndex = i;
            }

            // **** Skins ****
            int skinNameIndex = 0;
            foreach(string name in Minder.Static.StaticData.Settings.SkinsUniqueCodes.SkinsUniqueCodesAndNames.Keys)
            {
                _form.MSkinListBox.Items.Add(name);
                string uniqueCode = Minder.Static.StaticData.Settings.SkinsUniqueCodes.SkinsUniqueCodesAndNames[name];
                if (Minder.Static.StaticData.Settings.SkinUniqueCode.ToUpper().Equals(uniqueCode.ToUpper()))
                {
                    _form.MSkinListBox.SelectedIndex = skinNameIndex;
                    _form.MSkinPreviewPictureBox.Source = new Images().GetBitmapImage(uniqueCode.ToUpper());
                }
                skinNameIndex++;
            }

            //***** Theme ******
            SelectedTheme = Minder.Static.StaticData.Settings.ThemeUniqueCode;
            for (int i = 0; i < _form.MThemeComboBox.Items.Count; i++)
            {
                if (StaticData.Settings.ThemeUniqueCode.Equals((_form.MThemeComboBox.Items[i] as string).ToUpper()))
                {
                    _form.MThemeComboBox.SelectedIndex = i;
                    break;
                }
            }
            //ThemeManager.ThemeProperty.DefaultMetadata.DefaultValue = "BubbleCreme";

            //***** Sync ******
            _form.MEnableSyncCheckBox.IsChecked = Minder.Static.StaticData.Settings.Sync.Enable;
            if (Minder.Static.StaticData.Settings.Sync.Interval <= 0)
                _form.MSyncIntervalNumeric.Value = 30;
            else
                _form.MSyncIntervalNumeric.Value = Minder.Static.StaticData.Settings.Sync.Interval;
            _form.MSyncIdTextBox.Text = Minder.Static.StaticData.Settings.Sync.Id;
            _form.MLastSyncDate.Value = Minder.Static.StaticData.Settings.Sync.LastSyncDate;

        }

        private void SetSkinSettings()
        {
            string skinName = _form.MSkinListBox.Items[_form.MSkinListBox.SelectedIndex].ToString();
            Minder.Static.StaticData.Settings.SkinUniqueCode = Minder.Static.StaticData.Settings.SkinsUniqueCodes.SkinsUniqueCodesAndNames[skinName];
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
            if (_existChanges == true)
            {
                if (MessageBox.Show("Do you want to save changes?", "Settings",
                                   MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Minder.Static.StaticData.Settings.NewTaskHotkey.Alt = (bool)_form.MAltCheckBox.IsChecked;
                    Minder.Static.StaticData.Settings.NewTaskHotkey.Ctrl = (bool)_form.MCtrlCheckBox.IsChecked;
                    Minder.Static.StaticData.Settings.NewTaskHotkey.Shift = (bool)_form.MShiftCheckBox.IsChecked;
                    Minder.Static.StaticData.Settings.NewTaskHotkey.Win = (bool)_form.MWinCheckBox.IsChecked;
                    Minder.Static.StaticData.Settings.NewTaskHotkey.Key = _form.MKeysComboBox.SelectedItem.ToString();
                    Minder.Static.StaticData.Settings.StartWithWindows = (bool)_form.MStartWithWinCheckBox.IsChecked;
                    Minder.Static.StaticData.Settings.CheckUpdates = (bool)_form.MUpdateCheckBox.IsChecked;
                    Minder.Static.StaticData.Settings.PlaySound = (bool)_form.MPlaySoundCheckBox.IsChecked;
                    if (_form.MComboBoxCultureData.SelectedItem != null &&
                        _form.MComboBoxCultureData.SelectedItem is ICultureData)
                        Minder.Static.StaticData.Settings.CultureData = _form.MComboBoxCultureData.SelectedItem as ICultureData;
                    if (_form.MComboBoxRemindMeLater.SelectedItem != null &&
                        _form.MComboBoxRemindMeLater.SelectedItem is RemindLaterValue)
                        Minder.Static.StaticData.Settings.RemindMeLaterDecimalValue = (_form.MComboBoxRemindMeLater.SelectedItem as RemindLaterValue).Value;
                    SetSkinSettings();

                    Minder.Static.StaticData.Settings.Sync.Id = _form.MSyncIdTextBox.Text.ToUpper();
                    Minder.Static.StaticData.Settings.Sync.Interval = Convert.ToInt32(_form.MSyncIntervalNumeric.Value);
                    Minder.Static.StaticData.Settings.Sync.Enable = (bool)_form.MEnableSyncCheckBox.IsChecked;
                    Minder.Static.StaticData.Settings.ThemeUniqueCode = (string)_form.MThemeComboBox.SelectedItem;

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


        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add {  }
            remove { }
        }
    }
}
