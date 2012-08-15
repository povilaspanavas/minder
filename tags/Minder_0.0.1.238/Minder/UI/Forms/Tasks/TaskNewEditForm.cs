/*
 * Created by SharpDevelop.
 * User: IGNAS
 * Date: 2012.06.20
 * Time: 21:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minder.Forms.Tasks
{
	/// <summary>
	/// Description of TaskNewEditForm.
	/// </summary>
	public partial class TaskNewEditForm : Form
	{
		public TaskNewEditForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			this.MDatePicker.ValueChanged += delegate {
				if (this.MShowedCheckBox.Checked != false)
					this.MShowedCheckBox.Checked = false;
			};
		}
	}
}
