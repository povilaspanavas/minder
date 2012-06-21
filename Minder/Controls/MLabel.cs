
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minder.Controls
{
	public class MLabel : Label
	{
		private Image m_imageName = null;
		
		public MLabel(Image imageName) : base()
		{
			m_imageName = imageName;
			//			this.SetStyle(ControlStyles.UserPaint, true);
			this.BackgroundImage = imageName;
		}
		//		protected override void OnPaint(PaintEventArgs e)
		//		{
		//			base.OnPaint(e);
		//			e.Graphics.DrawImage(, new Point(0, 0));
		//		}
	}
}
