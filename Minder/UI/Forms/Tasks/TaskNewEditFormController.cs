/*
 * Created by SharpDevelop.
 * User: IGNAS
 * Date: 2012.06.20
 * Time: 21:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Core.Forms;
using Minder.Engine;
using Minder.Objects;
using Minder.Static;
using Minder.Forms;
using Minder.UI.Forms;
using System.Windows;
using Minder.UI.Forms.Tasks;

namespace Minder.Forms.Tasks
{
    /// <summary>
    /// Description of TaskNewEditFormPreparer.
    /// </summary>
    public class TaskNewEditFormController : IController
    {
        private TaskNewEditWpfForm _window = null;
        private bool _edit = false;
        private Task _task;

        public Task Task
        {
            get { return _task; }
            set { _task = value; }
        }

        public Visibility Edit
        {
            get
            {
                return _edit ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public TaskNewEditFormController(Task task)
        {
            this._task = task;
            _window = new TaskNewEditWpfForm();
            _window.DataContext = this;
            _edit = _task.Id > 0; // if it was saved to db, we are editing
            _window.Title = _edit ? "Edit task" : "New Task";
        }
        public string DateTimeFormat
        {
            get
            {
                return string.Format("{0} {1}",
                    StaticData.Settings.CultureData.CultureInfo.DateTimeFormat.ShortDatePattern,
                    StaticData.Settings.CultureData.CultureInfo.DateTimeFormat.ShortTimePattern);
            }
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
            //SetEvents();
            //if(m_edit == false)
            //    _window.MShowedCheckBox.Visible = false;
            //else
            //    FillFields();
            _window.ShowDialog();
        }


        //    _window.MSaveButton.Click += delegate
        //    {
        //        Task task = new Task();
        //        task.Text = _window.MTextBox.Text;
        //        task.DateRemainder = _window.MDatePicker.Value;

        //        if(m_edit == false)
        //        {
        //            task.Showed = false;
        //            task.SourceId = string.Format("{0}{1}{2}", DateTime.Now, task.DateRemainder, task.Text);
        //            task.Save();
        //            TimeEngine.FireTaskChangedEvent(task);
        //        }
        //        else
        //        {
        //            task.Showed = _window.MShowedCheckBox.Checked;
        //            task.SourceId = m_task.SourceId;
        //            task.Id = m_task.Id;
        //            task.Update();
        //            TimeEngine.FireTaskChangedEvent(task);
        //        }

        //        _window.Close();
        //    };

        //    _window.MCancelButton.Click += delegate
        //    { _window.Close(); };

    }
}
