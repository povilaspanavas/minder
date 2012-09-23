/*
 * Created by SharpDevelop.
 * User: Ignas
 * Date: 2012.08.26
 * Time: 10:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Core;
using Core.Forms;
using Core.Tools.Log;

namespace Minder.Starter
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
				Start(args);
				Kill();
				Application.Run();
			}
			catch(Exception e)
			{
				try
				{
//					ConfigLoader.Load();
//					Loger log = new Loger();
//					log.LogWrite(e.ToString(), LogerType.Fatal);
					Kill();
				}
				
				catch (Exception a)
				{
					new ErrorBox(a.ToString()+e.ToString(), "Error");
					Kill();
				}
			}
		}
		
		private static void Kill()
		{
			Process[] proc = Process.GetProcessesByName("Minder.Starter");
			if(proc.Length > 0)
			{
				foreach(Process proces in proc)
				{
					proces.Kill();
				}
			}
		}
		
		private static void Start(string[] args)
		{
			if(args == null || args.Length == 0)
				return;
			bool openForm = false;
			string path = string.Empty;
			
			for(int i=0; i<args.Length; i++)
			{
				if(args[i].ToLower().Equals(Commands.SLEEP))
					Thread.Sleep(Convert.ToInt32(args[i+1]) * 1000);
			}
			
			for(int i=0; i<args.Length; i++)
			{
				if(args[i].ToLower().Equals(Commands.OPEN_FORM))
					openForm = true;
			}
			
			for(int i=0; i<args.Length; i++)
			{
				if(args[i].ToLower().Equals(Commands.RUN))
					path = args[i+1];
			}
			
			//Start
			string argument = string.Empty;
			if(openForm)
				argument = "--openform";
			
			ProcessStartInfo info = new ProcessStartInfo(path, argument);
			Process.Start(info);
			Kill();
		}
		
	}
}
