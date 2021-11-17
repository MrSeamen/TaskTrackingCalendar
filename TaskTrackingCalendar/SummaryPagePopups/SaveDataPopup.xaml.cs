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
    /// Interaction logic for SaveDataPopup.xaml
    /// </summary>
    public partial class SaveDataPopup : Window
    {
        TaskList list;

        public SaveDataPopup(TaskList list)
        {
            this.list = list;
            InitializeComponent();
        }

        private void OnBrowse(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog();

            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;
                FilePathTextBox.Text = filename;
            }
        }

        private void OnSubmit(object sender, RoutedEventArgs e)
        {
            var filePath = FilePathTextBox.Text;
            if (list.SaveData(filePath))
            {
                Close();
            }
            else
            {
                ErrorTextBox.Text = "Invalid path ";
            }
        }

        private void OnSubmitNoPath(object sender, RoutedEventArgs e)
        {
            if (list.SaveData())
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
