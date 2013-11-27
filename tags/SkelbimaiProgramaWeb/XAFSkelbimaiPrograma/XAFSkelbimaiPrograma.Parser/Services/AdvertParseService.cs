using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
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
        private static Dictionary<object, UserParseInfoDto> m_allowParseCache = new Dictionary<object, UserParseInfoDto>();
        private Session m_session;

        public void RunService()
        {
            try
            {
                using (m_session = new Session { ConnectionString = StaticData.CONNECTION_STRING })
                {
                    LoadSettingsCollection();
                    StartParsing();
                }

            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e);
                Console.ResetColor();
            }
        }

        private int LoadLinkCountLimit()
        {
            string[] lines = File.ReadAllLines("LinkLoadLimit.txt");
            return Convert.ToInt32(lines[0]);
        }

        private void LoadSettingsCollection()
        {
            ConsoleHelper.WriteLineWithTime("Loading settings and reserving...");
            string machineName = Environment.MachineName + StaticVars.StartDate;
            int rows = LoadLinkCountLimit();

            string reserveQuery = string.Format("update \"SKUserSearchSettings\" a set a.\"Reserved\" = '{1}' " +
            "where a.\"Oid\" in (select first {0} b.\"Oid\" from \"SKUserSearchSettings\" b where " +
            "b.\"Reserved\" is null and b.\"Blocked\" = 0 and b.\"GCRecord\" is null order by b.\"LastParseDate\")", rows, machineName);

            bool notExecuted = true;
            while (notExecuted)
            {
                try
                {
                    m_session.ExecuteNonQuery(reserveQuery);
                    notExecuted = false;
                }
                catch
                {
                    //Dead lock
                    ConsoleHelper.WriteLineWithTime("Deadlok in reserve links!");
                    Thread.Sleep(500);
                }

            }

            XPCollection<SKUserSearchSettings> settingsXpCollection =
                new XPCollection<SKUserSearchSettings>(m_session,
                    CriteriaOperator.Parse(string.Format("Reserved = '{0}'", machineName)),
                    null);

            m_settingsList = settingsXpCollection.Cast<SKUserSearchSettings>().ToList();
            m_settingsList = m_settingsList.OrderBy(M => M.LastParseDate).ToList();

            ConsoleHelper.WriteLineWithTime("Settings loaded " + m_settingsList.Count);
        }

        private void StartParsing()
        {
            if (m_settingsList == null)
                return;
            LoadPlugins();

            //.NET 4.5 multithreading
            Parallel.ForEach<SKUserSearchSettings>(m_settingsList, obj =>
           //foreach (SKUserSearchSettings obj in m_settingsList)
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

                   UserParseInfoDto info = AllowParse(userId);
                   if (info == null)
                       return;

                   if (string.IsNullOrEmpty(urlLink))
                       return;

                   info = OverideParseInfo(info, settings);
                   ParseAdverts(userId, urlLink, settingsId, pluginUniqueCode, info);
                   ConsoleHelper.WriteLineWithTime(string.Format("Parsed: {0}", settings.Plugin.Name));
               }
               catch (Exception e)
               {
                   //log to DB
                   SKUserSearchSettings settings = obj as SKUserSearchSettings;
                   new LogDBHelper().Log(e, settings, LogType.ParserError);

                   Console.ForegroundColor = ConsoleColor.Red;
                   Console.WriteLine(e);
                   Console.ResetColor();
                   
               }

           }
           );
            UnreserveSettings();
        }

        public void UnreserveSettings()
        {
            ConsoleHelper.WriteLineWithTime("Unreserving settings...");
            string query = string.Format("update \"SKUserSearchSettings\" set \"Reserved\" = null where \"Reserved\" = '{0}'", Environment.MachineName + StaticVars.StartDate);
            bool notExecuted = true;
            while (notExecuted)
            {
                try
                {
                    m_session.ExecuteNonQuery(query);
                    notExecuted = false;
                }
                catch
                {
                    //Dead lock
                    Thread.Sleep(500);
                }

            }

            ConsoleHelper.WriteLineWithTime("Settings unreserved");
        }

        private UserParseInfoDto OverideParseInfo(UserParseInfoDto info, SKUserSearchSettings settings)
        {
            UserParseInfoDto result = new UserParseInfoDto();
            result.AllowParse = true;
            result.Email = info.Email;
            result.Photo = info.Photo;
            result.UserId = info.UserId;

            if (result.Email == true)
                result.Email = settings.SendEmail;
            if (result.Photo == true)
                result.Photo = settings.LoadPhoto;

            return result;
        }

        private bool ValidateSettings(SKUserSearchSettings settings)
        {
            bool result = false;

            if (string.IsNullOrEmpty(settings.Url) || settings.SKUser == null || settings.Plugin == null)
                result = false;
            else if (settings.Url.IndexOf("http://") == -1)
                result = false;
            //else if (settings.Url.ToLower().Replace(".", "").IndexOf(settings.Plugin.UniqueCode.ToLower().Replace()) == -1)
            //    result = false;
            else
                result = true;

            if (result == false)
            {
                //Block
                //Session session = new Session { ConnectionString = StaticData.CONNECTION_STRING };

                m_session.ExecuteNonQuery(string.Format("update \"SKUserSearchSettings\" set \"Blocked\" = 1 where \"Oid\" = '{0}'",
                    settings.Oid));
            }

            return result;
        }

        private UserParseInfoDto AllowParse(object userId)
        {
            UserParseInfoDto result = null;

            lock (m_allowParseCache) // Lock cache
            {
                bool found = m_allowParseCache.TryGetValue(userId, out result);
                if (found == true)
                    return result;

                string query = string.Format("select a.\"SKUser\" as UserId, b.\"Email\" as Email, b.\"Photo\" as Photo from \"SKUserLicense\" a left join \"SKLicenseType\" b on b.\"Oid\" = a.\"LicenseType\" where \"Blocked\" = 0 and a.\"SKUser\" = '{0}'", userId);
                SelectedData resultQuery = m_session.ExecuteQuery(query);

                foreach (SelectStatementResultRow row in resultQuery.ResultSet[0].Rows)
                {
                    UserParseInfoDto userInfoDto = new UserParseInfoDto();
                    userInfoDto.AllowParse = true;
                    userInfoDto.Email = Convert.ToBoolean(Convert.ToInt32(row.Values[1]));
                    userInfoDto.Photo = Convert.ToBoolean(Convert.ToInt32(row.Values[2]));
                    userInfoDto.UserId = row.Values[0];
                    m_allowParseCache.Add(userId, userInfoDto);
                    result = userInfoDto;
                }
            }

            return result;
        }

        private void ParseAdverts(object userId, string urlLink, object settingsId,
            string pluginUniqueCode, UserParseInfoDto info)
        {
            IPlugin plugin = GetPluginByUniqueCode(pluginUniqueCode);
            if (plugin == null)
                return;
            List<AdvertDto> adverts = plugin.Parse(urlLink, info);
            SetAdditionalInfoToAdverts(adverts, userId, settingsId);
            SetLastParseDate(settingsId);
            new SaveHelper(m_session, info).SaveAdverts(adverts);
        }

        private void SetLastParseDate(object settingsId)
        {
            string query = string.Format("update \"SKUserSearchSettings\" set \"LastParseDate\" " +
                "= '{0}' where \"Oid\" = '{1}'", DateTime.Now, settingsId);
            m_session.ExecuteNonQuery(query);
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
