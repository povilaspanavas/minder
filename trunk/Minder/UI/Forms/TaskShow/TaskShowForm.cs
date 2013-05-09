/*
 * Created by SharpDevelop.
 * User: IGNAS
 * Date: 2012.06.17
 * Time: 18:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using Core.UI.Forms;
using Minder.UI.Forms;

namespace Minder.Forms.TaskShow
{
	/// <summary>
	/// Description of TaskShowForm.
	/// </summary>
	public partial class TaskShowForm : CoreBaseForm
	{
		public TaskShowForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.FormUniqueCode = typeof(TaskShowForm).FullName;
			//
			//
		}
	}
}
