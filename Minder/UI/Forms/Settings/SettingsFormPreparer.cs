/*
 * Created by SharpDevelop.
 * User: IGNAS
 * Date: 2012.06.13
 * Time: 23:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Core;
using Core.Forms;
using Minder.Engine.Parse;
using Minder.Engine.Settings;
using Minder.Engine.Sync;
using Minder.Forms.Settings;
using Minder.Forms.TaskShow;
using Minder.Static;
using Minder.Tools;
using Minder.UI.Forms.TaskShow;

namespace Minder.Forms.Settings
{
	/// <summary>
	/// Description of SettingsFromPreparer.
	/// </summary>
	public class SettingsFormPreparer : IFormPreparer
	{
		SettingsForm m_form = null;
		private bool m_existChanges = false;
		log4net.ILog m_log = log4net.LogManager.GetLogger(typeof(SettingsFormPreparer));
		
		public SettingsFormPreparer()
		{
			m_form = new SettingsForm();
			m_form.Text = "Settings";
		}
		
		public System.Windows.Forms.Form Form {
			get {
				return m_form;
			}
		}
		
		public void PrepareForm()
		{
			AddDataToControlls();
			SetEvents();
			m_form.Show();
		}
		
		public void SetEvents()
		{
			m_form.MAltCheckBox.CheckedChanged += delegate {m_existChanges = true;};
			m_form.MCtrlCheckBox.CheckedChanged += delegate {m_existChanges = true;};
			m_form.MShiftCheckBox.CheckedChanged += delegate {m_existChanges = true;};
			m_form.MWinCheckBox.CheckedChanged += delegate {m_existChanges = true;};
			m_form.MKeysComboBox.SelectedIndexChanged += delegate {m_existChanges = true;};
			m_form.MStartWithWinCheckBox.CheckedChanged += delegate { m_existChanges = true; };
			m_form.MUpdateCheckBox.CheckedChanged += delegate { m_existChanges = true; };
			m_form.MPlaySoundCheckBox.CheckedChanged += delegate { m_existChanges = true; };
			m_form.MComboBoxCultureData.SelectedValueChanged += delegate { m_existChanges = true; };
			m_form.MComboBoxRemindMeLater.SelectedValueChanged += delegate { m_existChanges = true; };
			m_form.MSkinListBox.SelectedIndexChanged += delegate { m_existChanges = true; };
			
			m_form.MSyncGenerateIdButton.Click += delegate { m_existChanges = true; };
			m_form.MSyncIdTextBox.TextChanged += delegate { m_existChanges = true; };
			m_form.MSyncIntervalNumeric.ValueChanged += delegate { m_existChanges = true; };
			m_form.MEnableSyncCheckBox.CheckedChanged += delegate { m_existChanges = true; };
			
			m_form.Closing += FormClosing;
			
			m_form.MSkinListBox.SelectedIndexChanged += delegate
			{
				string skinUniqueCode = Minder.Static.StaticData.Settings
					.SkinsUniqueCodes.SkinsUniqueCodesAndNames[m_form.MSkinListBox.Items[m_form.MSkinListBox.SelectedIndex]
					                                           .ToString()];
				m_form.MSkinPreviewPictureBox.Image = new Images()
					.GetImage(skinUniqueCode.ToUpper());
			};
			
			m_form.MDefaultsButton.Click += delegate
			{
				if(MessageBox.Show("Do you realy want restore default settings?",
				                   "Settings", MessageBoxButtons.YesNo,
				                   MessageBoxIcon.Question) == DialogResult.Yes)
				{
					new SettingsLoader().CreateDefaultSettingsFile();
					new SettingsLoader().LoadSettings();
					AddDataToControlls();
					m_existChanges = true;
				}
			};
			
			m_form.MEnableSyncCheckBox.CheckedChanged += delegate
			{
				m_form.MSyncGenerateIdButton.Enabled = m_form.MEnableSyncCheckBox.Checked;
				m_form.MSyncIdTextBox.Enabled = m_form.MEnableSyncCheckBox.Checked;
				m_form.MSyncIntervalNumeric.Enabled = m_form.MEnableSyncCheckBox.Checked;
			};
			
			m_form.MSyncGenerateIdButton.Click += delegate { GenerateSyncId(); };
			
			m_form.MSyncNow.Click += delegate
			{
				using(new WaitingForm2("Syncing...", "Please wait", false))
				{
					new SyncController().Sync();
				}
			};
			
			if(Static.StaticData.Settings.Sync.Enable == false)
			{
				m_form.MSyncGenerateIdButton.Enabled = false;
				m_form.MSyncIdTextBox.Enabled = false;
				m_form.MSyncIntervalNumeric.Enabled = false;
			}
			
			m_form.MSyncIdTextBox.Leave += delegate { m_form.MSyncIdTextBox.Text = m_form.MSyncIdTextBox.Text.ToUpper(); };
		}
		
		private void AddDataToControlls()
		{
			foreach(string key in Minder.Static.StaticData.KeysDic.Keys)
			{
				m_form.MKeysComboBox.Items.Add(key);
			}
			
			m_form.MAltCheckBox.Checked = Minder.Static.StaticData.Settings.NewTaskHotkey.Alt;
			m_form.MCtrlCheckBox.Checked = Minder.Static.StaticData.Settings.NewTaskHotkey.Ctrl;
			m_form.MShiftCheckBox.Checked = Minder.Static.StaticData.Settings.NewTaskHotkey.Shift;
			m_form.MWinCheckBox.Checked = Minder.Static.StaticData.Settings.NewTaskHotkey.Win;
			
			for(int i=0; i<m_form.MKeysComboBox.Items.Count; i++)
			{
				if(Minder.Static.StaticData.Settings.NewTaskHotkey.Key
				   .Equals(m_form.MKeysComboBox.Items[i].ToString()))
					m_form.MKeysComboBox.SelectedIndex = i;
			}
			
			m_form.MStartWithWinCheckBox.Checked = Minder.Static.StaticData.Settings.StartWithWindows;
			m_form.MUpdateCheckBox.Checked = Minder.Static.StaticData.Settings.CheckUpdates;
			m_form.MPlaySoundCheckBox.Checked = Minder.Static.StaticData.Settings.PlaySound;
			
			// **** DateFormat tab ****
			m_form.MComboBoxCultureData.Items.Add(new CultureDataLT());
			m_form.MComboBoxCultureData.Items.Add(new CultureDataUK());
			m_form.MComboBoxCultureData.Items.Add(new CultureDataUS());
			
			for(int i = 0; i < m_form.MComboBoxCultureData.Items.Count; i++)
			{
				if(Minder.Static.StaticData.Settings.CultureData.Name
				   .Equals((m_form.MComboBoxCultureData.Items[i] as ICultureData).Name))
				{
					m_form.MComboBoxCultureData.SelectedIndex = i;
					break;
				}
			}
			
			// **** Default Remind Me Later value ****
			m_form.MComboBoxRemindMeLater.Sorted = false;
			TaskShowFormPreparer.AddRemindLaterValuesToComboBox(
				m_form.MComboBoxRemindMeLater,
				TaskShowFormPreparer.BuildRemindLaterList());
			
			TaskShowFormPreparer.SelectRemindMeLater(m_form.MComboBoxRemindMeLater);
			
			// **** Skins ****
			int skinNameIndex = 0;
			foreach(string name in Minder.Static.StaticData.Settings.SkinsUniqueCodes.SkinsUniqueCodesAndNames.Keys)
			{
				m_form.MSkinListBox.Items.Add(name);
				string uniqueCode = Minder.Static.StaticData.Settings.SkinsUniqueCodes.SkinsUniqueCodesAndNames[name];
				if(Minder.Static.StaticData.Settings.SkinUniqueCode.ToUpper().Equals(uniqueCode.ToUpper()))
				{
					m_form.MSkinListBox.SelectedIndex = skinNameIndex;
					m_form.MSkinPreviewPictureBox.Image = new Images().GetImage(uniqueCode.ToUpper());
				}
				skinNameIndex++;
			}
			
			// ***** Sync ******
			m_form.MEnableSyncCheckBox.Checked = Minder.Static.StaticData.Settings.Sync.Enable;
			if(Minder.Static.StaticData.Settings.Sync.Interval <= 0)
				m_form.MSyncIntervalNumeric.Value = 30;
			else
				m_form.MSyncIntervalNumeric.Value = Minder.Static.StaticData.Settings.Sync.Interval;
			m_form.MSyncIdTextBox.Text = Minder.Static.StaticData.Settings.Sync.Id;
			m_form.MLastSyncDate.Value = Minder.Static.StaticData.Settings.Sync.LastSyncDate;
			
		}
		
		private void SetSkinSettings()
		{
			string skinName = m_form.MSkinListBox.Items[m_form.MSkinListBox.SelectedIndex].ToString();
			Minder.Static.StaticData.Settings.SkinUniqueCode = Minder.Static.StaticData.Settings.SkinsUniqueCodes.SkinsUniqueCodesAndNames[skinName];
		}
		
		private void GenerateSyncId()
		{
			string rStr = Path.GetRandomFileName();
			rStr = rStr.Replace(".", ""); // For Removing the .
			rStr = rStr.ToUpper();
			if(string.IsNullOrEmpty(m_form.MSyncIdTextBox.Text))
				m_form.MSyncIdTextBox.Text = rStr;
			else
			{
				if(MessageBox.Show("Do you really want generate new ID and lose your current ID?", "Warrning",
				                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
					m_form.MSyncIdTextBox.Text = rStr;
			}
			
		}
		
		private void FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//Check or exist changes
			if(m_existChanges == true)
			{
				if(MessageBox.Show("Do you want to save changes?", "Settings",
				                   MessageBoxButtons.YesNo) ==  DialogResult.Yes)
				{
					Minder.Static.StaticData.Settings.NewTaskHotkey.Alt = m_form.MAltCheckBox.Checked;
					Minder.Static.StaticData.Settings.NewTaskHotkey.Ctrl = m_form.MCtrlCheckBox.Checked;
					Minder.Static.StaticData.Settings.NewTaskHotkey.Shift = m_form.MShiftCheckBox.Checked;
					Minder.Static.StaticData.Settings.NewTaskHotkey.Win = m_form.MWinCheckBox.Checked;
					Minder.Static.StaticData.Settings.NewTaskHotkey.Key = m_form.MKeysComboBox.SelectedItem.ToString();
					Minder.Static.StaticData.Settings.StartWithWindows = m_form.MStartWithWinCheckBox.Checked;
					Minder.Static.StaticData.Settings.CheckUpdates = m_form.MUpdateCheckBox.Checked;
					Minder.Static.StaticData.Settings.PlaySound = m_form.MPlaySoundCheckBox.Checked;
					if (m_form.MComboBoxCultureData.SelectedItem != null &&
					    m_form.MComboBoxCultureData.SelectedItem is ICultureData)
						Minder.Static.StaticData.Settings.CultureData = m_form.MComboBoxCultureData.SelectedItem as ICultureData;
					if (m_form.MComboBoxRemindMeLater.SelectedItem != null &&
					    m_form.MComboBoxRemindMeLater.SelectedItem is RemindLaterValue)
						Minder.Static.StaticData.Settings.RemindMeLaterDefaultValue = (m_form.MComboBoxRemindMeLater.SelectedItem as RemindLaterValue).Value;
					SetSkinSettings();
					
					Minder.Static.StaticData.Settings.Sync.Id = m_form.MSyncIdTextBox.Text.ToUpper();
					Minder.Static.StaticData.Settings.Sync.Interval = Convert.ToInt32(m_form.MSyncIntervalNumeric.Value);
					Minder.Static.StaticData.Settings.Sync.Enable = m_form.MEnableSyncCheckBox.Checked;
					
					new SettingsLoader().SaveSettingsToFile();
					if(MessageBox.Show("You need restart application to take efect. Do you want restart application now?", "Settings",
					                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
						if(proc.Length > 0)
						{
							foreach(Process proces in proc)
							{
								proces.Kill();
							}
						}
					}
//					new WarningBox("You need restart application to take efect");
				}
				
			}
		}
		
	}
}
