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
using System.Windows.Forms;
using Core.Forms;
using Core.UI.Grid;
using Minder.Engine;
using Minder.Objects;
using Minder.Sql;
using Minder.UI.Forms;
using Minder.UI.Forms.Tasks;
using System.Windows;

namespace Minder.Forms.Tasks
{
	/// <summary>
	/// Description of TasksWpfFormPreparer.
	/// </summary>
	public class TasksFormController : IController
	{
		private TasksWpfForm _form = null;
        private List<Task> _tasks = null;

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
		
		public Window Window {
			get {
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
            //if(_form.MTaskGrid.SelectedRows != null &&
            //   _form.MTaskGrid.SelectedRows.Count != 0)
            //{
            //    if(_form.MTaskGrid.SelectedRows[0].Cells[0].Value == null)
            //        return;
            //    int taskId = Convert.ToInt32(_form.MTaskGrid.SelectedRows[0].Cells[0].Value);
            //    Task task = new Task(taskId, _form.MTaskGrid.SelectedRows[0].Cells[2].Value.ToString(), Convert.ToDateTime(_form.MTaskGrid.SelectedRows[0].Cells[3].Value), _form.MTaskGrid.SelectedRows[0].Cells[1].Value.ToString());
            //    task.Showed = Convert.ToBoolean(_form.MTaskGrid.SelectedRows[0].Cells[4].Value);
				
            //    TaskNewEditFormController preparer = new TaskNewEditFormController(task);
            //    preparer.Window.Closed += delegate { RefreshTaskGrid(); };
            //    preparer.PrepareWindow();
            //}
		}
		
		public void SetEvents()
		{
            //_form.MNewButton.Click += delegate
            //{
            //    TaskNewEditFormController preparer = new TaskNewEditFormController(new Task());
            //    preparer.Window.Closed += delegate { RefreshTaskGrid(); };
            //    preparer.PrepareWindow();
            //};
			
            //_form.MTaskGrid.DoubleClick += delegate
            //{
            //    EditTask();
            //};
			
            //_form.MEditButton.Click += delegate
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

		public void DeleteSelected()
		{
            //if (_form.MTaskGrid.SelectedRows == null || _form.MTaskGrid.SelectedRows.Count == 0)
            //    return;
            //if (_form.MTaskGrid.SelectedRows[0].Cells[0].Value == null)
            //    return;

            //string message = "Do you realy want to delete this task?";
            //if (_form.MTaskGrid.SelectedRows.Count > 1)
            //    message = "Do you realy want to delete these tasks?";

            //if (MessageBox.Show(message, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
            //    for (int i = 0; i < _form.MTaskGrid.SelectedRows.Count; i++) {
            //        int taskId = Convert.ToInt32(_form.MTaskGrid.SelectedRows[i].Cells[0].Value);
            //        Task task = new Task(taskId, _form.MTaskGrid.SelectedRows[i].Cells[2].Value.ToString(), Convert.ToDateTime(_form.MTaskGrid.SelectedRows[i].Cells[3].Value), _form.MTaskGrid.SelectedRows[i].Cells[1].Value.ToString());
            //        task.Showed = Convert.ToBoolean(_form.MTaskGrid.SelectedRows[i].Cells[4].Value);
            //        task.Delete();
            //        TimeEngine.FireTaskChangedEvent(task);
            //    }
            //    RefreshTaskGrid();
            //}
		}
		
		private void LoadTaskGrid()
		{
//            using(new WaitingForm2("Loading tasks...", "Please wait", false))
//            {
//                _tasks = new DbHelper().LoadAllTasks();
				
//                if(_tasks == null)
//                    return;
				
//                int rowIndex = 0;
//                if(_form.MTaskGrid.CurrentCell != null)
//                    rowIndex = _form.MTaskGrid.CurrentCell.RowIndex;
				
////				m_form.MTaskGrid.Rows.Clear();
				
				
//                _tasks = _tasks
//                    .OrderBy(m => m.Showed)
//                    .ThenByDescending(n => n.DateRemainder).ToList();
////			m_tasks.Reverse();
////				foreach(Task task in m_tasks)
////				{
////					m_form.MTaskGrid.Rows.Add(task.Text, task.DateRemainder, task.Showed, task.Id, task.SourceId);
////				}
				
//                CoreGridController<Task>.AddToGrid(_form.MTaskGrid, _tasks);
				
//                if(_form.MTaskGrid.Rows.Count > rowIndex)
//                    _form.MTaskGrid.CurrentCell = _form.MTaskGrid.Rows[rowIndex].Cells[2];
//            }
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
