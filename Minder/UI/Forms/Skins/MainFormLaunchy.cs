﻿
using System;
using System.Drawing;
using System.Windows.Forms;
using Minder.UI.Forms;

namespace Minder.Forms.Skins
{

	
	/// <summary>
	/// Description of Main_Form.
	/// </summary>
	public partial class MainFormLaunchy : BasicForm
	{
		private Image m_backGroundImage = null;
		
		public MainFormLaunchy()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			//
			//
			this.SetStyle(ControlStyles.UserPaint, true);
		}	
		
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			e.Graphics.DrawImage(m_backGroundImage, new Point(0,0));
		}
	}
}
