using CPSC481Group12FoodyApp.Logic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CPSC481Group12FoodyApp
{
    /// <summary>
    /// Interaction logic for ChatAddCustomTime.xaml
    /// </summary>
    public partial class ChatAddCustomTime : Page
    {
        DateTime date;
        bool isAM;

        public ChatAddCustomTime()
        {
            isAM = true;
            InitializeComponent();
        }

        private void TopBar_Loaded(object sender, RoutedEventArgs e)
        {
            ComponentFunctions.setLabel(TopBar);
        }

        private void AM_Button_Click(object sender, RoutedEventArgs e)
        {
            isAM = true;
        }

        private void PM_Button_Click(object sender, RoutedEventArgs e)
        {
            isAM = false;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string customDateTimePick = CustomTimePick.Text;
                if ((customDateTimePick.Length != 5) ||
                    (customDateTimePick[2] != ':'))
                {
                    throw new FormatException("Not a valid time format.");
                }

                string hour = CustomTimePick.Text.Substring(0, 2);
                string minute = CustomTimePick.Text.Substring(3, 2);
                int hourInt = Int32.Parse(hour);
                if (!isAM)
                {
                    hourInt += 12;
                }

                date = new DateTime(date.Year, date.Month, date.Day, hourInt, Int32.Parse(minute), 0);

                Logic_Group.addGroupEventCustomTime(SessionData.getCurrentGroupId(), date);
            }
            catch (FormatException)
            {
                // print on error textblock
            }
        }

        private void CustomTimePick_GotFocus(object sender, RoutedEventArgs e)
        {
            CustomTimePick.Text = string.Empty;
        }

        private void CustomDatePick_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            date = (DateTime)CustomDatePick.SelectedDate;
        }
    }
}
