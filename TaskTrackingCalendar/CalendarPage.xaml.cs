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
    /// Interaction logic for CalendarPage.xaml
    /// </summary>
    public partial class CalendarPage : Window
    {
        TaskList list;
        SecretMainWindow mw;

        public CalendarPage(TaskList newList, SecretMainWindow parent)
        {
            list = newList;
            mw = parent;
            InitializeComponent();
        }
        private void OnOpenSummary(object sender, RoutedEventArgs e)
        {
            mw.OpenSummaryPage(list);
            Close();
        }

        private void OnClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mw.Close();
        }
    }
}
