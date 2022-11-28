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

        // setters

        // different types of arguments
    }
}
