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

        public static void createGroup(string groupId, string groupName, string emailCreator)
        {
            GroupInfo info = new GroupInfo
            {
                name = groupName,
                adminList = new List<string>() { emailCreator },
                memberList = new List<string>() { emailCreator },
                customCriteriaList = new List<string>(),
                restaurantList = new List<string>(),
                msgList = new List<string>(),
                eventList = new List<string>(),
            };

            allGroups[groupId] = info;
        }

        public static void addGroupMsg(string groupId, string msgId, string msgSender, string msgContent)
        {
            if (!allGroups[groupId].msgList.Contains(msgId))
            {
                allGroups[groupId].msgList.Add(msgId);
                SessionData_Msg.createMessage(groupId, msgId, msgSender, msgContent);
            }
        }

        public static void createGroupEvent(string groupId, string eventId, string time, string resId, string comment)
        {
            SessionData_Event.createEvent(groupId, eventId, time, resId, comment);
            addGroupEvent(groupId, eventId);
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

        public static List<string> getGroupMessages(string groupId)
        {
            return allGroups[groupId].msgList;
        }

        public static List<string> getGroupEvents(string groupId)
        {
            return allGroups[groupId].eventList;
        }

        // setters
        public static void addGroupMemberToAdmin(string groupId, string emailTarget)
        {
            if (!allGroups[groupId].adminList.Contains(emailTarget))
            {
                allGroups[groupId].adminList.Add(emailTarget);
            }
        }

        public static void removeGroupMemberFromAdmin(string groupId, string emailTarget)
        {
            if (allGroups[groupId].adminList.Contains(emailTarget))
            {
                allGroups[groupId].adminList.Remove(emailTarget);
            }
        }

        public static void addGroupMember(string groupId, string emailTarget)
        {
            if (!allGroups[groupId].memberList.Contains(emailTarget))
            {
                allGroups[groupId].memberList.Add(emailTarget);
            }
        }

        public static void removeGroupMember(string groupId, string emailTarget)
        {
            if (allGroups[groupId].memberList.Contains(emailTarget))
            {
                allGroups[groupId].memberList.Remove(emailTarget);
            }
        }

        public static void addGroupCriterion(string groupId, string criterion)
        {
            if (!allGroups[groupId].customCriteriaList.Contains(criterion))
            {
                allGroups[groupId].customCriteriaList.Add(criterion);
            }
        }

        public static void removeGroupCriterion(string groupId, string criterion)
        {
            if (allGroups[groupId].customCriteriaList.Contains(criterion))
            {
                allGroups[groupId].customCriteriaList.Remove(criterion);
            }
        }

        public static void addGroupRestaurant(string groupId, string restaurantId)
        {
            if (!allGroups[groupId].restaurantList.Contains(restaurantId))
            {
                allGroups[groupId].restaurantList.Add(restaurantId);
            }
        }

        public static void removeGroupRestaurant(string groupId, string restaurantId)
        {
            if (allGroups[groupId].restaurantList.Contains(restaurantId))
            {
                allGroups[groupId].restaurantList.Remove(restaurantId);
            }
        }

        public static void addGroupEvent(string groupId, string eventId)
        {
            if (!allGroups[groupId].eventList.Contains(eventId))
            {
                allGroups[groupId].eventList.Add(eventId);
            }
        }

        public static void removeGroupEvent(string groupId, string eventId) {
            if (allGroups[groupId].eventList.Contains(eventId))
            {
                allGroups[groupId].eventList.Remove(eventId);

                EventId ev = new EventId { groupId = groupId, id = eventId };

                SessionData_Event.deleteEvent(ev);
                foreach (var memberEmail in allGroups[groupId].memberList)
                {
                    SessionData_User.removeUserEvent(memberEmail, ev);
                }
            }
        }

        // different types of arguments
        public static void createGroup(int groupId, string groupName, string emailCreator)
        {
            createGroup(emailCreator, groupId.ToString(), groupName);
        }

        public static void addGroupMsg(string groupId, int msgId, string msgSender, string msgContent)
        {
            addGroupMsg(groupId.ToString(), msgId.ToString(), msgSender, msgContent);
        }

        public static void addGroupMsg(int groupId, string msgId, string msgSender, string msgContent)
        {
            addGroupMsg(groupId.ToString(), msgId.ToString(), msgSender, msgContent);
        }

        public static void addGroupMsg(int groupId, int msgId, string msgSender, string msgContent)
        {
            addGroupMsg(groupId.ToString(), msgId.ToString(), msgSender, msgContent);
        }

        public static void createGroupEvent(string groupId, string eventId, string time, int resId, string comment)
        {
            createGroupEvent(groupId.ToString(), eventId.ToString(), time.ToString(), resId.ToString(), comment);
        }

        public static void createGroupEvent(string groupId, string eventId, long time, string resId, string comment)
        {
            createGroupEvent(groupId.ToString(), eventId.ToString(), time.ToString(), resId.ToString(), comment);
        }

        public static void createGroupEvent(string groupId, string eventId, long time, int resId, string comment)
        {
            createGroupEvent(groupId.ToString(), eventId.ToString(), time.ToString(), resId.ToString(), comment);
        }

        public static void createGroupEvent(string groupId, int eventId, string time, string resId, string comment)
        {
            createGroupEvent(groupId.ToString(), eventId.ToString(), time.ToString(), resId.ToString(), comment);
        }

        public static void createGroupEvent(string groupId, int eventId, string time, int resId, string comment)
        {
            createGroupEvent(groupId.ToString(), eventId.ToString(), time.ToString(), resId.ToString(), comment);
        }

        public static void createGroupEvent(string groupId, int eventId, long time, string resId, string comment)
        {
            createGroupEvent(groupId.ToString(), eventId.ToString(), time.ToString(), resId.ToString(), comment);
        }

        public static void createGroupEvent(string groupId, int eventId, long time, int resId, string comment)
        {
            createGroupEvent(groupId.ToString(), eventId.ToString(), time.ToString(), resId.ToString(), comment);
        }

        public static void createGroupEvent(int groupId, string eventId, string time, string resId, string comment)
        {
            createGroupEvent(groupId.ToString(), eventId.ToString(), time.ToString(), resId.ToString(), comment);
        }

        public static void createGroupEvent(int groupId, string eventId, string time, int resId, string comment)
        {
            createGroupEvent(groupId.ToString(), eventId.ToString(), time.ToString(), resId.ToString(), comment);
        }

        public static void createGroupEvent(int groupId, string eventId, long time, string resId, string comment)
        {
            createGroupEvent(groupId.ToString(), eventId.ToString(), time.ToString(), resId.ToString(), comment);
        }

        public static void createGroupEvent(int groupId, string eventId, long time, int resId, string comment)
        {
            createGroupEvent(groupId.ToString(), eventId.ToString(), time.ToString(), resId.ToString(), comment);
        }

        public static void createGroupEvent(int groupId, int eventId, string time, string resId, string comment)
        {
            createGroupEvent(groupId.ToString(), eventId.ToString(), time.ToString(), resId.ToString(), comment);
        }

        public static void createGroupEvent(int groupId, int eventId, string time, int resId, string comment)
        {
            createGroupEvent(groupId.ToString(), eventId.ToString(), time.ToString(), resId.ToString(), comment);
        }

        public static void createGroupEvent(int groupId, int eventId, long time, string resId, string comment)
        {
            createGroupEvent(groupId.ToString(), eventId.ToString(), time.ToString(), resId.ToString(), comment);
        }

        public static void createGroupEvent(int groupId, int eventId, long time, int resId, string comment)
        {
            createGroupEvent(groupId.ToString(), eventId.ToString(), time.ToString(), resId.ToString(), comment);
        }

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

        public static List<string> getGroupMessages(int groupId)
        {
            return getGroupMessages(groupId.ToString());
        }

        public static List<string> getGroupEvents(int groupId)
        {
            return getGroupEvents(groupId.ToString());
        }

        public static void addGroupMemberToAdmin(int groupId, string emailTarget)
        {
            addGroupMemberToAdmin(groupId.ToString(), emailTarget);
        }

        public static void removeGroupMemberFromAdmin(int groupId, string emailTarget)
        {
            removeGroupMemberFromAdmin(groupId.ToString(), emailTarget);
        }

        public static void addGroupMember(int groupId, string emailTarget)
        {
            addGroupMember(groupId.ToString(), emailTarget);
        }

        public static void removeGroupMember(int groupId, string emailTarget)
        {
            removeGroupMember(groupId.ToString(), emailTarget);
        }

        public static void addGroupCriterion(int groupId, string criterion)
        {
            addGroupCriterion(groupId.ToString(), criterion);
        }

        public static void removeGroupCriterion(int groupId, string criterion)
        {
            removeGroupCriterion(groupId.ToString(), criterion);
        }

        public static void addGroupRestaurant(string groupId, int restaurantId)
        {
            addGroupRestaurant(groupId.ToString(), restaurantId.ToString());
        }

        public static void addGroupRestaurant(int groupId, string restaurantId)
        {
            addGroupRestaurant(groupId.ToString(), restaurantId.ToString());
        }

        public static void addGroupRestaurant(int groupId, int restaurantId)
        {
            addGroupRestaurant(groupId.ToString(), restaurantId.ToString());
        }

        public static void removeGroupRestaurant(string groupId, int restaurantId)
        {
            removeGroupRestaurant(groupId.ToString(), restaurantId.ToString());
        }

        public static void removeGroupRestaurant(int groupId, string restaurantId)
        {
            removeGroupRestaurant(groupId.ToString(), restaurantId.ToString());
        }

        public static void removeGroupRestaurant(int groupId, int restaurantId)
        {
            removeGroupRestaurant(groupId.ToString(), restaurantId.ToString());
        }
    }
}
