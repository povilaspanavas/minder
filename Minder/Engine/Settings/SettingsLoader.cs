/*
 * Created by SharpDevelop.
 * User: IGNAS
 * Date: 2012.06.15
 * Time: 21:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Globalization;
using System.IO;
using Minder.Engine.Parse;
using Minder.Static;
using Minder.Tools;
using Minder.UI.Forms.TaskShow;

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
		
		/// <summary>
		/// Jei nepavyksta pasikrauti, tai sukuriam defaultinius ir pasikraunam
		/// </summary>
		public void LoadSettings()
		{
			try
			{
				LoadFromSettingsFile();
			}
			catch(Exception)
			{
				CreateDefaultSettingsFile();
				LoadFromSettingsFile();
			}
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
			iniParser.AddSetting("General", "playsound", "true");
			iniParser.AddSetting("CultureInfo", "name", "lt-Lt");
			iniParser.AddSetting("RemindMeLater", "Default", RemindLaterValue.Round(10.0m/60.0m).ToString());
			iniParser.AddSetting("Skin", "code", StaticData.Settings.SkinsUniqueCodes.DEFAULT_SKIN_UNIQUE_CODE);
			iniParser.AddSetting("Sync", "enable", "false");
			iniParser.AddSetting("Sync", "ID", "");
			iniParser.AddSetting("Sync", "interval", "30");
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
			StaticData.Settings.PlaySound = Convert.ToBoolean(parser.GetSetting("General", "playsound"));
			string cultureInfoName = parser.GetSetting("CultureInfo", "Name");
			if (string.IsNullOrEmpty(cultureInfoName))
				cultureInfoName = "en-uk";
			switch (cultureInfoName.ToLower()) {
				case "lt-lt":
					StaticData.Settings.CultureData = new CultureDataLT();
					break;
				case "en-uk":
				case "en-gb":
					StaticData.Settings.CultureData = new CultureDataUK();
					break;
				case "en-us":
					StaticData.Settings.CultureData = new CultureDataUS();
					break;
				default:
					StaticData.Settings.CultureData = new CultureDataLT();
					break;
			}
			
			decimal remindLaterDefaultValue = 10.0m/60.0m;
			decimal.TryParse(parser.GetSetting("RemindMeLater", "Default"), out remindLaterDefaultValue);
			StaticData.Settings.RemindMeLaterDefaultValue = RemindLaterValue.Round(remindLaterDefaultValue);
			
			
			//Skins
			StaticData.Settings.SkinUniqueCode = parser.GetSetting("skin", "code");
			if (string.IsNullOrEmpty(StaticData.Settings.SkinUniqueCode))
				StaticData.Settings.SkinUniqueCode = StaticData.Settings.SkinsUniqueCodes.DEFAULT_SKIN_UNIQUE_CODE;
			
			//Sync
			StaticData.Settings.Sync.Id = parser.GetSetting("sync", "id");
			StaticData.Settings.Sync.Enable = Convert.ToBoolean(parser.GetSetting("sync", "enable"));
			StaticData.Settings.Sync.Interval = Convert.ToInt32(parser.GetSetting("sync", "interval"));
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
			parser.DeleteSetting("general", "playsound");
			parser.DeleteSetting("CultureInfo", "name");
			parser.DeleteSetting("RemindMeLater", "default");
			parser.DeleteSetting("skin", "code");
			parser.DeleteSetting("sync", "id");
			parser.DeleteSetting("sync", "interval");
			parser.DeleteSetting("sync", "enable");
			
			parser.AddSetting("NewTaskHotkey", "alt", StaticData.Settings.NewTaskHotkey.Alt.ToString());
			parser.AddSetting("NewTaskHotkey", "ctrl", StaticData.Settings.NewTaskHotkey.Ctrl.ToString());
			parser.AddSetting("NewTaskHotkey", "shift", StaticData.Settings.NewTaskHotkey.Shift.ToString());
			parser.AddSetting("NewTaskHotkey", "win", StaticData.Settings.NewTaskHotkey.Win.ToString());
			parser.AddSetting("NewTaskHotkey", "key", StaticData.Settings.NewTaskHotkey.Key);
			
			parser.AddSetting("General", "startwithwindows", StaticData.Settings.StartWithWindows.ToString());
			parser.AddSetting("General", "autoupdate", StaticData.Settings.CheckUpdates.ToString());
			parser.AddSetting("General", "playsound", StaticData.Settings.PlaySound.ToString());
			parser.AddSetting("CultureInfo", "name", StaticData.Settings.CultureData.CultureInfo.Name.ToString());
			parser.AddSetting("RemindMeLater", "default", RemindLaterValue.Round(StaticData.Settings.RemindMeLaterDefaultValue).ToString());
			parser.AddSetting("skin", "code", StaticData.Settings.SkinsUniqueCodes.DEFAULT_SKIN_UNIQUE_CODE);
			parser.AddSetting("sync", "id", StaticData.Settings.Sync.Id);
			parser.AddSetting("sync", "interval", StaticData.Settings.Sync.Interval.ToString());
			parser.AddSetting("sync", "enable", StaticData.Settings.Sync.Enable.ToString());
			
			parser.SaveSettings();
		}
		
	}
}
