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
        private bool m_edit = false;
        private Task m_task;

        public Task Task
        {
            get { return m_task; }
            set { m_task = value; }
        }

        public TaskNewEditFormController(bool edit, Task task)
            : this(edit)
        {
            this.m_task = task;
        }

        public TaskNewEditFormController(bool edit)
        {
            _window = new TaskNewEditWpfForm();
            _window.DataContext = this;
            m_edit = edit;
            if (m_edit)
                _window.Title = "Edit task";
            else
                _window.Title = "New task";
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

        //private void FillFields()
        //{
        //    if(m_task == null)
        //        return;
        //    _window.MDatePicker.Value = m_task.DateRemainder;
        //    _window.MTextBox.Text = m_task.Text;
        //    _window.MShowedCheckBox.Checked = m_task.Showed;
        //}

        //public void SetEvents()
        //{
        //    _window.MDatePicker.ValueChanged += delegate {
        //        if (_window.MShowedCheckBox.Checked != false)
        //            _window.MShowedCheckBox.Checked = false;
        //    };

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
