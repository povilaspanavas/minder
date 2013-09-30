﻿
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using Core.Forms;
using Minder.Forms.Tasks;
using Minder.Objects;
using Minder.Sql;
using Minder.Static;
using Minder.Tools;
using Minder.UI.Forms.TaskShow;
using System.Windows;
using Minder.UI.Forms;
using System.Windows.Input;

namespace Minder.Forms.TaskShow
{
    public interface IController
    {
        Window Window { get; }

        void PrepareWindow();
        void SetEvents();
    }

    /// <summary>
    /// Description of TaskShowFormPreparer.
    /// </summary>
    public class TaskShowController : IController
    {
        private TaskShowForm _window = null;
        private Task m_task;
        private List<RemindLaterValue> m_listRemindLaterValues = null;
        private RemindLaterValue m_remindLaterValueSelectedItem = null;

        public List<RemindLaterValue> RemindLaterValues
        {
            get { return m_listRemindLaterValues; }
        }

        public RemindLaterValue RemindLaterValueSelectedItem
        {
            get
            {
                if (m_remindLaterValueSelectedItem == null)
                    m_remindLaterValueSelectedItem = GetRemindMeLaterDefaultValue();
                return m_remindLaterValueSelectedItem;
            }
            set { m_remindLaterValueSelectedItem = value; }
        }

        /// <summary>
        /// Select default value
        /// </summary>
        /// <param name="comboBox"></param>
        public RemindLaterValue GetRemindMeLaterDefaultValue()
        {
            foreach (var remindMeLaterValue in m_listRemindLaterValues)
            {
                if (StaticData.Settings.RemindMeLaterDefaultValue.Equals(remindMeLaterValue.Value))
                    return remindMeLaterValue;
            }
            return null;
        }

        public Task Task
        {
            get { return m_task; }
            set { m_task = value; }
        }

        public TaskShowController(Task task)
        {
            _window = new TaskShowForm();
            _window.Title = "Minder Task";
            _window.DataContext = this;
            m_task = task;
            m_listRemindLaterValues = BuildRemindLaterList();
        }

        public List<RemindLaterValue> BuildRemindLaterList()
        {
            List<RemindLaterValue> listRemindLaterValues = new List<RemindLaterValue>();
            listRemindLaterValues.Add(new RemindLaterValue("5 minutes", 5.0m / 60));
            listRemindLaterValues.Add(new RemindLaterValue("10 minutes", 10.0m / 60));
            listRemindLaterValues.Add(new RemindLaterValue("15 minutes", 15.0m / 60));
            listRemindLaterValues.Add(new RemindLaterValue("30 minutes", 30.0m / 60));
            listRemindLaterValues.Add(new RemindLaterValue("1 hour", 1m));
            listRemindLaterValues.Add(new RemindLaterValue("2 hours", 2m));
            listRemindLaterValues.Add(new RemindLaterValue("4 hours", 4m));
            listRemindLaterValues.Add(new RemindLaterValue("8 hours", 8m));
            listRemindLaterValues.Add(new RemindLaterValue("1 day", 24m));
            listRemindLaterValues.Add(new RemindLaterValue("2 days", 24 * 2m));
            listRemindLaterValues.Add(new RemindLaterValue("1 week", 24 * 7m));
            return listRemindLaterValues;
        }


        public Window Window
        {
            get
            {
                return _window;
            }
        }

        public void PrepareWindow()
        {
            SetEvents();
            SetTaskText();
            if (StaticData.Settings.PlaySound)
                PlaySound();
            _window.ShowDialog();
        }

        private void PlaySound()
        {
            string soundPath = new PathCutHelper()
                .CutExecutableFileFromPath(System.Reflection.Assembly
                                           .GetExecutingAssembly().Location);
            soundPath += @"\" + StaticData.SOUND_FILE_PATH;
            SoundPlayer simpleSound = new SoundPlayer(soundPath);
            simpleSound.Play();
        }

        public ICommand CloseTaskCommand
        {
            get { return new DelegateCommand(new Action(CloseButtonPressed)); }
        }

        private void CloseButtonPressed()
        {
            m_task.Showed = true;
            CloseOrOkButton();
        }

        public ICommand RemindMeLaterCommand
        {
            get { return new DelegateCommand(new Action(RemindMeLaterPressed)); }
        }

        private void RemindMeLaterPressed()
        {
            m_task.Showed = false;
            decimal val = StaticData.Settings.RemindMeLaterDefaultValue;
            if (m_remindLaterValueSelectedItem != null)
                val = m_remindLaterValueSelectedItem.Value;
            m_task.DateRemainder = m_task.DateRemainder = DateTime.Now.AddHours((double)val); //Temp
            CloseOrOkButton();
        }

        public void SetEvents()
        {


            //_window.ButtonEditTask.Click += delegate {
            //    // Doesn't work closing, probably because we are in the event of the form we are closing
            //    this._window.Hide();
            //    new TaskNewEditFormPreparer(true, m_task).PrepareForm();
            //    this._window.Close();
            //};


            //_window.Deactivate += delegate { 
            //    _window.Opacity = 0.5;
            //};
            //_window.Activated += delegate {
            //    _window.Opacity = 1.0;
            //};
        }

        private void CloseOrOkButton()
        {
            m_task.Update();
            _window.Close();
        }

        private void SetTaskText()
        {
            //if(m_task == null)
            //    return;
            //_window.TextBox.Text =
            //    string.Format("Task: {0}{1}{2}Time: {3}", m_task.Text, Environment.NewLine, Environment.NewLine,
            //                  DBTypesConverter.ToFullDateStringByCultureInfo(m_task.DateRemainder));
        }
    }
}
