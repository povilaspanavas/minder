
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;

using Core;
using Core.Forms;
using Core.Tools.GlobalHotKeys;
using Core.Tools.ImportExport;
using Core.Tools.Log;
using Minder.Engine;
using Minder.Forms.About;
using Minder.Forms.Main;
using Minder.Forms.Settings;
using Minder.Forms.Skins;
using Minder.Forms.Tasks;
using Minder.Sql;

namespace Minder.Forms.Main
{
	/// <summary>
	/// Description of Main_From_Preparer.
	/// </summary>
	public class MainFormPreparer : IFormPreparer
	{
		private MainFormLaunchy m_form = null;
		private HotKeys m_hotKeys = null;
		public event TaskData DataEntered;
		public delegate void TaskData(string dataEntered);
		private WpfSkinPreparer m_wpfPreparer = null;
		
		public MainFormPreparer()
		{
			m_form = new MainFormLaunchy();
			m_wpfPreparer = new WpfSkinPreparer();
		}

		public void PrepareForm()
		{
			BackroundWorks();
			SetEvents();
			m_wpfPreparer.PrepareForm();
		}

		public void SetEvents()
		{
			m_form.m_trayIcon.DoubleClick += delegate
			{
				m_wpfPreparer.WpfForm.Show();
			};
			
			m_form.Deactivate += delegate { m_form.Visible = false; };
//			m_form.MTextBox.TextChanged += ParseRealTimeAndDisplay;
			m_wpfPreparer.WpfForm.MTextBox.TextChanged += ParseRealTimeAndDisplay;
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
			Core.Tools.GlobalHotKeys.ModifierKeys hotKey = new Core.Tools.GlobalHotKeys.ModifierKeys();
			if (alt)
				hotKey = hotKey | Core.Tools.GlobalHotKeys.ModifierKeys.Alt;
			if (shift)
				hotKey = hotKey | Core.Tools.GlobalHotKeys.ModifierKeys.Shift;
			if (ctrl)
				hotKey = hotKey | Core.Tools.GlobalHotKeys.ModifierKeys.Control;
			if (win)
				hotKey = hotKey | Core.Tools.GlobalHotKeys.ModifierKeys.Win;
			
			m_hotKeys.RegisterHotKey(hotKey, key);
//			m_form.MTextBox.KeyDown += KeyPressed;
			m_wpfPreparer.WpfForm.MTextBox.KeyDown += KeyPressed;
		}
		
		private void ShowHide(object sender, KeyPressedEventArgs e)
		{
			if(m_wpfPreparer.WpfForm.IsVisible)
			{
				m_wpfPreparer.WpfForm.Hide();
				m_wpfPreparer.WpfForm.MTextBox.SelectAll();
			}
			else
			{
				m_wpfPreparer.WpfForm.MTextBox.SelectAll();
				m_wpfPreparer.WpfForm.MTextBox.Focus();
				m_wpfPreparer.WpfForm.Show();
			}
		}
		
		private void KeyPressed(object sender, System.Windows.Input.KeyEventArgs e)
		{
			if (e.Key == Key.Escape)
			{
				m_wpfPreparer.WpfForm.MTextBox.SelectAll();
				m_wpfPreparer.WpfForm.Hide();
				return;
			}
			
			if(e.Key == Key.Enter)
			{
				if (DataEntered != null)
				{
					DataEntered(this.m_wpfPreparer.WpfForm.MTextBox.Text);
					this.m_wpfPreparer.WpfForm.MTextBox.Text = string.Empty;
				}
				this.m_wpfPreparer.WpfForm.Hide();
			}
		}
		
		public void ParseRealTimeAndDisplay(object sender, EventArgs e)
		{
			string leftText; DateTime date;
			string remainderDateString;
			if (TextParser.Parse(m_wpfPreparer.WpfForm.MTextBox.Text, out date, out leftText))
				remainderDateString = string.Format("{0:yyyy.MM.dd HH:mm}", date);
			else
				remainderDateString = "Unavailable";
			m_wpfPreparer.WpfForm.MDateLabel.Content = remainderDateString;
			return;
		}
		
		private void SetContextMenu()
		{
			ContextMenu menu = new ContextMenu();
			
			MenuItem menuItemNewTask = new MenuItem("New task", delegate { m_wpfPreparer.WpfForm.Show();}); //TODO
			MenuItem menuItemTasks = new MenuItem("Tasks", OpenTasksForm);
			MenuItem menuItemSettings = new MenuItem("Settings", OpenSettingsForm);
			MenuItem menuItemAbout = new MenuItem("About", OpenAboutForm);
			MenuItem menuSeparator = new MenuItem("-");
			MenuItem menuSeparator2 = new MenuItem("-");
			MenuItem menuExit = new MenuItem("Exit", ExitApplication);
//			MenuItem tempMeniu = new MenuItem("WpfForm", ExitApplication);
			
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
			//new Main2FormPreparer().PrepareForm();
			Application.Exit();
		}
		#endregion
		
		public Form Form {
			get { return m_form;}
		}
	}
}
