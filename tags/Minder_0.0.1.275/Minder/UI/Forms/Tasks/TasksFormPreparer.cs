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
using Minder.Engine;
using Minder.Objects;
using Minder.Sql;

namespace Minder.Forms.Tasks
{
	/// <summary>
	/// Description of TasksFormPreparer.
	/// </summary>
	public class TasksFormPreparer : IFormPreparer
	{
		private TasksForm m_form = null;
		private List<Task> m_tasks = null;
		
		public TasksFormPreparer()
		{
			m_form = new TasksForm();
			m_form.Text = "Tasks";
		}
		
		public System.Windows.Forms.Form Form {
			get {
				return m_form;
			}
		}
		
		public void PrepareForm()
		{
			SetEvents();
			LoadTaskGrid();
			m_form.Show();
		}
		
		public void EditTask()
		{
			if(m_form.MTaskGrid.SelectedRows != null &&
			   m_form.MTaskGrid.SelectedRows.Count != 0)
			{
				if(m_form.MTaskGrid.SelectedRows[0].Cells[3].Value == null)
					return;
				int taskId = Convert.ToInt32(m_form.MTaskGrid.SelectedRows[0].Cells[3].Value);
				Task task = new Task(taskId, m_form.MTaskGrid.SelectedRows[0].Cells[0].Value.ToString(),
				                     Convert.ToDateTime(m_form.MTaskGrid.SelectedRows[0].Cells[1].Value),
				                     m_form.MTaskGrid.SelectedRows[0].Cells[4].Value.ToString());
				task.Showed = Convert.ToBoolean(m_form.MTaskGrid.SelectedRows[0].Cells[2].Value);
				
				TaskNewEditFormPreparer preparer = new TaskNewEditFormPreparer(true);
				preparer.Task = task;
				preparer.Form.Closed += delegate { LoadTaskGrid(); };
				preparer.PrepareForm();
			}
		}
		
		public void SetEvents()
		{
			m_form.MNewButton.Click += delegate
			{
				TaskNewEditFormPreparer preparer = new TaskNewEditFormPreparer(false);
				preparer.Form.Closed += delegate { LoadTaskGrid(); };
				preparer.PrepareForm();
			};
			
			m_form.MTaskGrid.DoubleClick += delegate
			{
				EditTask();
			};
			
			m_form.MEditButton.Click += delegate
			{
				EditTask();
			};
			
			m_form.MDeleteButton.Click += delegate
			{
				DeleteSelected();
			};
			
			m_form.MTaskGrid.KeyUp += delegate(object sender, KeyEventArgs e) {
				if (e.Control || e.Alt || e.Shift)
					return;
				if (e.KeyCode.Equals(Keys.Delete))
				{
					DeleteSelected();
					e.Handled = true;
				}
			};
		}

		public void DeleteSelected()
		{
			if (m_form.MTaskGrid.SelectedRows == null || m_form.MTaskGrid.SelectedRows.Count == 0)
				return;
			if (m_form.MTaskGrid.SelectedRows[0].Cells[3].Value == null)
				return;

			string message = "Do you realy want to delete this task?";
			if (m_form.MTaskGrid.SelectedRows.Count > 1)
				message = "Do you realy want to delete these tasks?";

			if (MessageBox.Show(message, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
				for (int i = 0; i < m_form.MTaskGrid.SelectedRows.Count; i++) {
					int taskId = Convert.ToInt32(m_form.MTaskGrid.SelectedRows[i].Cells[3].Value);
					Task task = new Task(taskId, m_form.MTaskGrid.SelectedRows[i].Cells[0].Value.ToString(), Convert.ToDateTime(m_form.MTaskGrid.SelectedRows[0].Cells[1].Value), m_form.MTaskGrid.SelectedRows[i].Cells[4].Value.ToString());
					task.Showed = Convert.ToBoolean(m_form.MTaskGrid.SelectedRows[i].Cells[2].Value);
					task.Delete();
					TimeEngine.FireTaskChangedEvent(task);
				}
				LoadTaskGrid();
			}
		}
		
		private void LoadTaskGrid()
		{
			WaitingForm waitingForm = new WaitingForm("Loading tasks...", "Please wait");
			m_tasks = new DbHelper().LoadAllTasks();
			
			if(m_tasks == null)
				return;
			
			int rowIndex = 0;
			if(m_form.MTaskGrid.CurrentCell != null)
				rowIndex = m_form.MTaskGrid.CurrentCell.RowIndex;
			m_form.MTaskGrid.Rows.Clear();
			
			
			m_tasks = m_tasks
				.OrderBy(m => m.Showed)
				.ThenByDescending(n => n.DateRemainder).ToList();
//			m_tasks.Reverse();
			foreach(Task task in m_tasks)
			{
				m_form.MTaskGrid.Rows.Add(task.Text, task.DateRemainder, task.Showed, task.Id, task.SourceId);
			}
			if(m_form.MTaskGrid.Rows.Count > rowIndex)
				m_form.MTaskGrid.CurrentCell = m_form.MTaskGrid.Rows[rowIndex].Cells[0];
			waitingForm.Close();
		}
	}
}
