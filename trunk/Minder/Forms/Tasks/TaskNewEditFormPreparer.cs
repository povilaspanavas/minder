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

namespace Minder.Forms.Tasks
{
	/// <summary>
	/// Description of TaskNewEditFormPreparer.
	/// </summary>
	public class TaskNewEditFormPreparer : IFormPreparer
	{
		private TaskNewEditForm m_form = null;
		private bool m_edit = false;
		
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
			m_form.ShowDialog();
		}
		
		public void SetEvents()
		{
			
		}
	}
}
