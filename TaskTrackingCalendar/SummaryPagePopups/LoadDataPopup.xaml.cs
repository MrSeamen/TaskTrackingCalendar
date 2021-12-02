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
    /// Interaction logic for LoadDataPopup.xaml
    /// </summary>
    public partial class LoadDataPopup : Window
    {
        TaskList list;

        public LoadDataPopup(TaskList list)
        {
            this.list = list;
            InitializeComponent();
        }

        private void OnSubmit(object sender, RoutedEventArgs e)
        {
            var filePath = FilePathTextBox.Text;
            if (list.LoadData(filePath))
            {
                Close();
            } else
            {
                ErrorTextBox.Text = "Invalid path ";
            }
        }

        private void OnSubmitNoPath(object sender, RoutedEventArgs e)
        {
            if (list.LoadData())
            {
                Close();
            }
            else
            {
                ErrorTextBox.Text = "Invalid path ";
            }
        }
    }
}
