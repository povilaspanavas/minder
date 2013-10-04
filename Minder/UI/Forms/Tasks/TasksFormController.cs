/*
 * Created by SharpDevelop.
 * User: IGNAS
 * Date: 2012.06.20
 * Time: 00:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Core.Forms;
using Core.UI.Grid;
using Minder.Engine;
using Minder.Objects;
using Minder.Sql;
using Minder.UI.Forms;
using Minder.UI.Forms.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace Minder.Forms.Tasks
{
    /// <summary>
    /// Description of TasksWpfFormPreparer.
    /// </summary>
    public class TasksFormController : IController
    {
        private TasksForm _form = null;
        private ObservableCollection<Task> _tasks = null;

        public List<Task> SelectedTasks
        {
            get { 
                return _form.SelectedTasks;
            }
        }

        public ObservableCollection<Task> Tasks
        {
            get {

                if (_tasks == null)
                    LoadTasks();
                return _tasks;
            }
            set { _tasks = value; }
        }



        public TasksFormController()
        {
            _form = new TasksForm();
            _form.Title = "Tasks";
            _form.DataContext = this;
        }

        public Window Window
        {
            get
            {
                return _form;
            }
        }

        public void PrepareWindow()
        {
            SetEvents();
            _form.Show();

        }

        public void EditTask()
        {
            if (SelectedTasks.Count == 0)
                return;
            TaskNewEditFormController preparer = new TaskNewEditFormController(SelectedTasks[0]);
            //preparer.Window.Closed += delegate { LoadTasks(); };
            preparer.PrepareWindow();
        }
        
        public ICommand ReloadFromDbCommand
        {
            get
            {
                return new DelegateCommand(LoadTasks);
            }
        }

        public ICommand EditTaskCommand
        {
            get
            {
                return new DelegateCommand(EditTask);
            }
        }


        public ICommand NewTaskCommand
        {
            get
            {
                return new DelegateCommand(NewTask);
            }
        }

        public ICommand DeleteTaskCommand
        {
            get
            {
                return new DelegateCommand(DeleteSelectedTask);
            }
        }

        public void NewTask()
        {
            TaskNewEditFormController preparer = new TaskNewEditFormController(new Task());
            preparer.PrepareWindow();
            if (preparer.ChangesMade)
                _tasks.Add(preparer.Task);
        }

        public void SetEvents()
        {
            _form.EditTaskEvent += EditTask;

            //_form.MTaskGrid.KeyUp += delegate(object sender, KeyEventArgs e) {
            //    if (e.Control || e.Alt || e.Shift)
            //        return;
            //    if (e.KeyCode.Equals(Keys.Delete))
            //    {
            //        DeleteSelected();
            //        e.Handled = true;
            //    }
            //};
        }

        public void DeleteSelectedTask()
        {
            string message = "Do you realy want to delete this task?";
            if (this.SelectedTasks.Count > 1)
                message = "Do you realy want to delete these tasks?";

            if (MessageBox.Show(message, "Question",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                // we can't use SelectedTasks, because we are changing selected items by 
                // removing them from observable collection
                List<Task> currentSelection = new List<Task>(SelectedTasks);
                for (int i = 0; i < currentSelection.Count; i++)
                {
                    Task task = currentSelection[i];
                    task.Delete();
                    _tasks.Remove(task); // I think it should be slow
                    TimeEngine.FireTaskChangedEvent(task);
                }
                
            }
            //LoadTasks();
        }

        private void LoadTasks()
        {
            using (new WaitingForm2("Loading tasks...", "Please wait", false))
            {
                List<Task> _tasksTemp = new DbHelper().LoadAllTasks();

                if (_tasksTemp == null)
                    return;

                _tasks = new ObservableCollection<Task>(_tasksTemp
                    .OrderBy(m => m.Showed)
                    .ThenByDescending(n => n.DateRemainder).ToList());
            }
        }
    }
}
