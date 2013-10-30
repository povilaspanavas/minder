﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode;
using XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode.Objects;
using XAFSkelbimaiPrograma.Parser.Helpers;
using XAFSkelbimaiPrograma.Parser.Plugins;

namespace XAFSkelbimaiPrograma.Parser.Services
{
    class AdvertParseService
    {
        private List<SKUserSearchSettings> m_settingsList;
        private Dictionary<string, IPlugin> m_plugins;
        private Dictionary<object, bool?> m_allowParseCache = new Dictionary<object,bool?>();

        public void RunService()
        {
            try
            {
                LoadSettingsCollection();
                StartParsing();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e);
                Console.ResetColor();
            }
        }

        private void LoadSettingsCollection()
        {
            using (Session session = new Session() { ConnectionString = StaticData.CONNECTION_STRING })
            {
                XPClassInfo settingsClass = session.GetClassInfo(typeof(SKUserSearchSettings));
                ICollection settings = session.GetObjects(settingsClass, null, null, 0, 0, false, true);
                session.Disconnect();
                m_settingsList = settings.Cast<SKUserSearchSettings>().ToList();
                m_settingsList = m_settingsList.OrderBy(M => M.LastParseDate).ToList();
            }

        }

        private void StartParsing()
        {
            if (m_settingsList == null)
                return;
            LoadPlugins();

            //.NET 4.5 multithreading
            Parallel.ForEach<SKUserSearchSettings>(m_settingsList, obj =>
            {
                try
                {
                    SKUserSearchSettings settings = obj as SKUserSearchSettings;

                    if (ValidateSettings(settings) == false)
                        return;

                    object userId = settings.SKUser.Oid;
                    string urlLink = settings.Url;
                    object settingsId = settings.Oid;
                    string pluginUniqueCode = settings.Plugin.UniqueCode;

                    if (AllowParse(userId) == false)
                        return;

                    if (string.IsNullOrEmpty(urlLink))
                        return;

                    ParseAdverts(userId, urlLink, settingsId, pluginUniqueCode);
                }
                catch (Exception e)
                {
                    //TODO log to DB
                    throw e;
                }
               
            }
            );
        }

        private bool ValidateSettings(SKUserSearchSettings settings)
        {
            return true;
        }

        private bool AllowParse(object userId)
        {
            //direct sql
            bool? result = null;

            lock (m_allowParseCache) // Lock cache
            {
                m_allowParseCache.TryGetValue(userId, out result);


                if (result != null)
                    return result.Value;

                using (Session session = new Session { ConnectionString = StaticData.CONNECTION_STRING })
                {
                    string query = string.Format("select \"Oid\" from \"SKUserLicense\" where \"SKUser\" = '{0}' and \"Blocked\" = 0", userId);
                    object resultQuery = session.ExecuteScalar(query);
                    session.Disconnect();
                    if (resultQuery != null)
                        result = true;
                    else
                        result = false;


                    m_allowParseCache.Add(userId, result);
                }
            }

            return result.Value;
        }

        private void ParseAdverts(object userId, string urlLink, object settingsId, string pluginUniqueCode)
        {
            IPlugin plugin = GetPluginByUniqueCode(pluginUniqueCode);
            if (plugin == null)
                return;
            List<AdvertDto> adverts = plugin.Parse(urlLink);
            SetAdditionalInfoToAdverts(adverts, userId, settingsId);
            SetLastParseDate(settingsId);
            new SaveHelper().SaveAdverts(adverts);
        }

        private void SetLastParseDate(object settingsId)
        {
            using (Session session = new Session { ConnectionString = StaticData.CONNECTION_STRING })
            {
                string query = string.Format("update \"SKUserSearchSettings\" set \"LastParseDate\" "+
                    "= '{0}' where \"Oid\" = '{1}'", DateTime.Now, settingsId);
                session.ExecuteNonQuery(query);
                session.Disconnect();
            }
        }

        private void SetAdditionalInfoToAdverts(List<AdvertDto> adverts, object userId, object settingsId)
        {
            foreach (AdvertDto advert in adverts)
            {
                advert.UserId = userId;
                advert.SettingsId = settingsId;
                advert.Date = DateTime.Now;
            }
        }

        private void LoadPlugins()
        {
            m_plugins = new Dictionary<string, IPlugin>();
            var instances = from t in Assembly.GetExecutingAssembly().GetTypes()
                            where t.GetInterfaces().Contains(typeof(IPlugin))
                                     && t.GetConstructor(Type.EmptyTypes) != null
                            select Activator.CreateInstance(t) as IPlugin;
            foreach (IPlugin plugin in instances)
            {
                m_plugins.Add(plugin.UniqueCode, plugin);
            }

        }

        private IPlugin GetPluginByUniqueCode(string uniqueCode)
        {
            IPlugin result = null;
            m_plugins.TryGetValue(uniqueCode, out result);
            return result;
        }
    }
}
