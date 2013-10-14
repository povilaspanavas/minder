using AdvertModel;
using Core;
using log4net;
/*
 * Created by SharpDevelop.
 * User: Ignas T60
 * Date: 2013-10-14
 * Time: 18:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using SystemUpdater.Runable;

namespace SystemUpdater
{
    class BootStrap
    {
        public static void Main(string[] args)
        {
            LoadConfig();
            if (args.Length != 1)
                throw new Exception("Not assembly path given!");
            new DbVersionRunner(args[0]).Execute();
        }

        private static void LoadConfig()
        {
            ConfigLoader.Load();
            FileInfo config = new FileInfo("log4net.xml");
            log4net.Config.XmlConfigurator.Configure(config);

            LogManager.GetLogger(typeof(BootStrap)).Info("Config Loaded!");
        }
    }
}