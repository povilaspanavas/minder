/*
 * Created by SharpDevelop.
 * User: Povilas
 * Date: 2012.08.08
 * Time: 20:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace Minder.UI.Forms.Skins
{
	/// <summary>
	/// Description of ISkin.
	/// </summary>
	public interface IWindowsFormSkin
	{
//		event EventHandler Deactivate;
//		NotifyIcon TrayIcon {get;}
		TextBox MTextBox {get;}
		void Hide();
		void Show();
	}
}
