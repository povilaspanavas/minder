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
	public abstract class AbstractMainForm : Window
	{
		public abstract TextBox MTextBox {get;}
		public abstract Label MDateLabel {get;}
		public Window MWindow {get { return this;} }
		
		public AbstractMainForm()
		{
            System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop(this);
		}
		
		public void ShowHide(object sender, KeyPressedEventArgs e)
		{
			ShowHide();
		}
		
		public void ShowHide()
		{
			if(MWindow.IsVisible)
			{
				MWindow.Hide();
				MTextBox.SelectAll();
			}
			else
			{
				MWindow.Show();
				MTextBox.SelectAll();
				MTextBox.Focus();
				MWindow.Activate();
			}
		}
	}
}
