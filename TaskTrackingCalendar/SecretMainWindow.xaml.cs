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
    /// Interaction logic for SecretMainWindow.xaml
    /// </summary>
    public partial class SecretMainWindow : Window
    {
        public SecretMainWindow()
        {
            InitializeComponent();

            OpenSummaryPage(new TaskList());
            Hide();
        }

        public void OpenSummaryPage(TaskList list)
        {
            var sum = new SummaryPage(list, this);
            sum.Show();
        }

        public void OpenCalendarPage(TaskList list)
        {
            var cal = new CalendarPage(list, this);
            cal.Show();
        }
    }
}
