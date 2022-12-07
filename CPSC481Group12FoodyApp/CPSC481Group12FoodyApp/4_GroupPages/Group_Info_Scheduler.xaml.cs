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
    /// Interaction logic for Template_NoBottom.xaml
    /// </summary>
    public partial class ChatScheduler : Page
    {
        public ChatScheduler()
        {
            InitializeComponent();
        }

        private void TopBar_Loaded(object sender, RoutedEventArgs e)
        {
            ComponentFunctions.setLabel(TopBar);
        }

        private void AddTimeButton_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.gotoCustomEventTime();
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            ListControl.ItemsSource = GetObservableCollection.displayGroupSuggestTimeList((DateTime)SchedulerCalendar.SelectedDate);
        }
    }
}
