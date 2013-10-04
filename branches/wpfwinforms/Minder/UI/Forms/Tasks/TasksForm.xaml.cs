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
    public partial class TasksForm : BaseWpfForm
    {
        private List<Task> _selectedTasks = new List<Task>();

        public List<Task> SelectedTasks
        {
            get { return _selectedTasks; }
        }

        public TasksForm()
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
        
        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender == null)
                return;
            DataGrid dataGrid = sender as DataGrid;
            if (dataGrid != null && dataGrid.SelectedItems.Count >= 0)
            {
                EditTaskEvent();
            }
            e.Handled = true;

        }

        public delegate void DataGridMouseDoubleClick();
        public event DataGridMouseDoubleClick EditTaskEvent;

        public void OnEditTaskEvent()
        {
            if (EditTaskEvent != null)
                EditTaskEvent();
        }
    }
}
