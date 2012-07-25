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

namespace Minder.Forms.Tasks
{
	/// <summary>
	/// Description of TaskNewEditFormPreparer.
	/// </summary>
	public class TaskNewEditFormPreparer : IFormPreparer
	{
		private TaskNewEditForm m_form = null;
		private bool m_edit = false;
		
		Task m_task;
		
		public Task Task {
			get { return m_task; }
			set { m_task = value; }
		}
		
		public TaskNewEditFormPreparer(bool edit)
		{
			m_form = new TaskNewEditForm();
			m_edit = edit;
			if(m_edit)
				m_form.Text = "Edit task";
			else
				m_form.Text = "New task";
		}
		
		public System.Windows.Forms.Form Form {
			get {
				return m_form;
			}
		}
		
		public void PrepareForm()
		{
			SetEvents();
			if(m_edit == false)
				m_form.MShowedCheckBox.Visible = false;
			else
				FillFields();
			m_form.ShowDialog();
		}
		
		private void FillFields()
		{
			if(m_task == null)
				return;
			m_form.MDatePicker.Value = m_task.DateRemainder;
			m_form.MTextBox.Text = m_task.Text;
			m_form.MShowedCheckBox.Checked = m_task.Showed;
		}
		
		public void SetEvents()
		{
			m_form.MSaveButton.Click += delegate
			{
				Task task = new Task();
				task.Text = m_form.MTextBox.Text;
				task.DateRemainder = m_form.MDatePicker.Value;
				
				if(m_edit == false)
				{
					task.Showed = false;
					task.SourceId = string.Format("{0}{1}{2}", DateTime.Now, task.DateRemainder, task.Text);
					task.Save();
					TimeEngine.FireTaskChangedEvent(task);
				}
				else
				{
					task.Showed = m_form.MShowedCheckBox.Checked;
					task.SourceId = m_task.SourceId;
					task.Id = m_task.Id;
					task.Update();
					TimeEngine.FireTaskChangedEvent(task);
				}
				
				m_form.Close();
			};
			
			m_form.MCancelButton.Click += delegate 
			{ m_form.Close(); };
		}
	}
}
