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
    public static class SessionData_Group
    {
        private static Dictionary<string, GroupInfo> allGroups;

        public static void initializeStartup()
        {
            allGroups = DBFunctions.getAllGroupInfo();
        }

        // getters
        public static string getGroupName(string groupId)
        {
            return allGroups[groupId].name;
        }

        public static List<string> getGroupAdmins(string groupId)
        {
            return allGroups[groupId].adminList;
        }

        public static List<string> getGroupMembers(string groupId)
        {
            return allGroups[groupId].memberList;
        }

        public static List<string> getGroupCustomCriteria(string groupId)
        {
            return allGroups[groupId].customCriteriaList;
        }

        public static List<string> getGroupSavedRestaurants(string groupId)
        {
            return allGroups[groupId].restaurantList;
        }

        public static List<MsgId> getGroupMessages(string groupId)
        {
            return allGroups[groupId].msgList;
        }

        public static List<EventId> getGroupEvents(string groupId)
        {
            return allGroups[groupId].eventList;
        }

        // setters


        // different types of arguments
        public static string getGroupName(int groupId)
        {
            return getGroupName(groupId.ToString());
        }

        public static List<string> getGroupAdmins(int groupId)
        {
            return getGroupAdmins(groupId.ToString());
        }

        public static List<string> getGroupMembers(int groupId)
        {
            return getGroupMembers(groupId.ToString());
        }

        public static List<string> getGroupCustomCriteria(int groupId)
        {
            return getGroupCustomCriteria(groupId.ToString());
        }

        public static List<string> getGroupSavedRestaurants(int groupId)
        {
            return getGroupSavedRestaurants(groupId.ToString());
        }

        public static List<MsgId> getGroupMessages(int groupId)
        {
            return getGroupMessages(groupId.ToString());
        }

        public static List<EventId> getGroupEvents(int groupId)
        {
            return getGroupEvents(groupId.ToString());
        }
    }
}
