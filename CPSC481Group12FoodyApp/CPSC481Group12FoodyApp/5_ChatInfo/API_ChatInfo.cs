using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Printing;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class API_ChatInfo
    {
        public static void loadChatInfo(ChatInfoScreen infoScreen, string chatId)
        {
            List<string> members = File.ReadAllLines(PathFinder.getChatMembers(chatId)).ToList();
            List<string> criteria = File.ReadAllLines(PathFinder.getChatSavedCriteria(chatId)).ToList();
            List<string> restaurants = File.ReadAllLines(PathFinder.getChatSavedRestaurants(chatId)).ToList();

            int i;
            if (members.Any())
            {
                i = 0;
                infoScreen.MembersTextBlock.Text = members[i];
                i++;
                while ((i < 3) && (i < members.Count))
                {
                    infoScreen.MembersTextBlock.Text += Environment.NewLine + members[i];
                }

                if (members.Count > 3)
                {
                    infoScreen.Members_ShowMoreButton.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    infoScreen.Members_ShowMoreButton.Visibility = System.Windows.Visibility.Hidden;
                }
            }

            if (criteria.Any())
            {
                i = 0;
                infoScreen.CriteriaTextBlock.Text = criteria[i];
                i++;
                while ((i < 3) && (i < criteria.Count))
                {
                    infoScreen.CriteriaTextBlock.Text += Environment.NewLine + criteria[i];
                }

                if (criteria.Count > 3)
                {
                    infoScreen.Criteria_ShowMoreButton.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    infoScreen.Criteria_ShowMoreButton.Visibility = System.Windows.Visibility.Hidden;
                }
            }

            if (restaurants.Any())
            {
                i = 0;
                infoScreen.RestaurantTextBlock.Text = restaurants[i];
                i++;
                while ((i < 3) && (i < restaurants.Count))
                {
                    infoScreen.RestaurantTextBlock.Text += Environment.NewLine + restaurants[i];
                }

                if (restaurants.Count > 3)
                {
                    infoScreen.Restaurant_ShowMoreButton.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    infoScreen.Restaurant_ShowMoreButton.Visibility = System.Windows.Visibility.Hidden;
                }
            }

            PageNavigator.gotoChatInfo();
        }

        public static void addGroupMember()
        {

        }

        public static void removeGroupMember()
        {

        }

        public static void addGroupCriteria()
        {

        }

        public static void removeGroupCriteria()
        {

        }

        public static void addRestaurant()
        {

        }

        public static void removeRestaurant()
        {

        }

        public static void loadChatInfo(ChatInfoScreen infoScreen, int chatId)
        {
            loadChatInfo(infoScreen, chatId.ToString());
        }
    }
}
