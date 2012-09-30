/*
 * Created by SharpDevelop.
 * User: IGNAS
 * Date: 2012.06.14
 * Time: 22:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using Core.UI.Forms;
using Minder.UI.Forms;

namespace Minder.Forms.About
{
	/// <summary>
	/// Description of AboutForm.
	/// </summary>
	public partial class AboutForm : CoreBaseForm
	{
		public AboutForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.FormUniqueCode = typeof(AboutForm).FullName;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
	}
}
