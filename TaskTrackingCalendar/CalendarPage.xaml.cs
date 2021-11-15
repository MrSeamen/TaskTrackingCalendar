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
        List<int> monthList = new List<int>();
        int currentMonth;
        String currentMonthName;
        

        public CalendarPage(TaskList newList, SecretMainWindow parent)
        {
            list = newList;
            mw = parent;
            InitializeComponent();
        }

        public String monthName(int month)
        {
            String monthName = "";
            switch(month)
            {
                case 1: monthName = "January";
                    break;
                case 2: monthName = "February";
                    break;
                case 3: monthName = "March";
                    break;
                case 4: monthName = "April";
                    break;
                case 5: monthName = "May";
                    break;
                case 6: monthName = "June";
                    break;
                case 7: monthName = "July";
                    break;
                case 8: monthName = "August";
                    break;
                case 9: monthName = "September";
                    break;
                case 10: monthName = "October";
                    break;
                case 11: monthName = "November";
                    break;
                case 12: monthName = "December";
                    break;

            }
            return monthName;
        }

        private void OnOpenSummary(object sender, RoutedEventArgs e)
        {
            mw.OpenSummaryPage(list);
            Close();
        }

        private void forwardMonth(object sender, RoutedEventArgs e)
        {
            if (currentMonth == 12)
            {
                currentMonth = 1;
            } else
            {
                currentMonth++;
            }
            currentMonthName = monthName(currentMonth);
            //update calendar display
        }

        private void backwardMonth(object sender, RoutedEventArgs e)
        {
            if (currentMonth == 1)
            {
                currentMonth = 12;                
            }
            else
            {
                currentMonth--;
            }
            currentMonthName = monthName(currentMonth);
            //update calendar display
        }

        private void OnClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mw.Close();
        }
    }
}
