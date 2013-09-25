/*
 * Created by SharpDevelop.
 * User: IGNAS
 * Date: 2012.06.16
 * Time: 16:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Core.Tools.Shortcut;
using Minder.Static;
using vbAccelerator.Components.Shell;

namespace Minder.Tools
{
	/// <summary>
	///
	/// </summary>
	public class StartWithWinController
	{
		
		public void StartWithWindows()
		{
			OnAutoStart();
		}
		
		private void OnAutoStart()
		{
			string keyName = "Minder";
			string assemblyLocation = Assembly.GetExecutingAssembly().Location;  // Or the EXE path.

			if(StaticData.Settings.StartWithWindows)
			{
				if (StarterWithWin.IsAutoStartEnabled(keyName, assemblyLocation))
					return;
				StarterWithWin.SetAutoStart(keyName, assemblyLocation);
			}
			else
			{
				if (StarterWithWin.IsAutoStartEnabled(keyName, assemblyLocation))
					StarterWithWin.UnSetAutoStart(keyName);
			}
		}
		
		
	}
}
