
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Core;
using Core.Forms;
using EasyRemainder.Forms.Settings;
using Minder.Engine;
using Minder.Forms.Main;
using Minder.Objects;
using Minder.Sql;

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
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Starter();
			Application.Run();
		}
		
		private static void Starter()
		{
			try
			{
				ConfigLoader.LoadConfiguration(false);
				SettingsLoader loader = new SettingsLoader();
				loader.LoadSettings();
				new UpdateVersion();
				
				MainFromPreparer preparer = new MainFromPreparer();
				preparer.PrepareForm();
				
				TimeController timeController = new TimeController(preparer);
				timeController.Start();
			}
			catch (Exception e)
			{
				new ErrorBox(e.ToString()); // This shows error box and writes to log.
			}
			
		}
		
	}
}
