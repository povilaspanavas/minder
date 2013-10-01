/*
 * Created by SharpDevelop.
 * User: Ignas T60
 * Date: 2013-09-28
 * Time: 15:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading;
using AdvertModel;
using AdvertParsingService.Modules;
using Core;
using Core.DB;
using log4net;

namespace AdvertParsingService.Service
{
	/// <summary>
	/// Description of AdvertService.
	/// </summary>
	public class AdvertService
	{
		ILog m_log;
		
		public AdvertService()
		{
			LoadConfig();
		}
		
		public void Start()
		{
			RunService();
			Thread.Sleep(2000);
		}
		
		private void RunService()
		{
			List<Settings> allSettings = GenericDbHelper.Get<Settings>();
			m_log.Info("Loaded settings: "+allSettings.Count);
			Console.WriteLine("Loaded settings: "+allSettings.Count);
			
			foreach(Settings settings in allSettings)
			{
				try 
				{
					ParseAdverts(settings);
				} 
				catch (Exception e) 
				{
					m_log.Error(e);
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine(e.Message);
					Console.ResetColor();
				}
				
			}
		}
		
		private void ParseAdverts(Settings settings)
		{
			m_log.Info(string.Format("Parsing settings: {0} from {1} for {2} user!",
			                         settings.Name, settings.UniqueCode, settings.UserId));
			Console.WriteLine(string.Format("Parsing settings: {0} from {1} for {2} user!",
			                         settings.Name, settings.UniqueCode, settings.UserId));
			List<Advert> adverts = null;
			
			if(settings.UniqueCode.Equals(PluginsUniqueCodes.PluginsUniquecodes[0]))
				adverts = new ModuleAutogidas().Parse(settings.Url);
			if(settings.UniqueCode.Equals(PluginsUniqueCodes.PluginsUniquecodes[1]))
				adverts = new ModuleAutoplius().Parse(settings.Url);
			
			SetAdditionalFieldsAndSave(adverts, settings);
		}
		
		private void SetAdditionalFieldsAndSave(List<Advert> adverts, Settings settings)
		{
			m_log.Info(string.Format("Parsed: {0} adverts", adverts.Count));
			Console.WriteLine(string.Format("Parsed: {0} adverts", adverts.Count));
			bool notNewSettings = CheckOrThisSettingsExistAdverts(settings);
			
			int savedCount = 0;
			foreach(Advert advert in adverts)
			{
				bool exist = CheckOrExist(advert.UrlLink, settings.UserId, settings.Id);
				if(exist)
					continue;
				
				advert.SettingsId = settings.Id;
				advert.UserId = settings.UserId;
				advert.DateA = DateTime.Now.ToString();
				advert.SettingsName = settings.Name;
				advert.PluginName = settings.UniqueCode;
				if(notNewSettings == false)
					advert.Deleted = true;
				
				GenericDbHelper.Save(advert);
				savedCount++;
			}
			GenericDbHelper.Flush();
			Console.WriteLine("Saved adverts to DB: "+savedCount);
		}
		
		private bool CheckOrThisSettingsExistAdverts(Settings settings)
		{
			List<Advert> adverts = GenericDbHelper.Get<Advert>("SETTINGS_ID = "+settings.Id);
			if(adverts.Count == 0)
				return false;
			else
				return true;
		}
		
		private bool CheckOrExist(string url, int userId, int settingsId)
		{
			List<Advert> adverts = GenericDbHelper
				.Get<Advert>(string.Format("URL_LINK = '{0}' and USER_ID = {1} and SETTINGS_ID = {2}",
				                           url, userId, settingsId));
			if(adverts.Count == 0)
				return false;
			else
				return true;
		}
		
		private void LoadConfig()
		{
			ConfigLoader.Load();
			FileInfo config = new FileInfo("log4net.xml");
			log4net.Config.XmlConfigurator.Configure(config);
			
			m_log = LogManager.GetLogger(typeof(AdvertService));
			m_log.Info("Config loaded!");
			Console.WriteLine("Config loaded!");
		}
	}
}
