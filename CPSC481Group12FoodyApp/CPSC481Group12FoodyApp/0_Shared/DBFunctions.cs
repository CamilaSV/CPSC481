using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class DBFunctions
    {
        private const string dbDir = "DB\\";
        private const string accounts = "Accounts.json";
        private const string groups = "Groups.json";
        private const string messages = "Messages.json";
        private const string events = "Events.json";
        private const string categories = "Categories.json";
        private const string restaurants = "Restaurants.json";

        // getters
        private static string getDBDir()
        {
            return dbDir;
        }

        private static string getAccountsPath()
        {
            return dbDir + accounts;
        }

        private static string getGroupsPath()
        {
            return dbDir + groups;
        }

        private static string getMessagesPath()
        {
            return dbDir + messages;
        }

        private static string getEventsPath()
        {
            return dbDir + events;
        }

        private static string getCategoriesPath()
        {
            return dbDir + categories;
        }

        private static string getRestaurantsPath()
        {
            return dbDir + restaurants;
        }

        public static Dictionary<string, UserInfo> getAllUserInfo()
        {
            string json = File.ReadAllText(getAccountsPath());
            return new Dictionary<string, UserInfo>(JsonSerializer.Deserialize<Dictionary<string, UserInfo>>(json));
        }

        public static Dictionary<string, GroupInfo> getAllGroupInfo()
        {
            string json = File.ReadAllText(getGroupsPath());
            return new Dictionary<string, GroupInfo>(JsonSerializer.Deserialize<Dictionary<string, GroupInfo>>(json));
        }

        public static Dictionary<MsgId, MsgInfo> getAllMessageInfo()
        {
            string json = File.ReadAllText(getMessagesPath());
            return new Dictionary<MsgId, MsgInfo>(JsonSerializer.Deserialize<Dictionary<MsgId, MsgInfo>>(json));
        }

        public static Dictionary<EventId, EventInfo> getAllEventInfo()
        {
            string json = File.ReadAllText(getEventsPath());
            return new Dictionary<EventId, EventInfo>(JsonSerializer.Deserialize<Dictionary<EventId, EventInfo>>(json));
        }

        public static Dictionary<CategoryId, CategoryInfo> getAllCategoryInfo()
        {
            string json = File.ReadAllText(getCategoriesPath());
            return new Dictionary<CategoryId, CategoryInfo>(JsonSerializer.Deserialize<Dictionary<CategoryId, CategoryInfo>>(json));
        }

        public static Dictionary<string, RestaurantInfo> getAllRestaurantInfo()
        {
            string json = File.ReadAllText(getRestaurantsPath());
            return new Dictionary<string, RestaurantInfo>(JsonSerializer.Deserialize<Dictionary<string, RestaurantInfo>>(json));
        }

        // setters
        public static string createUserInfo(string email, string password)
        {
            return null;
        }

        public static void setUserName(string email, string newName)
        {
        }

        public static void setUserBio(string email, string newBio)
        {
        }

        public static void addUserFriend(string emailUser, string emailTarget)
        {

        }

        public static void removeUserFriend(string emailUser, string emailTarget)
        {

        }
    }
}
