
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Core;
using Core.Forms;
using Core.Tools.Log;
using Minder.Engine.Sync;
using Minder.Forms.Settings;
using Minder.Engine;
using Minder.Forms.Main;
using Minder.Objects;
using Minder.Sql;
using Minder.Sql.DBVersionSystem;
using Minder.Tools;

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
				// TODO Ignai, kaip tavo logeriu naudotis? Reikia įloginti klaidą.
				// Reikia ErrorBox, kuris ne tik išveda pranešimą, bet ir ima klaidą (Exception), kurią įlogina
				// (kartu ir su originaliu tekstu, o ne paduotu).
				try
				{
					new Loger().LogWrite(e.ToString(), LogerType.Fatal);
				}
				catch{} //Jei konfigai neužkrauti
				
				Application.Exit();
			}
		}
		
		private static void Starter(string[] args)
		{
			ConfigLoader.Load();
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
			
			UpdateDBVersion();
			
			new StartWithWinController().StartWithWindows();
//				new UpdateVersion();
			if(Minder.Static.StaticData.Settings.CheckUpdates)
				new UpdateProject(StaticData.VersionCache.Version, true, "Minder");
			
			//Sync
			if(Minder.Static.StaticData.Settings.Sync.Enable)
			{
				using(new WaitingForm("Syncing tasks...", "Please wait"))
				{
					new SyncController().Sync();
					new SyncController().StartThreadForSync();
				}
			}
			
			MainFormPreparer preparer = new MainFormPreparer();
			if(openForm)
				preparer.PrepareForm(openForm);
			else
				preparer.PrepareForm();
			
			TimeController timeController = new TimeController(preparer);
			timeController.Start();
		}
		
		/// <summary>
		/// Checks if update is necessary. If no, does nothing, if yes updates
		/// </summary>
		static void UpdateDBVersion()
		{
			new DBVersionSystem(new DBVersionRepository().AddVersions(typeof(Task).Assembly)).UpdateToNewest();
		}
		
	}
}
