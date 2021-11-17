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
    public partial class CalendarPage : Window
    {
        TaskList list;
        SecretMainWindow mw;
        private DateTime now; //current time, cannot be changed
        private Calendar currentCalendar;

        public class Calendar
        {
            
            public int currentYear { get; set; } //can be changed for data
            public int currentMonth { get; set; } //can be changed for data
            public int currentDay { get; set; }
            private int maxDays; //updated with buttons
            private int startDayofWeek; //updated with buttons
            public String currentMonthName { get; set; } //updated with buttons
            private List<Task>[] monthTaskList = new List<Task>[31];
            public CalendarDate[,] monthTaskDays = new CalendarDate[5, 7];

            public Calendar(DateTime time, TaskList list)
            {
                currentYear = time.Year;
                currentMonth = time.Month;
                currentDay = time.Day;
                updateMonthName(currentMonth);
                maxDays = DateTime.DaysInMonth(currentYear, currentMonth);
                startDayofWeek = firstDayOfMonth(currentMonth, currentYear);
                updateTaskList(list);
                updateMonthDays(monthTaskList, startDayofWeek);
            }

            public CalendarDate getCalendarDate(int week, int day)
            {
                return monthTaskDays[week, day];
            }
            
            public int firstDayOfMonth(int month, int year)
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
                            if (month == 1)
                            {
                                --year;
                                month = 12;
                                previousMonthMaxDays = DateTime.DaysInMonth(year, month);
                            }
                            else
                            {
                                --month;
                                previousMonthMaxDays = DateTime.DaysInMonth(year, month);
                            }
                            if (day < dayOffSet)
                            {
                                ++month;
                                date += previousMonthMaxDays;
                            }
                        }
                        else if (week == monthTaskDays.GetLength(0) - 1)
                        {
                            //end of month
                            if (date > maxDays)
                            {
                                date -= maxDays;
                                ++month;
                            }
                        }

                        if (monthTaskDays[week, day] == null)
                        {
                            if (taskList[date] == null)
                            {
                                monthTaskDays[week, day] = new CalendarDate(date + 1);
                            }
                            else
                            {
                                monthTaskDays[week, day] = new CalendarDate(date + 1, taskList[date]);
                            }
                        }
                        else
                        {
                            if (month != currentMonth)
                            {
                                monthTaskDays[week, day].clear();
                                monthTaskDays[week, day].setDate(date);
                            }
                            else
                            {
                                monthTaskDays[week, day].clear();
                                monthTaskDays[week, day].setDate(date);
                                monthTaskDays[week, day].addTaskList(taskList[date - 1]);
                            }
                        }
                    }
                }
            }

            private void updateMonthName(int month)
            {
                switch (month)
                {
                    case 1:
                        currentMonthName = "January";
                        break;
                    case 2:
                        currentMonthName = "February";
                        break;
                    case 3:
                        currentMonthName = "March";
                        break;
                    case 4:
                        currentMonthName = "April";
                        break;
                    case 5:
                        currentMonthName = "May";
                        break;
                    case 6:
                        currentMonthName = "June";
                        break;
                    case 7:
                        currentMonthName = "July";
                        break;
                    case 8:
                        currentMonthName = "August";
                        break;
                    case 9:
                        currentMonthName = "September";
                        break;
                    case 10:
                        currentMonthName = "October";
                        break;
                    case 11:
                        currentMonthName = "November";
                        break;
                    case 12:
                        currentMonthName = "December";
                        break;
                }
            }

            public void changeMonth(int number, TaskList list)
            {
                //assuming number is 1 or -1
                currentMonth += number;
                if (currentMonth == 13)
                {
                    currentMonth = 1;
                    currentYear++;
                }
                else if (currentMonth == 0)
                {
                    currentMonth = 12;
                    currentYear--;
                }
                updateMonthName(currentMonth);
                maxDays = DateTime.DaysInMonth(currentYear, currentMonth);
                startDayofWeek = firstDayOfMonth(currentMonth, currentYear);
                updateTaskList(list);
                updateMonthDays(monthTaskList, startDayofWeek);
            }

            public CalendarDate getDate(int date)
            {
                return monthTaskDays[(date % 7), (date - date % 7)];
            }
        }

        public class CalendarDate
        {
            public string date { get; set; }
            public List<Task> taskList = new List<Task>();

            public CalendarDate(int date, List<Task> taskList)
            {
                this.date = date.ToString();
                this.taskList.AddRange(taskList);
            }
            public CalendarDate(int date)
            {
                this.date = date.ToString();
                taskList = new List<Task>();
            }

            public void clear()
            {
                date = "";
                taskList.Clear();
            }

            public void addTaskList(List<Task> taskList)
            {
                this.taskList.AddRange(taskList);
            }

            public string getDate()
            {
                return date;
            }

            public void setDate(int date)
            {
                this.date = date.ToString();
            }

            public List<Task> getTaskList()
            {
                return taskList;
            }
        }

        /// Interaction logic for CalendarPage.xaml
        public CalendarPage(TaskList newList, SecretMainWindow parent)
        {
            InitializeComponent();
            list = newList;
            mw = parent;
            now = DateTime.Now;
            currentCalendar = new Calendar(now, list);
            DataContext = currentCalendar;
            Day0.Text = currentCalendar.getCalendarDate(0, 0).getDate();
            //Day00 = currentCalendar.getCalendarDate(0, 0).getTaskList();
        }
        
        private void OnOpenSummary(object sender, RoutedEventArgs e)
        {
            mw.OpenSummaryPage(list);
            Close();
        }


        private void forwardMonth(object sender, RoutedEventArgs e)
        {
            //update current year, current month, monthTaskLists, startDay, and maxDays
            currentCalendar.changeMonth(1, list);
            //update calendar display
            //DataContext = currentCalendar;
        }

        private void backwardMonth(object sender, RoutedEventArgs e)
        {
            //update current year, current month, monthTaskLists, startDay, and maxDays
            currentCalendar.changeMonth(-1, list);
            //update calendar display
            //DataContext = currentCalendar;
        }
        private void OnClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mw.Close();
        }
        
    }

}
