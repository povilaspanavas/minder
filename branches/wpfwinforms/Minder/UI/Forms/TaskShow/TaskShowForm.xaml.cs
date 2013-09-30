using Minder.Objects;
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

namespace Minder.UI.Forms.TaskShow
{
    /// <summary>
    /// Interaction logic for TaskShowWpfForm.xaml
    /// </summary>
    public partial class TaskShowForm : BasicWpfForm
    {
        public TaskShowForm()
        {
            InitializeComponent();
            this.Deactivated += delegate
            {
                this.Opacity = 0.5;
            };

            this.Activated += delegate
            {
                this.Opacity = 1.0;
            };
        }
    }
}
