using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using Core.Forms;
using Minder.Forms.Skins.Skin1;
using Minder.Tools;

namespace Minder.Forms.Skins
{
	class WpfSkinPreparer : IFormPreparer
	{
		//IWpfSkin m_form = null;
		WpfSkin1 m_form = null;

		public WpfSkinPreparer()
		{
			m_form = new WpfSkin1();
		}

		public System.Windows.Forms.Form Form
		{
			get { throw new NotImplementedException(); }
		}
		
		public WpfSkin1 WpfForm
		{
			get { return m_form; }
		}

		public void PrepareForm()
		{
			System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop(m_form);
			m_form.ShowInTaskbar = false;
			m_form.Topmost = true;
			m_form.MTextBox.Focus();
			
			string startupPath = new PathCutHelper()
					.CutExecutableFileFromPath(System.Reflection.Assembly
					                           .GetExecutingAssembly().Location) + @"\minderico.ico";
			
			m_form.MImage.Source = new BitmapImage(new Uri(startupPath));
		}

		public void SetEvents()
		{
			
		}
	}
}
