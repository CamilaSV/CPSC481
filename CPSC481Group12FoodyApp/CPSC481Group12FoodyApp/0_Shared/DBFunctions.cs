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
        private const string restaurants = "Restaurants.json";

        // getters
        public static void createNecessaryFiles()
        {
            Directory.CreateDirectory(dbDir);
            File.Create(getAccountsPath()).Close();
            File.Create(getGroupsPath()).Close();
            File.Create(getRestaurantsPath()).Close();
        }

        private static string getAccountsPath()
        {
            return dbDir + accounts;
        }

        private static string getGroupsPath()
        {
            return dbDir + groups;
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

        public static Dictionary<int, GroupInfo> getAllGroupInfo()
        {
            string json = File.ReadAllText(getGroupsPath());
            return new Dictionary<int, GroupInfo>(JsonSerializer.Deserialize<Dictionary<int, GroupInfo>>(json));
        }

        public static Dictionary<int, RestaurantInfo> getAllRestaurantInfo()
        {
            string json = File.ReadAllText(getRestaurantsPath());
            return new Dictionary<int, RestaurantInfo>(JsonSerializer.Deserialize<Dictionary<int, RestaurantInfo>>(json));
        }

        // setters
        public static void saveInfo(Dictionary<string, UserInfo> allInfo)
        {
            File.WriteAllText(getAccountsPath(), JsonSerializer.Serialize(allInfo, new JsonSerializerOptions { WriteIndented = true }));
        }

        public static void saveInfo(Dictionary<int, GroupInfo> allInfo)
        {
            File.WriteAllText(getGroupsPath(), JsonSerializer.Serialize(allInfo, new JsonSerializerOptions { WriteIndented = true }));
        }

    }
}
