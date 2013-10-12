using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ConfigLoader
/// </summary>
namespace WebSite.Helpers
{
    public class ConfigLoader
    {
        ILog m_log = LogManager.GetLogger(typeof(ConfigLoader));

        public ConfigLoader()
        {
        }

        public void Load()
        {
            Core.ConfigLoader.Load(WebSite.StaticData.CORE_CONFIG_PATH);
            FileInfo config = new FileInfo(WebSite.StaticData.LOG4NET_CONFIG_PATH);
            log4net.Config.XmlConfigurator.Configure(config);

            m_log.Info("Config Loaded!");
        }
    }
}