using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                        date = week * 7 + day + 1 - dayOffSet;
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
                            if (taskList[date - 1] == null)
                            {
                                monthTaskDays[week, day] = new CalendarDate(date);
                            }
                            else
                            {
                                monthTaskDays[week, day] = new CalendarDate(date, taskList[date - 1]);
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

        public class DateTask
        {
            public string AcademicClass { get; set; }
            public string TaskName { get; set; }
            public string Priority { get; set; }

            public DateTask(string Priority, string AcademicClass, string TaskName)
            {
                this.Priority = Priority;
                this.AcademicClass = AcademicClass;
                this.TaskName = TaskName;
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
            this.list = newList;
            var things = list.GetSummaryTasks();
            foreach (var t in things)
            {
                Trace.WriteLine(t);
            }
            mw = parent;
            now = DateTime.Now;
            currentCalendar = new Calendar(now, list);
            DataContext = currentCalendar;
            refresh();
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
            refresh();
        }

        private void backwardMonth(object sender, RoutedEventArgs e)
        {
            //update current year, current month, monthTaskLists, startDay, and maxDays
            currentCalendar.changeMonth(-1, list);
            //update calendar display
            refresh();
        }

        public void refresh()
        {
            //reset year/month
            Month.Text = currentCalendar.currentMonthName;
            Year.Text = currentCalendar.currentYear.ToString();
            //reset all dates
            Day0.Text = currentCalendar.getCalendarDate(0, 0).getDate();
            Day1.Text = currentCalendar.getCalendarDate(0, 1).getDate();
            Day2.Text = currentCalendar.getCalendarDate(0, 2).getDate();
            Day3.Text = currentCalendar.getCalendarDate(0, 3).getDate();
            Day4.Text = currentCalendar.getCalendarDate(0, 4).getDate();
            Day5.Text = currentCalendar.getCalendarDate(0, 5).getDate();
            Day6.Text = currentCalendar.getCalendarDate(0, 6).getDate();
            Day7.Text = currentCalendar.getCalendarDate(1, 0).getDate();
            Day8.Text = currentCalendar.getCalendarDate(1, 1).getDate();
            Day9.Text = currentCalendar.getCalendarDate(1, 2).getDate();
            Day10.Text = currentCalendar.getCalendarDate(1, 3).getDate();
            Day11.Text = currentCalendar.getCalendarDate(1, 4).getDate();
            Day12.Text = currentCalendar.getCalendarDate(1, 5).getDate();
            Day13.Text = currentCalendar.getCalendarDate(1, 6).getDate();
            Day14.Text = currentCalendar.getCalendarDate(2, 0).getDate();
            Day15.Text = currentCalendar.getCalendarDate(2, 1).getDate();
            Day16.Text = currentCalendar.getCalendarDate(2, 2).getDate();
            Day17.Text = currentCalendar.getCalendarDate(2, 3).getDate();
            Day18.Text = currentCalendar.getCalendarDate(2, 4).getDate();
            Day19.Text = currentCalendar.getCalendarDate(2, 5).getDate();
            Day20.Text = currentCalendar.getCalendarDate(2, 6).getDate();
            Day21.Text = currentCalendar.getCalendarDate(3, 0).getDate();
            Day22.Text = currentCalendar.getCalendarDate(3, 1).getDate();
            Day23.Text = currentCalendar.getCalendarDate(3, 2).getDate();
            Day24.Text = currentCalendar.getCalendarDate(3, 3).getDate();
            Day25.Text = currentCalendar.getCalendarDate(3, 4).getDate();
            Day26.Text = currentCalendar.getCalendarDate(3, 5).getDate();
            Day27.Text = currentCalendar.getCalendarDate(3, 6).getDate();
            Day28.Text = currentCalendar.getCalendarDate(4, 0).getDate();
            Day29.Text = currentCalendar.getCalendarDate(4, 1).getDate();
            Day30.Text = currentCalendar.getCalendarDate(4, 2).getDate();
            Day31.Text = currentCalendar.getCalendarDate(4, 3).getDate();
            Day32.Text = currentCalendar.getCalendarDate(4, 4).getDate();
            Day33.Text = currentCalendar.getCalendarDate(4, 5).getDate();
            Day34.Text = currentCalendar.getCalendarDate(4, 6).getDate();
            //refer to tasklists for new data, reassign itemssource for each date to new list
            Day0TL.ItemsSource = getDateList(0, 0);
            Day1TL.ItemsSource = getDateList(0, 1);
            Day2TL.ItemsSource = getDateList(0, 2);
            Day3TL.ItemsSource = getDateList(0, 3);
            Day4TL.ItemsSource = getDateList(0, 4);
            Day5TL.ItemsSource = getDateList(0, 5);
            Day6TL.ItemsSource = getDateList(0, 6);
            Day7TL.ItemsSource = getDateList(1, 0);
            Day8TL.ItemsSource = getDateList(1, 1);
            Day9TL.ItemsSource = getDateList(1, 2);
            Day10TL.ItemsSource = getDateList(1, 3);
            Day11TL.ItemsSource = getDateList(1, 4);
            Day12TL.ItemsSource = getDateList(1, 5);
            Day13TL.ItemsSource = getDateList(1, 6);
            Day14TL.ItemsSource = getDateList(2, 0);
            Day15TL.ItemsSource = getDateList(2, 1);
            Day16TL.ItemsSource = getDateList(2, 2);
            Day17TL.ItemsSource = getDateList(2, 3);
            Day18TL.ItemsSource = getDateList(2, 4);
            Day19TL.ItemsSource = getDateList(2, 5);
            Day20TL.ItemsSource = getDateList(2, 6);
            Day21TL.ItemsSource = getDateList(3, 0);
            Day22TL.ItemsSource = getDateList(3, 1);
            Day23TL.ItemsSource = getDateList(3, 2);
            Day24TL.ItemsSource = getDateList(3, 3);
            Day25TL.ItemsSource = getDateList(3, 4);
            Day26TL.ItemsSource = getDateList(3, 5);
            Day27TL.ItemsSource = getDateList(3, 6);
            Day28TL.ItemsSource = getDateList(4, 0);
            Day29TL.ItemsSource = getDateList(4, 1);
            Day30TL.ItemsSource = getDateList(4, 2);
            Day31TL.ItemsSource = getDateList(4, 3);
            Day32TL.ItemsSource = getDateList(4, 4);
            Day33TL.ItemsSource = getDateList(4, 5);
            Day34TL.ItemsSource = getDateList(4, 6);
        }

        public List<DateTask> getDateList(int week, int day)
        {
            List<DateTask> dateList = new List<DateTask>();
            foreach (Task t in currentCalendar.getCalendarDate(0, 0).getTaskList())
            {
                dateList.Add(new DateTask(t.GetPriority().ToString(), t.GetClassName(), t.GetName()));
            }
            return dateList;
        }


        private void OnClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mw.Close();
        }
        
    }

}
