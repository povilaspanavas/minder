/*
 * Created by SharpDevelop.
 * User: IGNAS
 * Date: 2012.06.17
 * Time: 18:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Core.Forms;
using Minder.Objects;
using Minder.Sql;

namespace Minder.Forms.TaskShow
{
	/// <summary>
	/// Description of TaskShowFormPreparer.
	/// </summary>
	public class TaskShowFormPreparer : IFormPreparer
	{
		TaskShowForm m_form = null;
		
		Task m_task;
		
		public Task Task {
			get { return m_task; }
			set { m_task = value; }
		}
		
		public TaskShowFormPreparer(Task task)
		{
			m_form = new TaskShowForm();
			m_form.Text = "Minder Task";
			m_task = task;
		}
		
		public System.Windows.Forms.Form Form 
		{
			get {
				return m_form;
			}
		}
		
		public void PrepareForm()
		{
			SetEvents();
			SetTaskText();
			m_form.ShowDialog();
		}
		
		public void SetEvents()
		{
			m_form.m_okButton.Click += delegate 
			{ 
				m_task.Showed = true;
				m_task.Update();
				m_form.Close();
			};
			
			m_form.m_remainderMeLaterButton.Click += delegate 
			{
//				m_task.Showed = false;
				m_task.DateRemainder.AddMinutes(5); //Temp
				m_task.Update();
				m_form.Close();
			};
		}
		
		private void SetTaskText()
		{
			if(m_task == null)
				return;
			m_form.m_textBox.Text = 
				string.Format("Task: {0}{1}{2}Time: {3}", m_task.Text, Environment.NewLine, Environment.NewLine,  
				              DBTypesConverter.ToFullDateString(m_task.DateRemainder));
		}
	}
}
