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
using TaskTrackingCalendar.SummaryPagePopups;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace TaskTrackingCalendar
{
    /// <summary>
    /// Interaction logic for SummaryPage.xaml
    /// </summary>
    public partial class SummaryPage : Window
    {
        TaskList list;
        SecretMainWindow mw;
        List<DisplayTask> displayTasks;
        List<DisplayReminder> displayReminders;

        bool sortPriority = true;
        string sortClass = "";

        public SummaryPage(TaskList newList, SecretMainWindow parent)
        {
            list = newList;
            mw = parent;
            InitializeComponent();

            displayTasks = new List<DisplayTask>();
            TaskListView.ItemsSource = displayTasks;
            displayReminders = new List<DisplayReminder>();
            ReminderListView.ItemsSource = displayReminders;

            RefreshPage();
        }

        public class DisplayTask
        {
            public string Name { get; set; }

            public string Class { get; set; }

            public int Priority { get; set; }

            public int Day { get; set; }
            public int Month { get; set; }
            public int Year { get; set; }
        }

        public class DisplayReminder
        {
            public string Class { get; set; }

            public string Task { get; set; }

            public int Day { get; set; }
            public int Month { get; set; }
            public int Year { get; set; }
        }

        public void RefreshPage()
        {
            var tasks = list.GetSummaryTasks();
            displayTasks = new List<DisplayTask>();
            foreach (var t in tasks)
            {
                Trace.WriteLine(t);
                displayTasks.Add(new DisplayTask() { Name = t.GetName(), Day = t.GetDate().Day, Month = t.GetDate().Month, Year = t.GetDate().Year, Priority = t.GetPriority(), Class = t.GetClassName() });
            }
            TaskListView.ItemsSource = displayTasks;

            var reminders = list.GetSummaryReminders();
            displayReminders = new List<DisplayReminder>();
            foreach (var r in reminders)
            {
                displayReminders.Add(new DisplayReminder() { Task = r.GetTaskName(), Class = r.GetClassName(), Day = r.GetTime().Day, Month = r.GetTime().Month, Year = r.GetTime().Year });
            }
            ReminderListView.ItemsSource = displayReminders;
        }

        private void OnClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mw.Close();
        }

        private void OnCreateClass(object sender, RoutedEventArgs e)
        {
            var win = new CreateClassPopup(list);
            win.Owner = GetWindow(this);
            win.ShowDialog();
            RefreshPage();
        }

        private void OnEditClass(object sender, RoutedEventArgs e)
        {
            var win = new EditClassPopup(list);
            win.Owner = GetWindow(this);
            win.ShowDialog();
            RefreshPage();
        }

        private void OnDeleteClass(object sender, RoutedEventArgs e)
        {
            var win = new DeleteClassPopup(list);
            win.Owner = GetWindow(this);
            win.ShowDialog();
            RefreshPage();
        }

        private void OnCreateTask(object sender, RoutedEventArgs e)
        {
            var win = new CreateTaskPopup(list);
            win.Owner = GetWindow(this);
            win.ShowDialog();
            RefreshPage();
        }

        private void OnEditTask(object sender, RoutedEventArgs e)
        {
            var win = new EditTaskPopup(list);
            win.Owner = GetWindow(this);
            win.ShowDialog();
            RefreshPage();
        }

        private void OnDeleteTask(object sender, RoutedEventArgs e)
        {
            var win = new DeleteTaskPopup(list);
            win.Owner = GetWindow(this);
            win.ShowDialog();
            RefreshPage();
        }

        private void OnCreateReminder(object sender, RoutedEventArgs e)
        {
            var win = new CreateReminderPopup(list);
            win.Owner = GetWindow(this);
            win.ShowDialog();
            RefreshPage();
        }

        private void OnEditReminder(object sender, RoutedEventArgs e)
        {
            var win = new EditReminderPopup(list);
            win.Owner = GetWindow(this);
            win.ShowDialog();
            RefreshPage();
        }

        private void OnDeleteReminder(object sender, RoutedEventArgs e)
        {
            var win = new DeleteReminderPopup(list);
            win.Owner = GetWindow(this);
            win.ShowDialog();
            RefreshPage();
        }

        private void OnSaveData(object sender, RoutedEventArgs e)
        {
            var win = new SaveDataPopup(list);
            win.Owner = GetWindow(this);
            win.ShowDialog();
            RefreshPage();
        }

        private void OnLoadData(object sender, RoutedEventArgs e)
        {
            var win = new LoadDataPopup(list);
            win.Owner = GetWindow(this);
            win.ShowDialog();
            RefreshPage();
        }

        private void OnOpenCalendar(object sender, RoutedEventArgs e)
        {
            mw.OpenCalendarPage(list);
            Close();
        }
    }
}
