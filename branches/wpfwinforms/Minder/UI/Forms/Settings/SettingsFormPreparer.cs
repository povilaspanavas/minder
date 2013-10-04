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
            _form = new SettingsWpfForm();
			_form.Title = "Settings";
		}
		
		public Window Window {
			get {
				return _form;
			}
		}
		
		public void PrepareWindow()
		{
			AddDataToControlls();
			SetEvents();
			_form.Show();
		}
		
		public void SetEvents()
		{
            _form.MAltCheckBox.Checked += delegate { _existChanges = true; };
            _form.MCtrlCheckBox.Checked += delegate { _existChanges = true; };
            _form.MShiftCheckBox.Checked += delegate { _existChanges = true; };
            _form.MWinCheckBox.Checked += delegate { _existChanges = true; };
            _form.MKeysComboBox.SelectionChanged += delegate { _existChanges = true; };
            _form.MStartWithWinCheckBox.Checked += delegate { _existChanges = true; };
            _form.MUpdateCheckBox.Checked += delegate { _existChanges = true; };
            _form.MPlaySoundCheckBox.Checked += delegate { _existChanges = true; };
            _form.MComboBoxCultureData.SelectionChanged += delegate { _existChanges = true; };
            _form.MComboBoxRemindMeLater.SelectionChanged += delegate { _existChanges = true; };
            _form.MSkinListBox.SelectionChanged += delegate { _existChanges = true; };

            _form.MSyncGenerateIdButton.Click += delegate { _existChanges = true; };
            _form.MSyncIdTextBox.TextChanged += delegate { _existChanges = true; };
            _form.MSyncIntervalNumeric.ValueChanged += delegate { _existChanges = true; };
            _form.MEnableSyncCheckBox.Checked += delegate { _existChanges = true; };
			
			_form.Closing += FormClosing;

            _form.MSkinListBox.SelectionChanged += delegate
            {
                string skinUniqueCode = Minder.Static.StaticData.Settings
                    .SkinsUniqueCodes.SkinsUniqueCodesAndNames[_form.MSkinListBox.Items[_form.MSkinListBox.SelectedIndex]
                                                               .ToString()];
                //_form.MSkinPreviewPictureBox = new Images()
                //    .GetImage(skinUniqueCode.ToUpper());
            };
			
            //_form.MDefaultsButton.Click += delegate
            //{
            //    if(MessageBox.Show("Do you realy want restore default settings?",
            //                       "Settings", MessageBoxButtons.YesNo,
            //                       MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        new SettingsLoader().CreateDefaultSettingsFile();
            //        new SettingsLoader().LoadSettings();
            //        AddDataToControlls();
            //        _existChanges = true;
            //    }
            //};
			
            //_form.MEnableSyncCheckBox.CheckedChanged += delegate
            //{
            //    _form.MSyncGenerateIdButton.Enabled = _form.MEnableSyncCheckBox.Checked;
            //    _form.MSyncIdTextBox.Enabled = _form.MEnableSyncCheckBox.Checked;
            //    _form.MSyncIntervalNumeric.Enabled = _form.MEnableSyncCheckBox.Checked;
            //};
			
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
			
            //_form.MSyncIdTextBox.Leave += delegate { _form.MSyncIdTextBox.Text = _form.MSyncIdTextBox.Text.ToUpper(); };
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
			
            //for(int i=0; i<_form.MKeysComboBox.Items.Count; i++)
            //{
            //    if(Minder.Static.StaticData.Settings.NewTaskHotkey.Key
            //       .Equals(_form.MKeysComboBox.Items[i].ToString()))
            //        _form.MKeysComboBox.SelectedIndex = i;
            //}

            _form.MStartWithWinCheckBox.IsChecked = Minder.Static.StaticData.Settings.StartWithWindows;
            _form.MUpdateCheckBox.IsChecked = Minder.Static.StaticData.Settings.CheckUpdates;
            _form.MPlaySoundCheckBox.IsChecked = Minder.Static.StaticData.Settings.PlaySound;
			
			// **** DateFormat tab ****
			_form.MComboBoxCultureData.Items.Add(new CultureDataLT());
			_form.MComboBoxCultureData.Items.Add(new CultureDataUK());
			_form.MComboBoxCultureData.Items.Add(new CultureDataUS());
			
			for(int i = 0; i < _form.MComboBoxCultureData.Items.Count; i++)
			{
				if(Minder.Static.StaticData.Settings.CultureData.Name
				   .Equals((_form.MComboBoxCultureData.Items[i] as ICultureData).Name))
				{
					_form.MComboBoxCultureData.SelectedIndex = i;
					break;
				}
			}
			
			// **** Default Remind Me Later value ****
            //m_form.MComboBoxRemindMeLater.Sorted = false;
            //TaskShowController.AddRemindLaterValuesToComboBox(
            //    m_form.MComboBoxRemindMeLater,
            //    TaskShowController.BuildRemindLaterList());
			
            //TaskShowController.SelectRemindMeLater(m_form.MComboBoxRemindMeLater);
			
			// **** Skins ****
            //int skinNameIndex = 0;
            //foreach(string name in Minder.Static.StaticData.Settings.SkinsUniqueCodes.SkinsUniqueCodesAndNames.Keys)
            //{
            //    _form.MSkinListBox.Items.Add(name);
            //    string uniqueCode = Minder.Static.StaticData.Settings.SkinsUniqueCodes.SkinsUniqueCodesAndNames[name];
            //    if(Minder.Static.StaticData.Settings.SkinUniqueCode.ToUpper().Equals(uniqueCode.ToUpper()))
            //    {
            //        _form.MSkinListBox.SelectedIndex = skinNameIndex;
            //        _form.MSkinPreviewPictureBox.Image = new Images().GetImage(uniqueCode.ToUpper());
            //    }
            //    skinNameIndex++;
            //}
			
			// ***** Sync ******
            //_form.MEnableSyncCheckBox.Checked = Minder.Static.StaticData.Settings.Sync.Enable;
            //if(Minder.Static.StaticData.Settings.Sync.Interval <= 0)
            //    _form.MSyncIntervalNumeric.Value = 30;
            //else
            //    _form.MSyncIntervalNumeric.Value = Minder.Static.StaticData.Settings.Sync.Interval;
            //_form.MSyncIdTextBox.Text = Minder.Static.StaticData.Settings.Sync.Id;
            //_form.MLastSyncDate.Value = Minder.Static.StaticData.Settings.Sync.LastSyncDate;
			
		}
		
		private void SetSkinSettings()
		{
            //string skinName = _form.MSkinListBox.Items[_form.MSkinListBox.SelectedIndex].ToString();
            //Minder.Static.StaticData.Settings.SkinUniqueCode = Minder.Static.StaticData.Settings.SkinsUniqueCodes.SkinsUniqueCodesAndNames[skinName];
		}
		
		private void GenerateSyncId()
		{
			string rStr = Path.GetRandomFileName();
			rStr = rStr.Replace(".", ""); // For Removing the .
			rStr = rStr.ToUpper();
            //if(string.IsNullOrEmpty(_form.MSyncIdTextBox.Text))
            //    _form.MSyncIdTextBox.Text = rStr;
            //else
            //{
            //    if(MessageBox.Show("Do you really want generate new ID and lose your current ID?", "Warrning",
            //                       MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            //        _form.MSyncIdTextBox.Text = rStr;
            //}
			
		}
		
		private void FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//Check or exist changes
			//if(_existChanges == true)
