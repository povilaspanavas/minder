
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
                if (StaticData.Settings.RemindMeLaterDecimalValue.Equals(remindMeLaterValue.Value))
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

        public static List<RemindLaterValue> BuildRemindLaterList()
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

        public ICommand EditTaskCommand
        {
            get
            {
                return new DelegateCommand(EditTask);
            }
        }

        public void EditTask()
        {
            var preparer = new TaskNewEditFormController(this.Task);
            preparer.PrepareWindow();
            _window.Close();
        }

        private void RemindMeLaterPressed()
        {
            m_task.Showed = false;
            decimal val = StaticData.Settings.RemindMeLaterDecimalValue;
            if (m_remindLaterValueSelectedItem != null)
                val = m_remindLaterValueSelectedItem.Value;
            m_task.DateRemainder = m_task.DateRemainder = DateTime.Now.AddHours((double)val); //Temp
            CloseOrOkButton();
        }

        private void CloseOrOkButton()
        {
            m_task.Update();
            _window.Close();
        }

        public string FullText
        {
            get
            {
                if (m_task == null)
                    return string.Empty;

                return string.Format("Task: {0}{1}{2}Time: {3}", m_task.Text, Environment.NewLine, Environment.NewLine,
                                  DBTypesConverter.ToFullDateStringByCultureInfo(m_task.DateRemainder));
            }
        }
    }
}
