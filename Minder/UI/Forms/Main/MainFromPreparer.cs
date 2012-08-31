
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
using Core.Tools.Log;
using Minder.Engine;
using Minder.Engine.Parse;
using Minder.Forms.About;
using Minder.Forms.Main;
using Minder.Forms.Settings;
using Minder.Forms.Skins;
using Minder.Forms.Tasks;
using Minder.Sql;
using Minder.UI.SkinController;
using Minder.UI.SkinController.MainForms.DefaultSkin;

namespace Minder.Forms.Main
{
	/// <summary>
	/// Description of Main_From_Preparer.
	/// </summary>
	public class MainFormPreparer : IFormPreparer
	{
		private MainFormLaunchy m_form = null; //Reikalinga dėl TrayIcon'o
		private HotKeys m_hotKeys = null;
		public event TaskData DataEntered;
		public delegate void TaskData(string dataEntered);
//		private WpfSkinPreparer m_wpfPreparer = null;
		private IMainForm m_mainForm = null;
		
		public MainFormPreparer()
		{
			m_form = new MainFormLaunchy();
			m_mainForm = new MainFormCollector().GetForm();
		}

		public void PrepareForm()
		{
			BackroundWorks();
			SetEvents();
			m_form.InitializeLifetimeService();
			m_mainForm.ShowHide(); //Form init
			m_mainForm.ShowHide();
		}
		
		public void PrepareForm(bool showForm)
		{
			PrepareForm();
			if(showForm)
				m_mainForm.ShowHide();
		}

		public void SetEvents()
		{
			m_form.TrayIcon.DoubleClick += delegate
			{
				m_mainForm.ShowHide();
			};
			
			m_mainForm.MTextBox.TextChanged += ParseRealTimeAndDisplay;
			m_mainForm.MWindow.Deactivated += delegate { m_mainForm.MWindow.Hide(); };
		}
		
		private void BackroundWorks()
		{
			RegisterHotKeys();
			SetContextMenu();
		}
		
		private void RegisterHotKeys()
		{
			m_hotKeys = new HotKeys();
			m_hotKeys.KeyPressed += new EventHandler<KeyPressedEventArgs>(m_mainForm.ShowHide);
			
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
			m_mainForm.MTextBox.KeyDown += KeyPressed;
		}
		
		private void KeyPressed(object sender, System.Windows.Input.KeyEventArgs e)
		{
			if (e.Key == Key.Escape)
			{
				m_mainForm.MTextBox.SelectAll();
				m_mainForm.ShowHide();
				return;
			}
			
			if(e.Key == Key.Enter)
			{
				if (DataEntered != null)
				{
					DataEntered(m_mainForm.MTextBox.Text);
					this.m_mainForm.MTextBox.Text = string.Empty;
				}
				m_mainForm.ShowHide();
			}
		}
		
		public void ParseRealTimeAndDisplay(object sender, EventArgs e)
		{
			string leftText; DateTime date;
			string remainderDateString;
			if (TextParser.Parse(m_mainForm.MTextBox.Text, out date, out leftText))
				remainderDateString = DBTypesConverter.ToFullDateStringByCultureInfo(date);
			else
				remainderDateString = "Unavailable";
			m_mainForm.MDateLabel.Content = remainderDateString;
			return;
		}
		
		private void SetContextMenu()
		{
			ContextMenu menu = new ContextMenu();
			
			MenuItem menuItemNewTask = new MenuItem("New task", delegate { m_mainForm.ShowHide();}); //TODO
			MenuItem menuItemSettings = new MenuItem("Settings", OpenSettingsForm);
			MenuItem menuItemTasks = new MenuItem("Tasks", OpenTasksForm);
			MenuItem menuItemAbout = new MenuItem("About", OpenAboutForm);
			MenuItem menuSeparator = new MenuItem("-");
			MenuItem menuSeparator2 = new MenuItem("-");
			MenuItem menuExit = new MenuItem("Exit", ExitApplication);
			
			menu.MenuItems.Add(menuItemNewTask);
			menu.MenuItems.Add(menuSeparator);
			menu.MenuItems.Add(menuItemSettings);
			menu.MenuItems.Add(menuItemTasks);
			menu.MenuItems.Add(menuItemAbout);
			menu.MenuItems.Add(menuSeparator2);
			menu.MenuItems.Add(menuExit);
			m_form.TrayIcon.ContextMenu = menu;
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
