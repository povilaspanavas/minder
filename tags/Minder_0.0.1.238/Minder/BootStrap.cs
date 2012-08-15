
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Core;
using Core.Forms;
using Core.Tools.Log;
using Minder.Forms.Settings;
using Minder.Engine;
using Minder.Forms.Main;
using Minder.Objects;
using Minder.Sql;
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
				Starter();
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
		
		private static void Starter()
		{

//			string startupPath = new PathCutHelper()
//				.CutExecutableFileFromPath(System.Reflection.Assembly
//				                           .GetExecutingAssembly().Location);
			
			ConfigLoader.Load();
			
			SettingsLoader loader = new SettingsLoader();
			loader.LoadSettings();
			new StartWithWinController().StartWithWindows();
//				new UpdateVersion();
			if(Minder.Static.StaticData.Settings.CheckUpdates)
				new UpdateProject(StaticData.VersionCache.Version, true, "Minder");
			
			MainFormPreparer preparer = new MainFormPreparer();
			preparer.PrepareForm();
			
			TimeController timeController = new TimeController(preparer);
			timeController.Start();
		}
		
	}
}
