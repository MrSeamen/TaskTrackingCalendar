using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TaskTrackingCalendar
{
    /// <summary>
    /// Interaction logic for EditTaskPopup.xaml
    /// </summary>
    public partial class EditTaskPopup : Window
    {
        TaskList list;

        public EditTaskPopup(TaskList list)
        {
            this.list = list;
            InitializeComponent();

            foreach (var c in list.GetSummaryClasses())
            {
                ClassComboBox.Items.Add(c);
            }
            ClassComboBox.SelectedIndex = 0;
        }

        private void ClassComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TaskComboBox.Items.Clear();

            var tasks = new List<Task>();
            if (!(ClassComboBox.SelectedItem == null))
            {
                string name = (string)ClassComboBox.SelectedItem;
                tasks = list.GetSummaryTasks(true, name);
            }

            foreach (var t in tasks)
            {
                TaskComboBox.Items.Add(t.GetName());
            }
            TaskComboBox.SelectedIndex = 0;
        }

        private void TaskComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ClassComboBox.SelectedItem != null && TaskComboBox.SelectedItem != null)
            {
                var className = (string)ClassComboBox.SelectedItem;
                var taskName = (string)TaskComboBox.SelectedItem;

                var tasks = list.GetSummaryTasks(true, className);
                var task = tasks[0];
                foreach (var t in tasks)
                {
                    if (t.GetName() == taskName)
                    {
                        task = t;
                    }
                }

                NewTaskName.Text = task.GetName();
                PriorityComboBox.SelectedIndex = task.GetPriority() - 1;
                DatePicker.SelectedDate = task.GetDate();
            }
        }

        private void OnSubmit(object sender, RoutedEventArgs e)
        {
            if (ClassComboBox.SelectedItem == null || TaskComboBox.SelectedItem == null || PriorityComboBox.SelectedItem == null || DatePicker.SelectedDate == null)
            {
                ErrorTextBox.Text = "Invalid data ";
            }
            var className = (string)ClassComboBox.SelectedItem;
            var taskName = (string)TaskComboBox.SelectedItem;
            var newName = NewTaskName.Text;
            var priority = PriorityComboBox.SelectedIndex + 1;
            var newDate = (DateTime)DatePicker.SelectedDate;
            if (list.UpdateTask(className, taskName, newName, priority, newDate))
            {
                Close();
            } else
            {
                ErrorTextBox.Text = "Invalid data ";
            }
        }
    }
}
