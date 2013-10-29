using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
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
        private ICollection m_settings;
        private Dictionary<string, IPlugin> m_plugins;

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
                m_settings = session.GetObjects(settingsClass, null, null, 0, 0, false, true);
                session.Disconnect();
            }

        }

        private void StartParsing()
        {
            if (m_settings == null)
                return;
            LoadPlugins();
            //.NET 4.5 multithreading
            List<SKUserSearchSettings> settingsList = m_settings.Cast<SKUserSearchSettings>().ToList();

            //Parallel.ForEach<SKUserSearchSettings>(settingsList, obj =>
            foreach (SKUserSearchSettings settings in settingsList)
            {
                //SKUserSearchSettings settings = obj as SKUserSearchSettings;
                if (settings.SKUser == null || settings.Plugin == null)
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
            //);
        }

        private bool AllowParse(object userId)
        {
            //direct sql
            using (Session session = new Session { ConnectionString = StaticData.CONNECTION_STRING })
            {
                string query = string.Format("select \"Oid\" from \"SKUserLicense\" where \"SKUser\" = '{0}' and \"Blocked\" = 0", userId);
                object result = session.ExecuteScalar(query);
                session.Disconnect();
                if (result != null)
                    return true;
                else
                    return false;
            }
        }

        private void ParseAdverts(object userId, string urlLink, object settingsId, string pluginUniqueCode)
        {
            IPlugin plugin = GetPluginByUniqueCode(pluginUniqueCode);
            if (plugin == null)
                return;
            List<AdvertDto> adverts = plugin.Parse(urlLink);
            SetAdditionalInfoToAdverts(adverts, userId, settingsId);
            new SaveHelper().SaveAdverts(adverts);
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