//            {
//                if(MessageBox.Show("Do you want to save changes?", "Settings",
//                                   MessageBoxButtons.YesNo) ==  DialogResult.Yes)
//                {
//                    Minder.Static.StaticData.Settings.NewTaskHotkey.Alt = _form.MAltCheckBox.Checked;
//                    Minder.Static.StaticData.Settings.NewTaskHotkey.Ctrl = _form.MCtrlCheckBox.Checked;
//                    Minder.Static.StaticData.Settings.NewTaskHotkey.Shift = _form.MShiftCheckBox.Checked;
//                    Minder.Static.StaticData.Settings.NewTaskHotkey.Win = _form.MWinCheckBox.Checked;
//                    Minder.Static.StaticData.Settings.NewTaskHotkey.Key = _form.MKeysComboBox.SelectedItem.ToString();
//                    Minder.Static.StaticData.Settings.StartWithWindows = _form.MStartWithWinCheckBox.Checked;
//                    Minder.Static.StaticData.Settings.CheckUpdates = _form.MUpdateCheckBox.Checked;
//                    Minder.Static.StaticData.Settings.PlaySound = _form.MPlaySoundCheckBox.Checked;
//                    if (_form.MComboBoxCultureData.SelectedItem != null &&
//                        _form.MComboBoxCultureData.SelectedItem is ICultureData)
//                        Minder.Static.StaticData.Settings.CultureData = _form.MComboBoxCultureData.SelectedItem as ICultureData;
//                    if (_form.MComboBoxRemindMeLater.SelectedItem != null &&
//                        _form.MComboBoxRemindMeLater.SelectedItem is RemindLaterValue)
//                        Minder.Static.StaticData.Settings.RemindMeLaterDefaultValue = (_form.MComboBoxRemindMeLater.SelectedItem as RemindLaterValue).Value;
//                    SetSkinSettings();
					
//                    Minder.Static.StaticData.Settings.Sync.Id = _form.MSyncIdTextBox.Text.ToUpper();
//                    Minder.Static.StaticData.Settings.Sync.Interval = Convert.ToInt32(_form.MSyncIntervalNumeric.Value);
//                    Minder.Static.StaticData.Settings.Sync.Enable = _form.MEnableSyncCheckBox.Checked;
					
//                    new SettingsLoader().SaveSettingsToFile();
//                    if(MessageBox.Show("You need restart application to take efect. Do you want restart application now?", "Settings",
//                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
//                    {
//                        string workingPath = new PathCutHelper()
//                            .CutExecutableFileFromPath(System.Reflection.Assembly
//                                                       .GetExecutingAssembly().Location);
//                        string starterPath = workingPath + @"\Minder.Starter.exe";
//                        string minderPath = workingPath + @"\Minder.exe";
						
//                        minderPath = minderPath.Insert(0, "\"");
//                        minderPath = minderPath.Insert(minderPath.Length, "\"");
						
//                        Process.Start(starterPath, string.Format("--openform --run {0} --sleep 2", minderPath));
						
//                        Process[] proc = Process.GetProcessesByName("Minder");
//                        if(proc.Length > 0)
//                        {
//                            foreach(Process proces in proc)
//                            {
//                                proces.Kill();
//                            }
//                        }
//                    }
////					new WarningBox("You need restart application to take efect");
				
		}
		
	}
}
