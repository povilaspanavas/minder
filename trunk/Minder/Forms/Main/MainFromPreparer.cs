
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
using Minder.Forms.About;
using Minder.Forms.Settings;
using Minder.Forms.Main;

namespace Minder.Forms.Main
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
			m_form.m_trayIcon.DoubleClick += delegate
			{
				m_form.Visible = true;
			};
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
			
			bool alt = Minder.Static.StaticData.Settings.NewTaskHotkey.Alt;
			bool shift = Minder.Static.StaticData.Settings.NewTaskHotkey.Shift;
			bool ctrl = Minder.Static.StaticData.Settings.NewTaskHotkey.Ctrl;
			bool win = Minder.Static.StaticData.Settings.NewTaskHotkey.Win;
			string keyString = Minder.Static.StaticData.Settings.NewTaskHotkey.Key;
			Keys key = Keys.Decimal;
			Minder.Static.StaticData.KeysDic.TryGetValue(keyString, out key);
			
			// Nesu 100% tikras, kad gerai veikia - bet standartinis atvejis veikia
			// o kodas daug aiškesnis ir lengviau taisomas
			ModifierKeys hotKey = new ModifierKeys();
			if (alt)
				hotKey = hotKey | ModifierKeys.Alt;
			if (shift)
				hotKey = hotKey | ModifierKeys.Shift;
			if (ctrl)
				hotKey = hotKey | ModifierKeys.Control;
			if (win)
				hotKey = hotKey | ModifierKeys.Win;
			
			hotKeys.RegisterHotKey(hotKey, key);
			m_form.m_textBox.KeyDown += KeyPressedEnter;
			
//			if(alt == true && shift == false && ctrl == false && win == false)
//				hotKeys.RegisterHotKey(ModifierKeys.Alt, key);
//			if(alt == false && shift == true && ctrl == false && win == false)
//				hotKeys.RegisterHotKey(ModifierKeys.Shift, key);
//			if(alt == false && shift == false && ctrl == true && win == false)
//				hotKeys.RegisterHotKey(ModifierKeys.Control, key);
//			if(alt == false && shift == false && ctrl == false && win == true)
//				hotKeys.RegisterHotKey(ModifierKeys.Win, key);
//
//			if(alt == true && shift == true && ctrl == false && win == false)
//				hotKeys.RegisterHotKey(ModifierKeys.Alt | ModifierKeys.Shift, key);
//			if(alt == true && shift == false && ctrl == true && win == false)
//				hotKeys.RegisterHotKey(ModifierKeys.Alt | ModifierKeys.Control, key);
//			if(alt == true && shift == false && ctrl == false && win == true)
//				hotKeys.RegisterHotKey(ModifierKeys.Alt	| ModifierKeys.Win, key);
//
//			if(alt == false && shift == true && ctrl == true && win == false)
//				hotKeys.RegisterHotKey(ModifierKeys.Shift | ModifierKeys.Control, key);
//			if(alt == false && shift == true && ctrl == false && win == true)
//				hotKeys.RegisterHotKey(ModifierKeys.Shift | ModifierKeys.Win, key);
//			if(alt == false && shift == false && ctrl == true && win == true)
//				hotKeys.RegisterHotKey(ModifierKeys.Control | ModifierKeys.Win, key);
//
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
			// Escape paslepia formą (kažko nepavyko tiesiai ant formos užmest
//			if (e.KeyCode.Equals(Keys.Escape))
//			{
//				m_form.Visible = false;
//				m_form.TextBox.Text = string.Empty;
//				return;
//			}
			
			if(e.Control == true || e.Shift == true
			   || e.Alt == true || e.KeyCode != Keys.Enter)
				return;
			if (DataEntered != null)
				DataEntered(this.m_form.TextBox.Text);
			this.m_form.TextBox.Clear();
			this.m_form.Visible = false;
		}
		
		private void SetContextMenu()
		{
			ContextMenu menu = new ContextMenu();
			
			MenuItem menuItemNewTask = new MenuItem("New task", delegate { m_form.Visible = true;}); //TODO
			MenuItem menuItemTasks = new MenuItem("Tasks"); //TODO
			MenuItem menuItemSettings = new MenuItem("Settings", OpenSettingsForm);
			MenuItem menuItemAbout = new MenuItem("About", OpenAboutForm);
			MenuItem menuSeparator = new MenuItem("-");
			MenuItem menuSeparator2 = new MenuItem("-");
			MenuItem menuExit = new MenuItem("Exit", ExitApplication);
			
			menu.MenuItems.Add(menuItemNewTask);
			menu.MenuItems.Add(menuSeparator);
			menu.MenuItems.Add(menuItemTasks);
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
