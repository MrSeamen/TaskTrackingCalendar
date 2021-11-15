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
        int currentYear; //can be changed
        int currentMonth; //can be changed
        int currentDay; //cannot be changed
        int maxDays;
        int startDayofWeek;
        String currentMonthName;
        List<Task>[] monthTaskList = new List<Task>[31];
        DateTime now;
        

        public CalendarPage(TaskList newList, SecretMainWindow parent)
        {
            list = newList;
            mw = parent;
            now = DateTime.Now;
            currentYear = now.Year;
            currentMonth = now.Month;
            currentDay = now.Day;
            currentMonthName = monthName(currentMonth);
            maxDays = DateTime.DaysInMonth(currentMonth, currentYear);
            startDayofWeek = firstDayOfMonth(currentMonth, currentYear);
            updateTaskList(list);
            InitializeComponent();
        }

        private int firstDayOfMonth(int month, int year)
        {
            return (int)new DateTime(year, month, 1, 0, 0, 0).DayOfWeek;
        }

        private void updateTaskList(TaskList taskList)
        {
            //clear monthTaskList
            for (int i = 0; i < monthTaskList.Length; i++)
            {
                monthTaskList[i].Clear();
            }
            //get tasks for this month
            foreach (Task task in taskList.GetSummaryTasks())
            {
                if (task.GetDate().Month == currentMonth)
                {
                    monthTaskList[task.GetDate().Day].Add(task);
                }
            }
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
            //update current year, current month, monthTaskLists, startDay, and maxDays
            if (currentMonth == 12)
            {
                currentMonth = 1;
                currentYear++;
            } else
            {
                currentMonth++;
            }
            
            currentMonthName = monthName(currentMonth);
            maxDays = DateTime.DaysInMonth(currentMonth, currentYear);
            startDayofWeek = firstDayOfMonth(currentMonth, currentYear);
            updateTaskList(list);
            //update calendar display
        }

        private void backwardMonth(object sender, RoutedEventArgs e)
        {
            //update current year, current month, monthTaskLists, startDay, and maxDays
            if (currentMonth == 1)
            {
                currentMonth = 12;
                currentYear--;
            }
            else
            {
                currentMonth--;
            }

            currentMonthName = monthName(currentMonth);
            maxDays = DateTime.DaysInMonth(currentMonth, currentYear);
            startDayofWeek = firstDayOfMonth(currentMonth, currentYear);
            updateTaskList(list);
            //update calendar display
        }

        //get individual tasks for the day
        private List<Task> tasksOfDay(int day)
        {
            return monthTaskList[day];
        }


        private void OnClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mw.Close();
        }
    }
}
