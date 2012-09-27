/*
 * Created by SharpDevelop.
 * User: IGNAS
 * Date: 2012.06.14
 * Time: 22:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Windows.Forms;
using Core.CoreInfo;
using Core.Forms;
using Minder.Static;

namespace Minder.Forms.About
{
	/// <summary>
	/// Description of AboutFormPreparer.
	/// </summary>
	public class AboutFormPreparer : IFormPreparer
	{
		log4net.ILog m_log = log4net.LogManager.GetLogger(typeof(AboutFormPreparer));
		
		AboutForm m_form = null;
		
		public AboutFormPreparer()
		{
			m_form = new AboutForm();
			m_form.Text = "About";
		}
		
		public System.Windows.Forms.Form Form {
			get {
				return m_form;
			}
		}
		
		public void PrepareForm()
		{
			SetEvents();
			m_form.MVersionLabel.Text = string.Format("Version: RC {0}", Core.StaticData.VersionCache.Version);
			m_form.MCoreVersionLabel.Text = string.Format("Core version: {0}", CoreVersionInfo.Version);
			m_form.ShowDialog();
		}
		
		public void SetEvents()
		{
			m_form.MLinkLabelSupport.Click += delegate
			{
				System.Diagnostics.Process.Start("http://code.google.com/p/minder/");
			};
			ConfigureLogLabel(m_form.MLabelLogFile);
		}
		
		private void ConfigureLogLabel(LinkLabel linkLabel)
		{
			m_form.MLabelLogFile.Text = Static.StaticData.Settings.LogFilePath;
			m_form.toolTip1.SetToolTip(linkLabel, "Click to open log file");
			
			string link = Static.StaticData.Settings.LogFilePath;
			if (File.Exists(link) == false)
			{
				m_log.Error(new ArgumentException(string.Format("File was not found. File Path:\n'{0}'", Path.GetFullPath(link))));
				linkLabel.Enabled = false;
				m_form.toolTip1.SetToolTip(linkLabel, "Log failas nerastas");
			}
			
			linkLabel.Click+= delegate
			{
				System.Diagnostics.Process.Start(link);
			};
		}
	}
}
