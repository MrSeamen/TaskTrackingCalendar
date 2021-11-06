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
            var win = new CreateClassPopup(list);
            win.Owner = GetWindow(this);
            win.ShowDialog();
        }

        private void OnEditClass(object sender, RoutedEventArgs e)
        {
            var win = new EditClassPopup(list);
            win.Owner = GetWindow(this);
            win.ShowDialog();
        }

        private void OnDeleteClass(object sender, RoutedEventArgs e)
        {
            var win = new DeleteClassPopup(list);
            win.Owner = GetWindow(this);
            win.ShowDialog();
        }

        private void OnCreateTask(object sender, RoutedEventArgs e)
        {
            var win = new CreateTaskPopup(list);
            win.Owner = GetWindow(this);
            win.ShowDialog();
        }

        private void OnEditTask(object sender, RoutedEventArgs e)
        {
            var win = new EditTaskPopup(list);
            win.Owner = GetWindow(this);
            win.ShowDialog();
        }

        private void OnDeleteTask(object sender, RoutedEventArgs e)
        {
            var win = new DeleteTaskPopup(list);
            win.Owner = GetWindow(this);
            win.ShowDialog();
        }

        private void OnCreateReminder(object sender, RoutedEventArgs e)
        {
            var win = new CreateReminderPopup(list);
            win.Owner = GetWindow(this);
            win.ShowDialog();
        }

        private void OnEditReminder(object sender, RoutedEventArgs e)
        {
            var win = new EditReminderPopup(list);
            win.Owner = GetWindow(this);
            win.ShowDialog();
        }

        private void OnDeleteReminder(object sender, RoutedEventArgs e)
        {
            var win = new DeleteReminderPopup(list);
            win.Owner = GetWindow(this);
            win.ShowDialog();
        }

        private void OnSaveData(object sender, RoutedEventArgs e)
        {
            var win = new SaveDataPopup(list);
            win.Owner = GetWindow(this);
            win.ShowDialog();

        }

        private void OnLoadData(object sender, RoutedEventArgs e)
        {
            var win = new LoadDataPopup(list);
            win.Owner = GetWindow(this);
            win.ShowDialog();

        }

        private void OnOpenCalendar(object sender, RoutedEventArgs e)
        {
            mw.OpenCalendarPage(list);
            Close();
        }
    }
}
