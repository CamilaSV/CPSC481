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
    /// Interaction logic for ChatInfoScreen.xaml
    /// </summary>
    public partial class ChatInfoScreen : Page
    {
        public ChatInfoScreen()
        {
            InitializeComponent();
        }

        private void SchedulerDateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SchedulerTimeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreateEventButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.gotoOneChat();
        }

        private void MemberShowMore_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.gotoGroupEditMembers();
        }

        private void Criteria_ShowMore_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.gotoGroupEditCriteria();
        }

        private void Restaurant_ShowMore_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.gotoGroupEditRestaurants();
        }

        private void TopBar_Loaded(object sender, RoutedEventArgs e)
        {
            ComponentFunctions.setLabel(TopBar);
        }

        private void MemberTextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            var members = SessionData.getGroupMembers(SessionData.getCurrentGroupId());
            MemberTextBlock.Text = SessionData.getUserDisplayName(SessionData.getCurrentUser()) + " (Me)";

            var count = 1;
            foreach (var member in members)
            {
                if (!member.Equals(SessionData.getCurrentUser()))
                {
                    if (count == 3)
                    {
                        if (members.Count > count)
                        {
                            MemberShowMore.Visibility = Visibility.Visible;
                        }

                        break;
                    }

                    MemberTextBlock.Text = "\n" + SessionData.getUserDisplayName(member);
                    count++;
                }
            }
        }

        private void CriteriaTextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            var criteriaGroup = SessionData.getGroupCustomCriteria(SessionData.getCurrentGroupId());

            var count = 0;
            if (criteriaGroup.ContainsKey(SessionData.getCurrentUser()))
            {
                CriteriaTextBlock.Text = SessionData.getUserDisplayName(SessionData.getCurrentUser()) + " (Me):\n" + SessionData.getCriterionName(criteriaGroup[SessionData.getCurrentUser()]);
                count++;
            }
            else
            {
                CriteriaTextBlock.Text = "";
            }

            foreach (var criterion in criteriaGroup)
            {
                if (!criterion.Equals(SessionData.getCurrentUser()))
                {
                    if (count == 2)
                    {
                        if (criteriaGroup.Count > count)
                        {
                            CriteriaShowMore.Visibility = Visibility.Visible;
                        }

                        break;
                    }

                    CriteriaTextBlock.Text += SessionData.getUserDisplayName(criterion.Key + "\n" + SessionData.getCriterionName(criterion.Value));
                    count++;
                }
            }
        }

        private void RestaurantTextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            var restaurantGroup = SessionData.getGroupSavedRestaurants(SessionData.getCurrentGroupId());
            RestaurantTextBlock.Text = "";

            var count = 0;
            foreach (var restaurant in restaurantGroup)
            {
                if (count == 3)
                {
                    if (restaurantGroup.Count > count)
                    {
                        RestaurantShowMore.Visibility = Visibility.Visible;
                    }

                    break;
                }

                RestaurantTextBlock.Text += SessionData.getRestaurantName(restaurant);
                count++;
            }
        }
    }
}