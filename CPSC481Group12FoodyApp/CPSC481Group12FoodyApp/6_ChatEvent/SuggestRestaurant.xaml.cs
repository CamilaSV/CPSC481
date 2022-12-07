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
    /// Interaction logic for SuggestRestaurant.xaml
    /// </summary>
    public partial class SuggestRestaurant : Page
    {
        List<int> allRestaurants = new List<int>();

        public SuggestRestaurant()
        {
            InitializeComponent();
            allRestaurants = SessionData.getAllRestaurantsNotSaved(SessionData.getCurrentGroupId());
        }

        private void TopBar_Loaded(object sender, RoutedEventArgs e)
        {
            ComponentFunctions.setLabel(TopBar);
        }

        private void SubmitRestaurantButton_Click(object sender, RoutedEventArgs e)
        {
            if (RestaurantList.SelectedIndex == -1)
            {
                ErrorTextBlock.Foreground = Brushes.Indigo;
                ErrorTextBlock.Text = "Select a restaurant.";
            }
            else
            {
                Logic_Group.addGroupRestaurant(allRestaurants[RestaurantList.SelectedIndex]);
                ErrorTextBlock.Foreground = Brushes.Blue;
                ErrorTextBlock.Text = "Restaurant suggested!";
            }
        }

        private void RestaurantList_Loaded(object sender, RoutedEventArgs e)
        {
            RestaurantList.ItemsSource = getRestaurantsFormatted();
        }

        private List<string> getRestaurantsFormatted()
        {
            List<string> resListStrings = new List<string>();
            foreach (int res in allRestaurants)
            {
                resListStrings.Add(SessionData.getRestaurantName(res));
            }

            return resListStrings;
        }

        private List<string> getCriteriaFormatted()
        {
            var criteria = SessionData.getRestaurantCriteria(allRestaurants[RestaurantList.SelectedIndex]);
            List<string> criteriaStrings = new List<string>();

            foreach (var criterion in criteria)
            {
                criteriaStrings.Add("• " + SessionData.getCriterionName(criterion));
            }

            return criteriaStrings;
        }

        private void RestaurantList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AddressText.Text = SessionData.getRestaurantAddress(allRestaurants[RestaurantList.SelectedIndex]);
            ListControl.ItemsSource = getCriteriaFormatted();
        }
    }
}
