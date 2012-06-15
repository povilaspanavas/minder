
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Core;
using Core.Forms;
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
		
		private static void StartEngine()
		{
			
		}
		
		private static void Starter()
		{
			try
			{
				ConfigLoader.LoadConfiguration(false);
				new UpdateVersion();
				MainFromPreparer preparer = new MainFromPreparer();
				preparer.PrepareForm();
			}
			catch (Exception e)
			{
				new ErrorBox(e.ToString()); //This show error box and write to log.
			}
			
		}
		
	}
}
