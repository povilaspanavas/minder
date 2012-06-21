
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minder.Forms.Skins
{

	
	/// <summary>
	/// Description of Main_Form.
	/// </summary>
	public partial class MainFormLaunchy : Form
	{
		public MainFormLaunchy()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			this.SetStyle(ControlStyles.UserPaint, true);
		}	
		
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			e.Graphics.DrawImage(Bitmap.FromFile("LaunchyClone.png"), new Point(0,0));
		}
	}
}
