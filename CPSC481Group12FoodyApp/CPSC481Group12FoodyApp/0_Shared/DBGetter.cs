using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class DBGetter
    {
        public static string getDBDir()
        {
            return dbDir;
        }

        public static string getAccountsPath()
        {
            return dbDir + accounts;
        }

        public static string getGroupsPath()
        {
            return dbDir + groups;
        }

        public static string getMessagesPath()
        {
            return dbDir + messages;
        }

        public static string getEventsPath()
        {
            return dbDir + events;
        }

        public static string getCategoriesPath()
        {
            return dbDir + categories;
        }

        public static string getRestaurantsPath()
        {
            return dbDir + restaurants;
        }

        private static Dictionary<string, UserInfo> getAllUserInfo()
        {
            string json = File.ReadAllText(getAccountsPath());
            return new Dictionary<string, UserInfo>(JsonSerializer.Deserialize<Dictionary<string, UserInfo>>(json));
        }

        private static Dictionary<string, GroupInfo> getAllGroupInfo()
        {
            string json = File.ReadAllText(getGroupsPath());
            return new Dictionary<string, GroupInfo>(JsonSerializer.Deserialize<Dictionary<string, GroupInfo>>(json));
        }

        private static Dictionary<MsgId, MsgInfo> getAllMessageInfo()
        {
            string json = File.ReadAllText(getMessagesPath());
            return new Dictionary<MsgId, MsgInfo>(JsonSerializer.Deserialize<Dictionary<MsgId, MsgInfo>>(json));
        }

        private static Dictionary<EventId, EventInfo> getAllEventInfo()
        {
            string json = File.ReadAllText(getEventsPath());
            return new Dictionary<EventId, EventInfo>(JsonSerializer.Deserialize<Dictionary<EventId, EventInfo>>(json));
        }

        private static Dictionary<CategoryId, CategoryInfo> getAllCategoryInfo()
        {
            string json = File.ReadAllText(getCategoriesPath());
            return new Dictionary<CategoryId, CategoryInfo>(JsonSerializer.Deserialize<Dictionary<CategoryId, CategoryInfo>>(json));
        }

        private static Dictionary<string, RestaurantInfo> getAllRestaurantInfo()
        {
            string json = File.ReadAllText(getRestaurantsPath());
            return new Dictionary<string, RestaurantInfo>(JsonSerializer.Deserialize<Dictionary<string, RestaurantInfo>>(json));
        }

        private static UserInfo getUserInfo(string emailUser)
        {
            return getAllUserInfo()[emailUser];
        }

        private static GroupInfo getGroupInfo(string groupId)
        {
            return getAllGroupInfo()[groupId];
        }

        private static MsgInfo getMessageInfo(string groupId, string msgId)
        {
            return getAllMessageInfo()[new MsgId { groupId = groupId, id = msgId }];
        }

        private static EventInfo getEventInfo(string groupId, string eventId)
        {
            return getAllEventInfo()[new EventId { groupId = groupId, id = eventId }];
        }

        private static CategoryInfo getCategoryInfo(string emailUser, string catId)
        {
            return getAllCategoryInfo()[new CategoryId { emailOwner = emailUser, id = catId }];
        }

        private static RestaurantInfo getRestaurantInfo(string restaurantId)
        {
            return getAllRestaurantInfo()[restaurantId];
        }

        public static string getUserPassword(string emailUser)
        {
            return getUserInfo(emailUser).password;
        }

        public static string getUserBio(string emailUser)
        {
            return getUserInfo(emailUser).bio;
        }

        public static List<string> getUserFriendList(string emailUser)
        {
            return getUserInfo(emailUser).friendList;
        }

        public static List<string> getUserFriendRequestList(string emailUser)
        {
            return getUserInfo(emailUser).friendReqList;
        }

        public static List<string> getUserGroupList(string emailUser)
        {
            return getUserInfo(emailUser).groupList;
        }

        public static List<string> getUserEventList(string emailUser)
        {
            return getUserInfo(emailUser).eventList;
        }

        public static List<string> getUserCategoryList(string emailUser)
        {
            return getUserInfo(emailUser).categoryList;
        }

        public static List<string> getUserRestaurantList(string emailUser)
        {
            return getUserInfo(emailUser).restaurantList;
        }

        public static List<InvitationInfo> getUserGroupInvitations(string emailUser)
        {
            return getUserInfo(emailUser).invitationList;
        }

        // these are put here just to send important methods to the top
        private const string dbDir = "DB\\";
        private const string accounts = "Accounts.json";
        private const string groups = "Groups.json";
        private const string messages = "Messages.json";
        private const string events = "Events.json";
        private const string categories = "Categories.json";
        private const string restaurants = "Restaurants.json";
    }
}
