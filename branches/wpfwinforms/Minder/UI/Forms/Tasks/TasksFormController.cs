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

namespace Minder.Forms.Tasks
{
    /// <summary>
    /// Description of TasksWpfFormPreparer.
    /// </summary>
    public class TasksFormController : IController
    {
        private TasksWpfForm _form = null;
        private List<Task> _tasks = null;
        private List<Task> _selectedTasks = null;

        public List<Task> SelectedTasks
        {
            get { return _selectedTasks; }
            set { _selectedTasks = value; }
        }

        public List<Task> Tasks
        {
            get { return _tasks; }
            set { _tasks = value; }
        }



        public TasksFormController()
        {
            _form = new TasksWpfForm();
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
            LoadTaskGrid();
            _form.Show();
        }

        /// <summary>
        /// The task changedEvent will be fired by taskshowform
        /// </summary>
        public void EditTask()
        {
            if (_selectedTasks.Count == 0)
                return;
            TaskNewEditFormController preparer = new TaskNewEditFormController(_selectedTasks[0]);
            preparer.Window.Closed += delegate { RefreshTaskGrid(); };
            preparer.PrepareWindow();
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
            preparer.Window.Closed += delegate { RefreshTaskGrid(); };
            preparer.PrepareWindow();
        }

        public void SetEvents()
        {


            //_form.MTaskGrid.DoubleClick += delegate
            //{
            //    EditTask();
            //};


            //_form.MDeleteButton.Click += delegate
            //{
            //    DeleteSelected();
            //};

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
                for (int i = 0; i < SelectedTasks.Count; i++)
                {
                    Task task = SelectedTasks[i];
                    task.Delete();
                    TimeEngine.FireTaskChangedEvent(task);
                }
            }
            RefreshTaskGrid();
        }

        private void LoadTaskGrid()
        {
            using (new WaitingForm2("Loading tasks...", "Please wait", false))
            {
                List<Task> _tasksTemp = new DbHelper().LoadAllTasks();

                if (_tasksTemp == null)
                    return;

                //                int rowIndex = 0;
                //                if(_form.MTaskGrid.CurrentCell != null)
                //                    rowIndex = _form.MTaskGrid.CurrentCell.RowIndex;

                ////				m_form.MTaskGrid.Rows.Clear();


                _tasks = _tasksTemp
                    .OrderBy(m => m.Showed)
                    .ThenByDescending(n => n.DateRemainder).ToList();
                ////			m_tasks.Reverse();
                ////				foreach(Task task in m_tasks)
                ////				{
                ////					m_form.MTaskGrid.Rows.Add(task.Text, task.DateRemainder, task.Showed, task.Id, task.SourceId);
                ////				}

                //                CoreGridController<Task>.AddToGrid(_form.MTaskGrid, _tasks);

                //                if(_form.MTaskGrid.Rows.Count > rowIndex)
                //                    _form.MTaskGrid.CurrentCell = _form.MTaskGrid.Rows[rowIndex].Cells[2];
            }
        }

        private void RefreshTaskGrid()
        {
            ////			using(new WaitingForm2("Loading tasks...", "Please wait", false))
            ////			{
            //            _tasks = new DbHelper().LoadAllTasks();

            //            if(_tasks == null)
            //                return;

            //            int rowIndex = 0;
            //            if(_form.MTaskGrid.CurrentCell != null)
            //                rowIndex = _form.MTaskGrid.CurrentCell.RowIndex;

            ////				m_form.MTaskGrid.Rows.Clear();


            //            _tasks = _tasks
            //                .OrderBy(m => m.Showed)
            //                .ThenByDescending(n => n.DateRemainder).ToList();
            ////			m_tasks.Reverse();
            ////				foreach(Task task in m_tasks)
            ////				{
            ////					m_form.MTaskGrid.Rows.Add(task.Text, task.DateRemainder, task.Showed, task.Id, task.SourceId);
            ////				}

            //            CoreGridController<Task>.AddValues(_form.MTaskGrid, _tasks);

            //            if(_form.MTaskGrid.Rows.Count > rowIndex)
            //                _form.MTaskGrid.CurrentCell = _form.MTaskGrid.Rows[rowIndex].Cells[2];
        }
    }
}
