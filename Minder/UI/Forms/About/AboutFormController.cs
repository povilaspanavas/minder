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
		
		AboutWpfForm _form = null;
		
		public AboutFormController()
		{
            _form = new AboutWpfForm();
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
			SetEvents();
            //_form.MVersionLabel.Text = string.Format("Version: RC {0}", Core.StaticData.VersionCache.Version);
            //_form.MCoreVersionLabel.Text = string.Format("Core version: {0}", CoreVersionInfo.Version);
			_form.ShowDialog();
		}
		
		public void SetEvents()
		{
            //_form.MLinkLabelSupport.Click += delegate
            //{
            //    System.Diagnostics.Process.Start("http://code.google.com/p/minder/");
            //};
            //ConfigureLogLabel(_form.MLabelLogFile);
		}
		
        //private void ConfigureLogLabel(LinkLabel linkLabel)
        //{
        //    _form.MLabelLogFile.Text = Static.StaticData.Settings.LogFilePath;
        //    _form.toolTip1.SetToolTip(linkLabel, "Click to open log file");
			
        //    string link = Static.StaticData.Settings.LogFilePath;
        //    string executablePath = new PathCutHelper().GetExecutablePath();
        //    link = string.Format(@"{0}\{1}", executablePath, link);
        //    if (File.Exists(link) == false)
        //    {
        //        _log.Error(new ArgumentException(string.Format("File was not found. File Path:\n'{0}'", Path.GetFullPath(link))));
        //        linkLabel.Enabled = false;
        //        _form.toolTip1.SetToolTip(linkLabel, "Log failas nerastas");
        //    }
			
        //    linkLabel.Click+= delegate
        //    {
        //        System.Diagnostics.Process.Start(link);
        //    };
        //}
	}
}
