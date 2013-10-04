using Minder.Objects;
using System;
using System.Collections;
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

namespace Minder.UI.Forms.Tasks
{
    /// <summary>
    /// Interaction logic for TasksWpfForm.xaml
    /// </summary>
    public partial class TasksWpfForm : BaseWpfForm
    {
        private List<Task> _selectedTasks = new List<Task>();

        public TasksWpfForm()
        {
            InitializeComponent();
            this.DataGrid.SelectionChanged += DataGrid_SelectionChanged;
        }

        void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Task item in e.RemovedItems)
                _selectedTasks.Remove(item);
            foreach (Task item in e.AddedItems)
                _selectedTasks.Add(item);
        }

        public List<Task> SelectedTasks
        {
            get { return _selectedTasks; }
            set { throw new Exception("This property is read-only. To bind to it you must use 'Mode=OneWayToSource'."); }
        }
    }
}
