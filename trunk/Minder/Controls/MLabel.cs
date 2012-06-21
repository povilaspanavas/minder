
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minder.Controls
{
	public class MLabel : Label
	{
		private string m_imageName = string.Empty;
		
		public MLabel(string imageName) : base()
		{
			m_imageName = imageName;
	//			this.SetStyle(ControlStyles.UserPaint, true);
			this.BackgroundImage = Bitmap.FromFile(m_imageName);
		}
	//		protected override void OnPaint(PaintEventArgs e)
	//		{
	//			base.OnPaint(e);
	//			e.Graphics.DrawImage(, new Point(0, 0));
	//		}
	}
}
