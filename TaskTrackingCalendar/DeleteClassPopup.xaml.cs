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
    /// Interaction logic for DeleteClassPopup.xaml
    /// </summary>
    public partial class DeleteClassPopup : Window
    {
        TaskList list;

        public DeleteClassPopup(TaskList list)
        {
            this.list = list;

            InitializeComponent();
            foreach (var c in list.GetSummaryClasses())
            {
                ClassComboBox.Items.Add(c);
            }
            ClassComboBox.SelectedIndex = 0;
        }

        private void OnSubmit(object sender, RoutedEventArgs e)
        {
            var toDelete = ClassComboBox.SelectedItem;
            if (toDelete == null)
            {
                ErrorTextBox.Text = "Form incomplete ";
            }
            else
            {
                if (list.DeleteClass((string)toDelete))
                {
                    Close();
                } else
                {
                    ErrorTextBox.Text = "Arguments invalid ";
                }
            }
        }
    }
}
