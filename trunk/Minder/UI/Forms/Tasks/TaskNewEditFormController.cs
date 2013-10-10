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
using System.Windows.Input;

namespace Minder.Forms.Tasks
{
    /// <summary>
    /// Description of TaskNewEditFormPreparer.
    /// </summary>
    public class TaskNewEditFormController : IController
    {
        private TaskNewEditForm _window = null;
        private bool _changesMade = false;
        private bool _edit = false;
        private Task _task;

        public bool ChangesMade
        {
            get { return _changesMade; }
        }

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
            _window = new TaskNewEditForm();
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

        public ICommand CloseCommand
        {
            get
            {
                return new DelegateCommand(() => _window.Close());
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return new DelegateCommand(SavePressed);
            }
        }
        
        public void SavePressed()
        {
            if (_edit == false) // new task
            {
                _task.SourceId = string.Format("{0}{1}{2}", DateTime.Now, _task.DateRemainder, _task.Text);
                _task.Save();
            }
            else
                _task.Update();

            TimeEngine.FireTaskChangedEvent(_task);
            _changesMade = true;
            _window.Close();
        }

        public void PrepareWindow()
        {
            _changesMade = false;
            _window.ShowDialog();
        }
    }
}
