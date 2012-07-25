/*
 * Created by SharpDevelop.
 * User: IGNAS
 * Date: 2012.06.15
 * Time: 21:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using Minder.Static;
using Minder.Tools;

namespace Minder.Forms.Settings
{
	/// <summary>
	/// Description of SettingsLoader.
	/// </summary>
	public class SettingsLoader
	{	
		private string m_settingsPath = new PathCutHelper()
					.CutExecutableFileFromPath(System.Reflection.Assembly
					                           .GetExecutingAssembly()
					                           .Location)+@"\"+StaticData.SETTINGS_FILE_PATH;
		
		public void LoadSettings()
		{
			LoadFromSettingsFile();
		}
		
		public void CreateDefaultSettingsFile()
		{
			StreamWriter writer = new StreamWriter(m_settingsPath);
			writer.Close();
			IniParser iniParser = new IniParser(m_settingsPath);
			iniParser.AddSetting("NewTaskHotkey", "Ctrl", "false");
			iniParser.AddSetting("NewTaskHotkey", "Alt", "true");
			iniParser.AddSetting("NewTaskHotkey", "Win", "false");
			iniParser.AddSetting("NewTaskHotkey", "Shift", "false");
			iniParser.AddSetting("NewTaskHotkey", "Key", "N");
			iniParser.AddSetting("General", "startwithwindows", "true");
			iniParser.AddSetting("General", "autoupdate", "true");
			iniParser.AddSetting("CultureInfo", "name", "lt-Lt");
			iniParser.SaveSettings();
		}
		
		private void LoadFromSettingsFile()
		{
			if(File.Exists(m_settingsPath) == false)
				CreateDefaultSettingsFile();
			//HotKey settings
			IniParser parser = new IniParser(m_settingsPath);
			StaticData.Settings.NewTaskHotkey.Alt = Convert.ToBoolean(parser.GetSetting("NewTaskHotkey", "alt"));
			StaticData.Settings.NewTaskHotkey.Ctrl = Convert.ToBoolean(parser.GetSetting("NewTaskHotkey", "ctrl"));
			StaticData.Settings.NewTaskHotkey.Shift = Convert.ToBoolean(parser.GetSetting("NewTaskHotkey", "shift"));
			StaticData.Settings.NewTaskHotkey.Win = Convert.ToBoolean(parser.GetSetting("NewTaskHotkey", "win"));
			StaticData.Settings.NewTaskHotkey.Key = parser.GetSetting("NewTaskHotkey", "key");
			//General
			StaticData.Settings.StartWithWindows = Convert.ToBoolean(parser.GetSetting("General", "startwithwindows"));
			StaticData.Settings.CheckUpdates = Convert.ToBoolean(parser.GetSetting("General", "autoupdate"));
			string cultureInfoName = parser.GetSetting("CultureInfo", "Name");
			StaticData.Settings.CultureInfo = new System.Globalization.CultureInfo(cultureInfoName);
		}
		
		public void SaveSettingsToFile()
		{
			IniParser parser = new IniParser(m_settingsPath);
			parser.DeleteSetting("NewTaskHotkey", "alt");
			parser.DeleteSetting("NewTaskHotkey", "ctrl");
			parser.DeleteSetting("NewTaskHotkey", "shift");
			parser.DeleteSetting("NewTaskHotkey", "win");
			parser.DeleteSetting("NewTaskHotkey", "key");
			parser.DeleteSetting("general", "startwithwindows");
			parser.DeleteSetting("general", "autoupdate");
			parser.DeleteSetting("CultureInfo", "name");
			
			parser.AddSetting("NewTaskHotkey", "alt", StaticData.Settings.NewTaskHotkey.Alt.ToString());
			parser.AddSetting("NewTaskHotkey", "ctrl", StaticData.Settings.NewTaskHotkey.Ctrl.ToString());
			parser.AddSetting("NewTaskHotkey", "shift", StaticData.Settings.NewTaskHotkey.Shift.ToString());
			parser.AddSetting("NewTaskHotkey", "win", StaticData.Settings.NewTaskHotkey.Win.ToString());
			parser.AddSetting("NewTaskHotkey", "key", StaticData.Settings.NewTaskHotkey.Key);
			
			parser.AddSetting("General", "startwithwindows", StaticData.Settings.StartWithWindows.ToString());
			parser.AddSetting("General", "autoupdate", StaticData.Settings.CheckUpdates.ToString());
			parser.AddSetting("CultureInfo", "name", StaticData.Settings.CultureInfo.Name.ToString());
			
			parser.SaveSettings();
		}
		
	}
}
