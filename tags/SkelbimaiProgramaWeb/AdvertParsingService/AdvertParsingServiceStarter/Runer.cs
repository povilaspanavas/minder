/*
 * Created by SharpDevelop.
 * User: Ignas T60
 * Date: 2013-09-28
 * Time: 20:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.Threading;

namespace AdvertParsingServiceStarter
{
	/// <summary>
	/// Description of Runer.
	/// </summary>
	public class Runer
	{
		public Runer()
		{
		}
		
		public void Run()
		{
			while(true)
			{
				StartProcess();
				Thread.Sleep(30 * 1000);
			}
		}
		
		private void StartProcess()
		{
			Process[] process = Process.GetProcessesByName("AdvertParsingService");
			if(process.Length == 0)
				Process.Start("AdvertParsingService.exe");
		}
	}
}
