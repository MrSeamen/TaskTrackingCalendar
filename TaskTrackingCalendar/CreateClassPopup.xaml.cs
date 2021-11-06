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
