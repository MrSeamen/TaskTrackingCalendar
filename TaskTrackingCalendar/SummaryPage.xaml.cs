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
    /// Interaction logic for SummaryPage.xaml
    /// </summary>
    public partial class SummaryPage : Window
    {
        TaskList list;
        SecretMainWindow mw;

        public SummaryPage(TaskList newList, SecretMainWindow parent)
        {
            list = newList;
            mw = parent;
            InitializeComponent();
        }

        private void OnClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mw.Close();
        }

        private void OnCreateClass(object sender, RoutedEventArgs e)
        {

        }

        private void OnEditClass(object sender, RoutedEventArgs e)
        {

        }

        private void OnDeleteClass(object sender, RoutedEventArgs e)
        {

        }

        private void OnCreateTask(object sender, RoutedEventArgs e)
        {

        }

        private void OnEditTask(object sender, RoutedEventArgs e)
        {

        }

        private void OnDeleteTask(object sender, RoutedEventArgs e)
        {

        }

        private void OnCreateReminder(object sender, RoutedEventArgs e)
        {

        }

        private void OnEditReminder(object sender, RoutedEventArgs e)
        {

        }

        private void OnDeleteReminder(object sender, RoutedEventArgs e)
        {

        }

        private void OnOpenCalendar(object sender, RoutedEventArgs e)
        {
            mw.OpenCalendarPage(list);
            Close();
        }
    }
}
