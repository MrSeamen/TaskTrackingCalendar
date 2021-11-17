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
        private DateTime now; //current time, cannot be changed
        private int currentYear; //can be changed for data
        private int currentMonth; //can be changed for data
        private int currentDay; //do not change
        private int maxDays; //updated with buttons
        private int startDayofWeek; //updated with buttons
        private String currentMonthName; //updated with buttons
        private List<Task>[] monthTaskList = new List<Task>[31];
        private CalendarDate[,] monthTaskDays = new CalendarDate[5, 7];

        public String getCurrentMonthName()
        {
            return currentMonthName;
        }

        public int getCurrentDay()
        {
            return currentDay;
        }

        public int getCurrentMonth()
        {
            return currentMonth;
        }

        public int getCurrentYear()
        {
            return currentYear;
        }

        public DateTime getCurrentTime()
        {
            return now;
        }

        public int getMaxDays()
        {
            return maxDays;
        }

        public int getStartDayOfWeek()
        {
            return startDayofWeek;
        }

        public List<Task>[] getMonthTaskList()
        {
            return monthTaskList;
        }

        public CalendarDate[,] getmonthTaskDays()
        {
            return monthTaskDays;
        }
        

        public class CalendarDate
        {
            int date;
            List<Task> taskList = new List<Task>();

            public CalendarDate(int date, List<Task> taskList)
            {
                this.date = date;
                this.taskList.AddRange(taskList);
            }
            public CalendarDate(int date)
            {
                this.date = date;
                taskList = new List<Task>();
            }

            public void clear()
            {
                date = 0;
                taskList.Clear();
            }

            public void setDate(int date)
            {
                this.date = date;
            }

            public void addTaskList(List<Task> taskList)
            {
                this.taskList.AddRange(taskList);
            }


            public int getDate()
            {
                return date;
            }

            public List<Task> getTaskList()
            {
                return taskList;
            }
        }

        public CalendarPage(TaskList newList, SecretMainWindow parent)
        {
            list = newList;
            mw = parent;
            InitializeComponent();
            now = DateTime.Now;
            currentYear = now.Year;
            currentMonth = now.Month;
            currentDay = now.Day;
            currentMonthName = monthName(currentMonth);
            maxDays = DateTime.DaysInMonth(currentYear, currentMonth);
            startDayofWeek = firstDayOfMonth(currentMonth, currentYear);
            updateTaskList(list);
            updateMonthDays(monthTaskList, startDayofWeek);
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
                if (monthTaskList[i] == null)
                {
                    monthTaskList[i] = new List<Task>();
                }
                else
                {
                    monthTaskList[i].Clear();
                }
            }
            //get tasks for this month
            for (int day = 1; day < maxDays; day++)
            {
                foreach (Task task in taskList.GetSummaryTasks())
                {
                    if (task.GetDate().Month == currentMonth && task.GetDate().Day == day)
                    {
                        monthTaskList[day].Add(task);
                    }
                }
            }
        }

        private void updateMonthDays(List<Task>[] taskList, int dayOffSet)
        {
            int year = 0;
            int month = 0;
            int date = 0;
            for (int week = 0; week < monthTaskDays.GetLength(0); week++)
            {
                
                for (int day = 0; day < monthTaskDays.GetLength(1); day++)
                {
                    month = currentMonth;
                    year = currentYear;
                    //handle date
                    date = week * 7 + day - dayOffSet;
                    //beginning of month
                    if (week == 0)
                    {
                        int previousMonthMaxDays;
                        if (month == 1) {
                            previousMonthMaxDays = DateTime.DaysInMonth(year--, 12);
                        } else {
                            previousMonthMaxDays = DateTime.DaysInMonth(year, month--);
                        }
                        if (day < dayOffSet)
                        {
                            date += previousMonthMaxDays;
                        }
                    } else if (week == monthTaskDays.GetLength(0) - 1)
                    {
                        //end of month
                        if (date > maxDays)
                        {
                            date -= maxDays;
                        }
                    }

                    if (monthTaskDays[week, day] == null)
                    {
                        if (taskList[date] == null)
                        {
                            monthTaskDays[week, day] = new CalendarDate(date);
                        }
                        else
                        {
                            monthTaskDays[week, day] = new CalendarDate(date, taskList[date]);
                        }
                    }
                    else
                    {
                        monthTaskDays[week, day].clear();
                        monthTaskDays[week, day].setDate(date);
                        monthTaskDays[week, day].addTaskList(taskList[date]);
                    }
                }
            }
        }

        private String monthName(int month)
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
            maxDays = DateTime.DaysInMonth(currentYear, currentMonth);
            startDayofWeek = firstDayOfMonth(currentMonth, currentYear);
            updateTaskList(list);
            updateMonthDays(monthTaskList, startDayofWeek);
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
            maxDays = DateTime.DaysInMonth(currentYear, currentMonth);
            startDayofWeek = firstDayOfMonth(currentMonth, currentYear);
            updateTaskList(list);
            updateMonthDays(monthTaskList, startDayofWeek);
            //update calendar display
        }
        private void OnClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mw.Close();
        }
    }
}
