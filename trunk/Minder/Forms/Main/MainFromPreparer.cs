
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
using Minder.Engine;
using Minder.Forms.About;
using Minder.Forms.Settings;
using Minder.Forms.Main;
using Minder.Forms.Tasks;
using Minder.Sql;

namespace Minder.Forms.Main
{
	/// <summary>
	/// Description of Main_From_Preparer.
	/// </summary>
	public class MainFormPreparer : IFormPreparer
	{
		private MainForm m_form = null;
		HotKeys m_hotKeys = null;
		public event TaskData DataEntered;
		public delegate void TaskData(string dataEntered);
		
		public MainFormPreparer()
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
			
			m_form.MTextBox.LostFocus += delegate { m_form.Visible = false; };
		}
		
		private void BackroundWorks()
		{
			RegisterHotKeys();
			SetContextMenu();
		}
		
		private void RegisterHotKeys()
		{
			m_hotKeys = new HotKeys();
			m_hotKeys.KeyPressed += new EventHandler<KeyPressedEventArgs>(ShowHide);
			
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
			
			m_hotKeys.RegisterHotKey(hotKey, key);
			m_form.MTextBox.KeyDown += KeyPressed;
			m_form.MTextBox.KeyUp += ParseRealTimeAndDisplay;
				
		}
		
		private void ShowHide(object sender, KeyPressedEventArgs e)
		{
			if(m_form.Visible == true)
				m_form.Visible = false;
			else
			{
				m_form.Visible = true;
				m_form.MTextBox.SelectAll();
			}
		}
		
		private void KeyPressed(object sender, KeyEventArgs e)
		{
			// Escape paslepia formą (kažko nepavyko tiesiai ant formos užmest
			if (e.KeyCode.Equals(Keys.Escape))
			{
				m_form.Visible = false;
				m_form.MTextBox.SelectAll();
				return;
			}
			
			if(e.Control == true || e.Shift == true
			   || e.Alt == true || e.KeyCode != Keys.Enter)
			{
				e.Handled = false;
				return;
			}
			if (DataEntered != null)
				DataEntered(this.m_form.MTextBox.Text);
			this.m_form.MTextBox.Text = string.Empty;
			this.m_form.Visible = false;
		}
		
		public void ParseRealTimeAndDisplay(object sender, KeyEventArgs e) {
			// Tikėtina, kad įvesta paprasta raidė
			if(e.Control == false && e.Shift == false
			   || e.Alt == false)
			{
				string leftText; DateTime date;
				string remainderDateString;
				if (TextParser.Parse(m_form.MTextBox.Text, out date, out leftText))
					remainderDateString = string.Format("{0:yyyy.MM.dd HH:mm}", date);
				else
					remainderDateString = "Unavailable";
				m_form.MLabelRemaindDate.Text = remainderDateString;
				return;
			}
		}
		private void SetContextMenu()
		{
			ContextMenu menu = new ContextMenu();
			
			MenuItem menuItemNewTask = new MenuItem("New task", delegate { m_form.Visible = true;}); //TODO
			MenuItem menuItemTasks = new MenuItem("Tasks", OpenTasksForm);
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
		private void OpenTasksForm(object sender, EventArgs e)
		{
			TasksFormPreparer preparer = new TasksFormPreparer();
			preparer.PrepareForm();
		}
		
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
