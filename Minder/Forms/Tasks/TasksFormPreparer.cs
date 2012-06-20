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
				m_form.MTaskGrid.Rows.Add(task.Text, task.DateRemainder, task.Showed);
			}
		}
	}
}
