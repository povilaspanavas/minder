﻿
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;
using Core;
using Core.DB;
using Core.Forms;
using Core.Tools.GlobalHotKeys;
using Core.Tools.Log;
using Minder.Engine;
using Minder.Engine.Helpers;
using Minder.Engine.Parse;
using Minder.Engine.Sync;
using Minder.Forms.About;
using Minder.Forms.Main;
using Minder.Forms.Settings;
using Minder.Forms.Skins;
using Minder.Forms.Tasks;
using Minder.Objects;
using Minder.Sql;
using Minder.UI.SkinController;

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
        public delegate void TaskData(string dataEntered, AbstractMainForm mainForm);
        //		private WpfSkinPreparer m_wpfPreparer = null;
        private AbstractMainForm m_mainForm = null;
        private SyncController m_syncController = null;

        public MainFormPreparer()
        {
            m_form = new MainFormLaunchy();
            m_mainForm = new MainFormCollector().GetForm();
            m_syncController = new SyncController();
        }

        public void PrepareForm()
        {
            SetEvents();
            BackroundWorks();

            if (Minder.Static.StaticData.Settings.Sync.Enable)
            {
                m_syncController.Sync();
                m_syncController.StartThreadForSync(); //Sync
            }

            m_form.InitializeLifetimeService();
            m_mainForm.MWindow.BeginInit();
            m_mainForm.ShowHide(); //Form init
            m_mainForm.ShowHide();
        }

        public void PrepareForm(bool showForm)
        {
            PrepareForm();
            if (showForm)
                m_mainForm.ShowHide();
        }

        public void SetEvents()
        {
            m_form.TrayIcon.DoubleClick += delegate
            {
                m_mainForm.ShowHide();
            };

            Application.ApplicationExit += delegate
            {
                if (Minder.Static.StaticData.Settings.Sync.Enable)
                {
                    //					using(new WaitingForm2("Syncing tasks...", "Minder. Please wait", false))
                    //					{
                    m_syncController.Sync();
                    Info infoSync = InfoFinder.FindByUniqueCode(Minder.Static.StaticData.InfoUniqueCodes.InfoLastSyncDate);
                    infoSync.Value1 = Minder.Static.StaticData.Settings.Sync.LastSyncDate.ToString();
                    GenericDbHelper.UpdateAndFlush(infoSync);


                    //					}
                }
            };

            m_syncController.Synced += delegate
            {
                //				m_form.TrayIcon.BalloonTipIcon = ToolTipIcon.Info;
                //				m_form.TrayIcon.BalloonTipTitle = "Minder synced!";
                //				m_form.TrayIcon.BalloonTipText = String.Format("Added {0} new task(s)!", m_syncController.NewTasks);
                //				m_form.TrayIcon.ShowBalloonTip(5);
                m_syncController.NewTasks = 0;
            };

            m_form.TrayIcon.BalloonTipClicked += delegate
            {
                new TasksFormController().PrepareWindow();
            };

            m_form.TrayIcon.MouseMove += delegate
            {
                m_form.TrayIcon.Text = FormatNextTaskRemindingDate();
            };
            m_mainForm.MTextBox.TextChanged += ParseRealTimeAndDisplay;
            m_mainForm.MWindow.Deactivated += delegate { m_mainForm.MWindow.Hide(); };
        }

        public string FormatNextTaskRemindingDate()
        {
            int maxTimeTextLength = 38; // Text length without task description
            int maxLength = 64; // for NotifyIcon.Text property it's maximum
            int maxTaskNameLength = maxLength - maxTimeTextLength;
            string text = "Nothing to be mindered about";
            Task nextTask = new DbHelper().NextTaskToShow();
            if (nextTask == null)
                return text;
            if (string.IsNullOrEmpty(nextTask.Text) == false
                && nextTask.Text.Length > maxTaskNameLength)
                nextTask.Text = nextTask.Text.Substring(0, maxTaskNameLength);
            DateTime? nextDate = nextTask.DateRemainder;
            if (nextDate.HasValue == false)
                return text;

            text = string.Format("Task {0} minders at {1}", nextTask.Text, DBTypesConverter.ToFullDateStringByCultureInfo(nextDate.Value));
            TimeSpan difference = nextDate.Value.Subtract(DateTime.Now);

            decimal days = RoundHelper.Round((decimal)difference.TotalDays, 0);
            if (days < 1)
                text = string.Format("Task {0} minders at {1}", nextTask.Text, nextDate.Value.ToShortTimeString());

            decimal minutes = RoundHelper.Round((decimal)difference.TotalMinutes, 0);
            if (difference.TotalHours < 1)
                text = string.Format("Task {0} minders in {1} minutes", nextTask.Text, minutes);
            if (minutes < 1)
                text = (string.Format("Task {0} minders in less than a minute", nextTask.Text));
            return text;
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
            Minder.Static.StaticData.Settings.NewTaskHotkey.KeysDic.TryGetValue(keyString, out key);

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

            if (e.Key == Key.Enter)
            {
                if (DataEntered != null)
                    DataEntered(m_mainForm.MTextBox.Text, m_mainForm);
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

            MenuItem menuItemNewTask = new MenuItem("New task", delegate { m_mainForm.ShowHide(); }); //TODO
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
            TasksFormController preparer = new TasksFormController();
            preparer.PrepareWindow();
        }

        private void OpenSettingsForm(object sender, EventArgs e)
        {
            SettingsFormController preparer = new SettingsFormController();
            preparer.PrepareWindow();
        }

        private void OpenAboutForm(object sender, EventArgs e)
        {
            AboutFormController preparer = new AboutFormController();
            preparer.PrepareWindow();
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        public Form Form
        {
            get { return m_form; }
        }
    }
}
