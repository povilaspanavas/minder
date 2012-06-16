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
using System.Windows.Forms;

using vbAccelerator.Components.Shell;

namespace Minder.Tools
{
	/// <summary>
	///
	/// </summary>
	public class StartWithWinController
	{
		private string m_shortcutPath = string.Empty;
		
		public void StartWithWindows(bool value)
		{
			
		}
		
		private void CreateShortcut()
		{
			using (ShellLink shortcut = new ShellLink())
			{
				shortcut.Target = Application.ExecutablePath;
				shortcut.WorkingDirectory = Path.GetDirectoryName(Application.ExecutablePath);
				shortcut.Description = "My Shorcut Name Here";
				shortcut.DisplayMode = ShellLink.LinkDisplayMode.edmNormal;
				shortcut.Save(m_shortcutPath);
			}
		}
	}
}
