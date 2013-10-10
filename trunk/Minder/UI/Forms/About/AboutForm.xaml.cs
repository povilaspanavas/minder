using Core.CoreInfo;
using Core.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Minder.UI.Forms.About
{
    /// <summary>
    /// Interaction logic for AboutWpfForm.xaml
    /// </summary>
    public partial class AboutForm : BaseWpfForm
    {
        public AboutForm()
        {
            InitializeComponent();

            this.LabelProgramVersion.Content = string.Format("Version: Alpha WPF {0}", Core.StaticData.VersionCache.Version);
            this.LabelCoreVersion.Content = string.Format("Core version: {0}", CoreVersionInfo.Version);
            this.LabelLogLink.ToolTip = "Click to open log file";

        }

        private void LogLink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            string link = Static.StaticData.Settings.LogFilePath; 
            string executablePath = new PathCutHelper().GetExecutablePath();
            link = string.Format(@"{0}\{1}", executablePath, link);
            if (System.IO.File.Exists(link) == false)
                this.LabelLogLink.IsEnabled = false;
            else
                System.Diagnostics.Process.Start(link);
        }

        private void SupportLink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.AbsoluteUri);
            e.Handled = true;
        }
    }
}
