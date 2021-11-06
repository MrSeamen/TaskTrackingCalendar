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

namespace TaskTrackingCalendar.SummaryPagePopups
{
    /// <summary>
    /// Interaction logic for CreateReminderPopup.xaml
    /// </summary>
    public partial class CreateReminderPopup : Window
    {
        TaskList list;
        public CreateReminderPopup(TaskList list)
        {
            this.list = list;
            InitializeComponent();
        }
    }
}
