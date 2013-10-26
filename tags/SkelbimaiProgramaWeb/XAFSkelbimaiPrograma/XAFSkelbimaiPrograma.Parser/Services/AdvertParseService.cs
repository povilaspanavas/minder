using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
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
            LoadSettingsCollection();
            StartParsing();
        }

        private void LoadSettingsCollection()
        {
            Session session = new Session() { ConnectionString = StaticData.CONNECTION_STRING };
            XPClassInfo settingsClass = session.GetClassInfo(typeof(SKUserSearchSettings));
            m_settings = session.GetObjects(settingsClass, null, null, 0, 0, false, true);
        }

        private void StartParsing()
        {
            if (m_settings == null)
                return;

            //TODO reikia čia lygiagretinti

            foreach (object obj in m_settings)
            {
                SKUserSearchSettings settings = obj as SKUserSearchSettings;
                if(settings.SKUser == null || settings.Plugin == null)
                    continue;

                object userId = settings.SKUser.Oid;
                string urlLink = settings.Url;
                object settingsId = settings.Oid;
                string pluginUniqueCode = settings.Plugin.UniqueCode;

                if (AllowParse(userId) == false)
                    continue;
                
                if (string.IsNullOrEmpty(urlLink))
                    continue;

                ParseAdverts(userId, urlLink, settingsId, pluginUniqueCode);
            }
        }

        private bool AllowParse(object userId)
        {
            Session session = new Session { ConnectionString = StaticData.CONNECTION_STRING };
            XPClassInfo licenceClass = session.GetClassInfo(typeof(SKUserLicense));
            ICollection licences = session.GetObjects(licenceClass, CriteriaOperator.Parse(string.Format("SKUser.Oid = '{0}' AND (Blocked = false or Blocked = null)", userId)), null, 0, 0, false, true);
            List<SKUserLicense> licencesList = licences.Cast<SKUserLicense>().ToList();
            if (licencesList.Count != 1)
                return false;
            return true;
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

        private IPlugin GetPluginByUniqueCode(string uniqueCode)
        {
            if (m_plugins == null) //Indexing
            {
                var instances = from t in Assembly.GetExecutingAssembly().GetTypes()
                                where t.GetInterfaces().Contains(typeof(IPlugin))
                                         && t.GetConstructor(Type.EmptyTypes) != null
                                select Activator.CreateInstance(t) as IPlugin;
                m_plugins = new Dictionary<string, IPlugin>();
                foreach (IPlugin plugin in instances)
                {
                    m_plugins.Add(plugin.UniqueCode, plugin);
                }

            }

            IPlugin result;
            m_plugins.TryGetValue(uniqueCode, out result);
            return result;
        }
    }
}
