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
			m_form.Closing += FormClosing;
			
		}
		
		private void AddDataToControlls()
		{
			foreach(string key in StaticData.KeysDic.Keys)
			{
				m_form.m_keysComboBox.Items.Add(key);
			}
			
			new SettingsLoader().LoadSettings();
		}
		
		private void FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//Check or exist changes
			
			if(MessageBox.Show("Do you want to save changes?", "Settings",
			                   MessageBoxButtons.YesNo) ==  DialogResult.No)
			{
//				e.Cancel = true;
			}
			
			
		}
		
	}
}
