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
    /// Interaction logic for CreateTaskPopup.xaml
    /// </summary>
    public partial class CreateTaskPopup : Window
    {
        TaskList list;

        public CreateTaskPopup(TaskList list)
        {
            this.list = list;

            InitializeComponent();

            DatePicker.SelectedDate = DateTime.Today;
            foreach (var c in list.GetSummaryClasses())
            {
                ClassComboBox.Items.Add(c);
            }
            ClassComboBox.SelectedIndex = 0;
        }

        private void OnSubmit(object sender, RoutedEventArgs e)
        {
            if (ClassComboBox.SelectedItem == null || PriorityComboBox.SelectedItem == null || DatePicker.SelectedDate == null)
            {
                ErrorTextBox.Text = "Invalid data ";
            }
            var className = (string)ClassComboBox.SelectedItem;
            var taskName = TaskNameTextBox.Text;
            var priority = PriorityComboBox.SelectedIndex + 1;
            var date = (DateTime)DatePicker.SelectedDate;
            if (list.CreateTask(className, taskName, priority, date))
            {
                Close();
            } else
            {
                ErrorTextBox.Text = "Invalid data ";
            }
        }
    }
}
