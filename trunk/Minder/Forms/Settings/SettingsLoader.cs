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

namespace EasyRemainder.Forms.Settings
{
	/// <summary>
	/// Description of SettingsLoader.
	/// </summary>
	public class SettingsLoader
	{	
		public void LoadSettings()
		{
			LoadFromSettingsFile();
		}
		
		public void CreateDefaultSettingsFile()
		{
			StreamWriter writer = new StreamWriter(StaticData.SETTINGS_FILE_PATH);
			writer.Close();
			IniParser iniParser = new IniParser(StaticData.SETTINGS_FILE_PATH);
			iniParser.AddSetting("NewTaskHotkey", "Ctrl", "false");
			iniParser.AddSetting("NewTaskHotkey", "Alt", "true");
			iniParser.AddSetting("NewTaskHotkey", "Win", "false");
			iniParser.AddSetting("NewTaskHotkey", "Shift", "false");
			iniParser.AddSetting("NewTaskHotkey", "Key", "N");
			iniParser.SaveSettings();
		}
		
		private void LoadFromSettingsFile()
		{
			if(File.Exists(StaticData.SETTINGS_FILE_PATH) == false)
				CreateDefaultSettingsFile();
			//HotKey settings
			IniParser parser = new IniParser(StaticData.SETTINGS_FILE_PATH);
			StaticData.Settings.NewTaskHotkey.Alt = Convert.ToBoolean(parser.GetSetting("NewTaskHotkey", "alt"));
			StaticData.Settings.NewTaskHotkey.Ctrl = Convert.ToBoolean(parser.GetSetting("NewTaskHotkey", "ctrl"));
			StaticData.Settings.NewTaskHotkey.Shift = Convert.ToBoolean(parser.GetSetting("NewTaskHotkey", "shift"));
			StaticData.Settings.NewTaskHotkey.Win = Convert.ToBoolean(parser.GetSetting("NewTaskHotkey", "win"));
			StaticData.Settings.NewTaskHotkey.Key = parser.GetSetting("NewTaskHotkey", "key");
		}
		
	}
}
