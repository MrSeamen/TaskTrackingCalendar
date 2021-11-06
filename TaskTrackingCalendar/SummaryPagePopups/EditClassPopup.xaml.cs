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
    /// Interaction logic for EditClassPopup.xaml
    /// </summary>
    public partial class EditClassPopup : Window
    {
        TaskList list;

        public EditClassPopup(TaskList list)
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
            var toUpdate = ClassComboBox.SelectedItem;
            var newName = NewNameTextBox.Text;
            if (toUpdate == null)
            {
                ErrorTextBox.Text = "Form incomplete ";
            } else
            {
                if (list.UpdateClass((string)toUpdate, newName))
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
