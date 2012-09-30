/*
 * Created by SharpDevelop.
 * User: IGNAS
 * Date: 2012.06.20
 * Time: 00:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using Core.UI.Forms;
using Minder.UI.Forms;

namespace Minder.Forms.Tasks
{
	/// <summary>
	/// Description of TasksForm.
	/// </summary>
	public partial class TasksForm : CoreBaseForm
	{
		public TasksForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.FormUniqueCode = typeof(TasksForm).FullName;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
	}
}
