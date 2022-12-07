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
    /// Interaction logic for ChatEventScreen.xaml
    /// </summary>
    public partial class CreateEventScreen : Page
    {
        List<int> groupSavedRestaurantsInt = new List<int>();
        List<long> suggestedEventTimes = new List<long>();

        public CreateEventScreen()
        {
            InitializeComponent();
            groupSavedRestaurantsInt = SessionData.getGroupSavedRestaurants(SessionData.getCurrentGroupId());
            suggestedEventTimes = SessionData.getEventCustomTimesOnGroupDate(SessionData.getCurrentGroupId());
        }

        private List<string> getRestaurantsFormatted()
        {
            List<string> resListStrings = new List<string>();
            foreach (int res in groupSavedRestaurantsInt)
            {
                resListStrings.Add(SessionData.getRestaurantName(res));
            }

            return resListStrings;
        }

        private List<string> getTimeListFormatted()
        {
            List<string> timeListStrings = new List<string>();
            foreach (long time in suggestedEventTimes)
            {
                timeListStrings.Add(SessionData.getDateOrTimefromEpoch(time).ToString("MMMM dd, yyyy @ hh:mm tt"));
            }

            return timeListStrings;
        }

        private void CreateEventButton_Click(object sender, RoutedEventArgs e)
        {
            if ((RestaurantList.SelectedIndex == -1) ||
                TimeList.SelectedIndex== -1)
            {
                ErrorTextBlock.Foreground = Brushes.Indigo;
                ErrorTextBlock.Text = "Please select a valid restaurant and time.";
            }
            else
            {
                var restaurantId = RestaurantList.SelectedIndex;
                var addTime = suggestedEventTimes[TimeList.SelectedIndex];
                Logic_Group.createGroupEvent(restaurantId, addTime, "");
                ErrorTextBlock.Foreground = Brushes.Blue;
                ErrorTextBlock.Text = "Event successfully created!";
            }
        }

        private void TopBar_Loaded(object sender, RoutedEventArgs e)
        {
            ComponentFunctions.setLabel(TopBar);
        }

        private void RestaurantList_Loaded(object sender, RoutedEventArgs e)
        {
            RestaurantList.ItemsSource = getRestaurantsFormatted();
        }

        private void TimeList_Loaded(object sender, RoutedEventArgs e)
        {
            TimeList.ItemsSource = getTimeListFormatted();
        }
    }
}
