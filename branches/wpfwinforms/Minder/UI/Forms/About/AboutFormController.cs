using System;
using System.IO;
using Core.CoreInfo;
using Core.Forms;
using Core.Tools;
using Minder.Static;
using Minder.UI.Forms;
using Minder.UI.Forms.About;
using System.Windows;
using System.Windows.Navigation;

namespace Minder.Forms.About
{
	/// <summary>
	/// Description of AboutFormPreparer.
	/// </summary>
	public class AboutFormController : IController
	{
		log4net.ILog _log = log4net.LogManager.GetLogger(typeof(AboutFormController));
		
		AboutForm _form = null;
		
		public AboutFormController()
		{
            _form = new AboutForm();
			_form.Title = "About";
		}

        public void Blynas(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.AbsoluteUri);
            e.Handled = true;
        }

        public Window Window
        {
			get {
				return _form;
			}
		}
		
		public void PrepareWindow()
		{
			_form.ShowDialog();
		}
	}
}
