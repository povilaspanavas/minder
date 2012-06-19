/*
 * Created by SharpDevelop.
 * User: IGNAS
 * Date: 2012.06.20
 * Time: 00:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Core.Forms;

namespace Minder.Forms.Tasks
{
	/// <summary>
	/// Description of TasksFormPreparer.
	/// </summary>
	public class TasksFormPreparer : IFormPreparer
	{
		private TasksForm m_form = null;
		
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
			m_form.Show();
		}
		
		public void SetEvents()
		{
			
		}
	}
}
