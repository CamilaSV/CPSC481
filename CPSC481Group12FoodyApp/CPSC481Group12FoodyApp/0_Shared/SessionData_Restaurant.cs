using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text.Json;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class SessionData_Restaurant
    {
        private static Dictionary<string, RestaurantInfo> allRestaurants;

        public static void initializeStartup()
        {
            allRestaurants = DBFunctions.getAllRestaurantInfo();
        }

        // getters
        public static string getRestaurantName(string restaurantId)
        {
            return allRestaurants[restaurantId].name;
        }

        public static string getRestaurantAddress(string restaurantId)
        {
            return allRestaurants[restaurantId].address;
        }

        public static List<string> getRestaurantCriteria(string restaurantId)
        {
            return allRestaurants[restaurantId].criteriaList;
        }

        // different types of arguments
        public static string getRestaurantName(int restaurantId)
        {
            return getRestaurantName(restaurantId.ToString());
        }

        public static string getRestaurantAddress(int restaurantId)
        {
            return getRestaurantAddress(restaurantId.ToString());
        }

        public static List<string> getRestaurantCriteria(int restaurantId)
        {
            return getRestaurantCriteria(restaurantId.ToString());
        }
    }
}
