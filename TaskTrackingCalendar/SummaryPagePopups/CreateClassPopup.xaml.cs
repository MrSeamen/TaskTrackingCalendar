using System.Windows;

namespace TaskTrackingCalendar
{
    /// <summary>
    /// Interaction logic for CreateClassPopup.xaml
    /// </summary>
    public partial class CreateClassPopup : Window
    {
        TaskList list;

        public CreateClassPopup(TaskList list)
        {
            this.list = list;
            InitializeComponent();
        }

        private void OnSubmit(object sender, RoutedEventArgs e)
        {
            var name = NameTextBox.Text;
            if (list.CreateClass(name))
            {
                Close();
            }
            else
            {
                ErrorTextBox.Text = "Invalid Class Name ";
            }
        }
    }
}
