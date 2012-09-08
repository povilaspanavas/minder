/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2012.08.15
 * Time: 12:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows;
using System.Windows.Controls;

using Core.Tools.GlobalHotKeys;

namespace Minder.UI.SkinController
{
	/// <summary>
	/// Description of IForm.
	/// </summary>
	public interface IMainForm
	{
		void ShowHide();
		void ShowHide(object sender, KeyPressedEventArgs e);
		TextBox MTextBox {get;}
		Label MDateLabel {get;}
		Window MWindow {get;}
	}
}
