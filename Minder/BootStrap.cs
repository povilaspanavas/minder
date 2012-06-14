
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Core;
using Core.Forms;
using Core.Forms.LoginForm;
using Core.Tools.Log;
using Core.Web;
using EasyRemainder.Forms.Main;
using EasyRemainder.Objects;
using Minder.Sql;

namespace EasyRemainder
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
//			StartEngine();
			Application.Run();
		}
		
		private static void StartEngine()
		{
			
		}
		
		private static void Starter()
		{
			ConfigLoader.LoadConfiguration(false);
			new UpdateVersion();
			Loger loger = new Loger();
			loger.LogWrite(string.Format("Program started \n Program version: {0}",
			                             StaticData.VersionCache.Version), LogerType.Info);
			
			MainFromPreparer preparer = new MainFromPreparer();
			preparer.PrepareForm();
		}
		
	}
}
