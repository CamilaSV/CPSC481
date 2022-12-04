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
        private const string criteria = "Criteria.json";

        public static void createNecessaryFiles()
        {
            Directory.CreateDirectory(dbDir);
            CreateMock.createPresetCriteria();
            CreateMock.createRestaurants();
            File.AppendText(getAccountsPath()).Close();
            File.AppendText(getGroupsPath()).Close();
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

        private static string getCriteriaPath()
        {
            return dbDir + criteria;
        }

        public static Dictionary<string, UserInfo> getAllUserInfo()
        {
            string json = File.ReadAllText(getAccountsPath());
            if (string.IsNullOrEmpty(json)) {
                return new Dictionary<string, UserInfo>();
            }
            
            return new Dictionary<string, UserInfo>(JsonSerializer.Deserialize<Dictionary<string, UserInfo>>(json));
        }

        public static Dictionary<int, GroupInfo> getAllGroupInfo()
        {
            string json = File.ReadAllText(getGroupsPath());
            if (string.IsNullOrEmpty(json))
            {
                return new Dictionary<int, GroupInfo>();
            }

            return new Dictionary<int, GroupInfo>(JsonSerializer.Deserialize<Dictionary<int, GroupInfo>>(json));
        }

        public static Dictionary<int, RestaurantInfo> getAllRestaurantInfo()
        {
            string json = File.ReadAllText(getRestaurantsPath());
            if (string.IsNullOrEmpty(json)) {
                return new Dictionary<int, RestaurantInfo>();
            }

            return new Dictionary<int, RestaurantInfo>(JsonSerializer.Deserialize<Dictionary<int, RestaurantInfo>>(json));
        }

        public static Dictionary<int, PresetCriteriaInfo> getAllCriteriaInfo()
        {
            string json = File.ReadAllText(getCriteriaPath());
            if (string.IsNullOrEmpty(json))
            {
                return new Dictionary<int, PresetCriteriaInfo>();
            }

            return new Dictionary<int, PresetCriteriaInfo>(JsonSerializer.Deserialize<Dictionary<int, PresetCriteriaInfo>>(json));
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
