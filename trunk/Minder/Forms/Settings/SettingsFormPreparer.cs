/*
 * Created by SharpDevelop.
 * User: IGNAS
 * Date: 2012.06.13
 * Time: 23:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Windows.Forms;
using Core.Forms;
using EasyRemainder.Forms.Settings;
using Minder.Static;

namespace Minder.Forms.Settings
{
	/// <summary>
	/// Description of SettingsFromPreparer.
	/// </summary>
	public class SettingsFormPreparer : IFormPreparer
	{
		SettingsForm m_form = null;
		private bool m_existChanges = false;
		
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
			
			m_form.Closing += FormClosing;
		}
		
		private void AddDataToControlls()
		{
			foreach(string key in StaticData.KeysDic.Keys)
			{
				m_form.MKeysComboBox.Items.Add(key);
			}
			
			m_form.MAltCheckBox.Checked = StaticData.Settings.NewTaskHotkey.Alt;
			m_form.MCtrlCheckBox.Checked = StaticData.Settings.NewTaskHotkey.Ctrl;
			m_form.MShiftCheckBox.Checked = StaticData.Settings.NewTaskHotkey.Shift;
			m_form.MWinCheckBox.Checked = StaticData.Settings.NewTaskHotkey.Win;
			
			for(int i=0; i<m_form.MKeysComboBox.Items.Count; i++)
			{
				if(StaticData.Settings.NewTaskHotkey.Key
				   .Equals(m_form.MKeysComboBox.Items[i].ToString()))
					m_form.MKeysComboBox.SelectedIndex = i;
			}
			
			m_form.MStartWithWinCheckBox.Checked = StaticData.Settings.StartWithWindows;
		}
		
		private void FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//Check or exist changes
			if(m_existChanges == true)
			{
				if(MessageBox.Show("Do you want to save changes?", "Settings",
				                   MessageBoxButtons.YesNo) ==  DialogResult.Yes)
				{
					StaticData.Settings.NewTaskHotkey.Alt = m_form.MAltCheckBox.Checked;
					StaticData.Settings.NewTaskHotkey.Ctrl = m_form.MCtrlCheckBox.Checked;
					StaticData.Settings.NewTaskHotkey.Shift = m_form.MShiftCheckBox.Checked;
					StaticData.Settings.NewTaskHotkey.Win = m_form.MWinCheckBox.Checked;
					StaticData.Settings.NewTaskHotkey.Key = m_form.MKeysComboBox.SelectedItem.ToString();
					StaticData.Settings.StartWithWindows = m_form.MStartWithWinCheckBox.Checked;
					
					new SettingsLoader().SaveSettingsToFile();
					new WarningBox("You need restart application to take efect");
				}
				
			}
		}
		
	}
}
