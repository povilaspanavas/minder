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
using System.Windows.Forms;
using Core.Forms;
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
		
		public void SetEvents()
		{
			m_form.MNewButton.Click += delegate
			{
				TaskNewEditFormPreparer preparer = new TaskNewEditFormPreparer(false);
				preparer.Form.Closed += delegate { LoadTaskGrid(); };
				preparer.PrepareForm();
			};
			
			m_form.MEditButton.Click += delegate
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
			};
			
			m_form.MDeleteButton.Click += delegate
			{
				if(m_form.MTaskGrid.SelectedRows == null ||
				   m_form.MTaskGrid.SelectedRows.Count == 0)
					return;
				if(m_form.MTaskGrid.SelectedRows[0].Cells[3].Value == null)
						return;
				if(MessageBox.Show("Do you realy want delete this task?", "Question",
				                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
				   DialogResult.Yes)
				{
					int taskId = Convert.ToInt32(m_form.MTaskGrid.SelectedRows[0].Cells[3].Value);
					Task task = new Task(taskId, m_form.MTaskGrid.SelectedRows[0].Cells[0].Value.ToString(),
					                     Convert.ToDateTime(m_form.MTaskGrid.SelectedRows[0].Cells[1].Value),
					                     m_form.MTaskGrid.SelectedRows[0].Cells[4].Value.ToString());
					task.Showed = Convert.ToBoolean(m_form.MTaskGrid.SelectedRows[0].Cells[2].Value);
					task.Delete();
					LoadTaskGrid();
				}
			};
		}
		
		private void LoadTaskGrid()
		{
			m_form.MTaskGrid.Rows.Clear();
			using (DBConnection connection = new DBConnection())
			{
				m_tasks = connection.LoadAllTasks();
			}
			
			if(m_tasks == null)
				return;
			
			foreach(Task task in m_tasks)
			{
				m_form.MTaskGrid.Rows.Add(task.Text, task.DateRemainder, task.Showed, task.Id, task.SourceId);
			}
		}
	}
}
