
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Core;
using Core.Forms;
using Core.Tools.GlobalHotKeys;
using Core.Tools.ImportExport;
using Core.Tools.Log;
using EasyRemainder.Forms.About;
using EasyRemainder.Forms.Settings;
using Minder.Forms.Main;

namespace EasyRemainder.Forms.Main
{
	/// <summary>
	/// Description of Main_From_Preparer.
	/// </summary>
	public class MainFromPreparer : IFormPreparer
	{
		private MainForm m_form = null;
		public event TaskData DataEntered;
		public delegate void TaskData(string dataEntered);
		
		public MainFromPreparer()
		{
			m_form = new MainForm();
		}

		public void PrepareForm()
		{
			BackroundWorks();
			SetEvents();
		}

		public void SetEvents()
		{
			
		}
		
		private void BackroundWorks()
		{
			RegisterHotKeys();
			SetContextMenu();
		}
		
		private void RegisterHotKeys()
		{
			HotKeys hotKeys = new HotKeys();
			hotKeys.KeyPressed += new EventHandler<KeyPressedEventArgs>(KeyPressed);
			hotKeys.RegisterHotKey(ModifierKeys.Alt, Keys.N);
			m_form.m_textBox.KeyDown += KeyPressedEnter;
		}
		
		private void KeyPressed(object sender, KeyPressedEventArgs e)
		{
			if(m_form.Visible == true)
				m_form.Visible = false;
			else
				m_form.Visible = true;
		}
		
		private void KeyPressedEnter(object sender, KeyEventArgs e)
		{
			if(e.Control == false || e.KeyCode != Keys.Enter)
				return;
			if (DataEntered != null)
				DataEntered(this.m_form.TextBox.Text);
			m_form.Visible = false;
		}
		
		private void SetContextMenu()
		{
			ContextMenu menu = new ContextMenu();
			
			MenuItem menuItemNewTask = new MenuItem("New task"); //TODO
			MenuItem menuItemSettings = new MenuItem("Settings", OpenSettingsForm);
			MenuItem menuItemAbout = new MenuItem("About", OpenAboutForm);
			MenuItem menuSeparator = new MenuItem("-");
			MenuItem menuSeparator2 = new MenuItem("-");
			MenuItem menuExit = new MenuItem("Exit", ExitApplication);
			
			menu.MenuItems.Add(menuItemNewTask);
			menu.MenuItems.Add(menuSeparator);
			menu.MenuItems.Add(menuItemSettings);
			menu.MenuItems.Add(menuItemAbout);
			menu.MenuItems.Add(menuSeparator2);
			menu.MenuItems.Add(menuExit);
			m_form.m_trayIcon.ContextMenu = menu;
		}
		
		#region ContextMenuEvents
		private void OpenSettingsForm(object sender, EventArgs e)
		{
			SettingsFormPreparer preparer = new SettingsFormPreparer();
			preparer.PrepareForm();
		}
		
		private void OpenAboutForm(object sender, EventArgs e)
		{
			AboutFormPreparer preparer = new AboutFormPreparer();
			preparer.PrepareForm();
		}
		
		private void ExitApplication(object sender, EventArgs e)
		{
			Application.Exit();
		}
		#endregion
		
		public Form Form {
			get { return m_form;}
		}
	}
}
