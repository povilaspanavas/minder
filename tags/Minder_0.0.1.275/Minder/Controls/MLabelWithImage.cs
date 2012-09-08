
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minder.Controls
{
	public class MLabelWithImage : Label
	{
		public MLabelWithImage(Image imageName) : base()
		{
			this.BackgroundImage = imageName;
		}
	}
}
