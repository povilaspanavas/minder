﻿
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Windows.Forms;
using Core;
using Core.Forms;
using Core.Tools.Log;
using Minder.Engine.Helpers;
using Minder.Engine.Sync;
using Minder.Forms.Settings;
using Minder.Engine;
using Minder.Forms.Main;
using Minder.Objects;
using Minder.Sql;
using Minder.Sql.DBVersionSystem;
using Minder.Tools;
using Minder.UI.Helpers;

namespace Minder
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class BootStrap
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			try
			{
//				if (IsWriteAccess() == false)
//					return;
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Starter(args);
				Application.Run();
			}
			catch (Exception e)
			{
				new ErrorBox("We are very sorry, but the program crashed. Please contact support at " +
				             "http://code.google.com/p/minder/issues/list. Thank you for your patience.\n\n" +
				             "P.S. you can copy error message by pressing clr + C. Have a nice day."); // This shows error box and writes to log.
				try
				{
					log4net.ILog log = log4net.LogManager.GetLogger(typeof(BootStrap));
					log.Fatal(e);
				}
				catch{} //Jei konfigai neužkrauti
				
				Application.Exit();
			}
		}
		
		private static void Starter(string[] args)
		{
			ConfigLoader.Load();
			string log4netConfigPath = new PathCutHelper()
				.CutExecutableFileFromPath(System.Reflection.Assembly
				                           .GetExecutingAssembly().Location);
			log4netConfigPath += @"\Minder.log4net.xml";
			FileInfo config = new FileInfo(log4netConfigPath);
			log4net.Config.XmlConfigurator.Configure(config);
			log4net.ILog logger = log4net.LogManager.GetLogger(typeof(BootStrap));
			
			bool openForm = false;
			if(args != null)
			{
				foreach(string arg in args)
				{
					if(arg.ToLower().Equals("--openform"))
						openForm = true;
				}
			}
			
			SettingsLoader loader = new SettingsLoader();
			loader.LoadSettings();
			Minder.Static.StaticData.Settings.LogFilePath = @"Log\Minder.log";

			UpdateDBVersion();
			Info syncInfo = InfoFinder.FindByUniqueCode(Minder.Static.StaticData.InfoUniqueCodes.InfoLastSyncDate);
			if(syncInfo != null)
				Minder.Static.StaticData.Settings.Sync.LastSyncDate = Convert.ToDateTime(syncInfo.Value1);
			
			new StartWithWinController().StartWithWindows();
			if(Minder.Static.StaticData.Settings.CheckUpdates)
				new UpdateProject(StaticData.VersionCache.Version, true, "Minder");
			
			MainFormPreparer preparer = new MainFormPreparer();
			if(openForm)
				preparer.PrepareForm(openForm);
			else
				preparer.PrepareForm();
			
			MousePositionHelper mouseMoveChecker = new MousePositionHelper();
			mouseMoveChecker.SartMouseMoveChecker();
			
			TimeController timeController = new TimeController(preparer);
			timeController.Start();
			
			logger.Info("Minder started");
		}
		
		/// <summary>
		/// Checks if update is necessary. If no, does nothing, if yes updates
		/// </summary>
		public static void UpdateDBVersion()
		{
			new DBVersionSystem(new DBVersionRepository().AddVersions(typeof(Task).Assembly)).UpdateToNewest();
		}
		
		/// <summary>
		/// Checks for write access. If program cannot write, then
		/// shows message about this error and returns false
		/// </summary>
		/// <returns></returns>
		public static bool IsWriteAccess()
		{
			bool writeAccess = false;
			try {
				Directory.CreateDirectory("test654");
				Directory.Delete("test654");
				writeAccess = true;
			} catch(Exception) {
				new MessageBoxHelper().ShowErrorOk("Program doesn't have write permissions. Please fix it.");
			}
			return writeAccess;
		}
	}
}
