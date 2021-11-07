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

namespace TaskTrackingCalendar.SummaryPagePopups
{
    /// <summary>
    /// Interaction logic for CreateReminderPopup.xaml
    /// </summary>
    public partial class CreateReminderPopup : Window
    {
        TaskList list;
        public CreateReminderPopup(TaskList list)
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

        private void OnSubmit(object sender, RoutedEventArgs e)
        {
            if (ClassComboBox.SelectedItem == null || TaskComboBox.SelectedItem == null  || DatePicker.SelectedDate == null)
            {
                ErrorTextBox.Text = "Invalid data ";
            }

            var className = (string)ClassComboBox.SelectedItem;
            var taskName = (string)TaskComboBox.SelectedItem;
            var date = (DateTime)DatePicker.SelectedDate;
            if (list.CreateReminder(className, taskName, date))
            {
                Close();
            }
            else
            {
                ErrorTextBox.Text = "Invalid data ";
            }
        }
    }
}
