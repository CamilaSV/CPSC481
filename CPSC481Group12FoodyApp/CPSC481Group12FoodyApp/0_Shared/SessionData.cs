using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Interop;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class SessionData
    {
        private static string currentUser = "";
        private static Dictionary<string, UserInfo> allUsers;
        private static Dictionary<int, GroupInfo> allGroups;
        private static Dictionary<int, RestaurantInfo> allRestaurants;

        public static void initializeStartup()
        {
            allUsers = DBFunctions.getAllUserInfo();
            allGroups = DBFunctions.getAllGroupInfo();
            allRestaurants = DBFunctions.getAllRestaurantInfo();
        }

        public static void loginUser(string emailUser)
        {
            currentUser = emailUser;
        }

        public static string getCurrentUser()
        {
            return currentUser;
        }

        // setters for user
        public static void createUser(string emailUser, string password)
        {
            UserInfo info = new UserInfo
            {
                password = password,
                name = emailUser,
                bio = "",
                friendList = new List<string>(),
                friendReqList = new List<string>(),
                groupList = new List<int>(),
                categoryList = new List<CategoryInfo>(),
                eventList = new List<UserEventInfo>(),
                invitationList = new List<InvitationInfo>(),
            };

            allUsers[emailUser] = info;
            DBFunctions.saveInfo(allUsers);
        }

        public static void addUserNewGroup(string emailCreator, int groupId, string name)
        {
            createGroup(groupId, name, emailCreator);
            addUserGroup(emailCreator, groupId);
            DBFunctions.saveInfo(allUsers);
        }

        public static void addUserFriend(string emailUser, string emailTarget)
        {
            if (!allUsers[emailUser].friendList.Contains(emailTarget))
            {
                allUsers[emailUser].friendList.Add(emailTarget);
                addUserFriend(emailTarget, emailUser);
                removeUserFriendReq(emailUser, emailTarget);
            }
        }

        public static void removeUserFriend(string emailUser, string emailTarget)
        {
            if (allUsers[emailUser].friendList.Contains(emailTarget))
            {
                allUsers[emailUser].friendList.Remove(emailTarget);
                DBFunctions.saveInfo(allUsers);
            }
        }

        public static void removeUserFriendReq(string emailUser, string emailTarget)
        {
            if (allUsers[emailUser].friendReqList.Contains(emailTarget))
            {
                allUsers[emailUser].friendReqList.Remove(emailTarget);
                DBFunctions.saveInfo(allUsers);
            }
        }

        public static void addUserCategory(string emailUser, int categoryId, string name)
        {
            if (getCategoryExist(emailUser, categoryId) == -1)
            {
                CategoryInfo info = new CategoryInfo
                {
                    id = categoryId,
                    name = name,
                    restaurantList = new List<int>(),
                };

                allUsers[emailUser].categoryList.Add(info);
                DBFunctions.saveInfo(allUsers);
            }
        }

        public static void removeUserCategory(string emailUser, int categoryId)
        {
            int index = getCategoryExist(emailUser, categoryId);
            if (index != -1)
            {
                allUsers[emailUser].categoryList.RemoveAt(index);
                DBFunctions.saveInfo(allUsers);
            }
        }

        public static void addUserGroup(string emailUser, int groupId)
        {
            if (!allUsers[emailUser].groupList.Contains(groupId))
            {
                allUsers[emailUser].groupList.Add(groupId);
                // delete all invitations that invites to the added groupId
                allUsers[emailUser].invitationList.RemoveAll(invite => invite.inviteGroupId.Equals(groupId));
                addGroupMember(groupId, emailUser);
                DBFunctions.saveInfo(allUsers);
            }
        }

        public static void removeUserGroup(string emailUser, int groupId)
        {
            if (allUsers[emailUser].groupList.Contains(groupId))
            {
                allUsers[emailUser].groupList.Remove(groupId);
                removeGroupMember(groupId, emailUser);
                DBFunctions.saveInfo(allUsers);
            }
        }

        public static void addUserEvent(string emailUser, int groupId, int eventId)
        {
            UserEventInfo eventInfo = new UserEventInfo { groupId = groupId, eventId = eventId };

            if (!allUsers[emailUser].eventList.Contains(eventInfo))
            {
                allUsers[emailUser].eventList.Add(eventInfo);
                DBFunctions.saveInfo(allUsers);
            }
        }

        public static void removeUserEvent(string emailUser, int groupId, int eventId)
        {
            UserEventInfo eventInfo = new UserEventInfo { groupId = groupId, eventId = eventId };

            if (allUsers[emailUser].eventList.Contains(eventInfo))
            {
                allUsers[emailUser].eventList.Remove(eventInfo);
                DBFunctions.saveInfo(allUsers);
            }
        }

        public static void addUserRestaurant(string emailUser, int catId, int resId)
        {
            Tuple<int, Boolean> index = getUserCategoryHasRes(emailUser, catId, resId);
            if ((index.Item1 != -1) && (index.Item2 == false))
            {
                allUsers[emailUser].categoryList[index.Item1].restaurantList.Add(resId);
                DBFunctions.saveInfo(allUsers);
            }
        }

        public static void removeUserRestaurant(string emailUser, int catId, int resId)
        {
            Tuple<int, Boolean> index = getUserCategoryHasRes(emailUser, catId, resId);
            if (index.Item2 == true)
            {
                allUsers[emailUser].categoryList[index.Item1].restaurantList.Remove(resId);
                DBFunctions.saveInfo(allUsers);
            }
        }

        public static void removeUserGroupInvite(string emailUser, int groupId, string emailSender)
        {
            InvitationInfo info = new InvitationInfo { inviteGroupId = groupId, inviteSenderEmail = emailSender };
            if (allUsers[emailUser].invitationList.Contains(info))
            {
                allUsers[emailUser].invitationList.Remove(info);
                DBFunctions.saveInfo(allUsers);
            }
        }

        // these ones are different from the above that the user alters target's information
        public static void addUserFriendReqToTarget(string emailUser, string emailTarget)
        {
            if (!allUsers[emailTarget].friendReqList.Contains(emailUser))
            {
                allUsers[emailTarget].friendReqList.Add(emailUser);
                DBFunctions.saveInfo(allUsers);
            }
        }

        public static void addUserGroupInviteToTarget(string emailTarget, int groupId, string emailSender)
        {
            InvitationInfo info = new InvitationInfo { inviteGroupId = groupId, inviteSenderEmail = emailSender };
            if (!allUsers[emailTarget].invitationList.Contains(info))
            {
                allUsers[emailTarget].invitationList.Add(info);
                DBFunctions.saveInfo(allUsers);
            }
        }

        public static void setUserPassword(string email, string password)
        {
            allUsers[email].name = password;
            DBFunctions.saveInfo(allUsers);
        }

        public static void setUserDisplayName(string email, string name)
        {
            allUsers[email].name = name;
            DBFunctions.saveInfo(allUsers);
        }

        public static void setUserBio(string email, string bio)
        {
            allUsers[email].bio = bio;
            DBFunctions.saveInfo(allUsers);
        }

        public static void setCategoryName(string email, int catId, string name)
        {
            allUsers[email].categoryList[catId].name = name;
            DBFunctions.saveInfo(allUsers);
        }

        // setters for group/event
        public static void createGroup(int groupId, string groupName, string emailCreator)
        {
            GroupInfo info = new GroupInfo
            {
                name = groupName,
                adminList = new List<string>() { emailCreator },
                memberList = new List<string>() { emailCreator },
                customCriteriaList = new List<string>(),
                restaurantList = new List<int>(),
                msgList = new List<MsgInfo>(),
                eventList = new List<EventInfo>(),
            };

            allGroups[groupId] = info;
            DBFunctions.saveInfo(allGroups);
        }

        public static void deleteGroup(int groupId)
        {
            if (allGroups.ContainsKey(groupId))
            {
                allGroups.Remove(groupId);
                DBFunctions.saveInfo(allGroups);

                // delete all events in each user?
                foreach (var user in allUsers)
                {
                    user.Value.eventList.RemoveAll(ev => ev.groupId.Equals(groupId));
                }
                DBFunctions.saveInfo(allUsers);
            }
        }

        public static void addGroupMsg(int groupId, int msgId, string msgSender, string msgContent)
        {
            if (getGroupMsgExist(groupId, msgId) == -1)
            {
                MsgInfo msg = new MsgInfo
                {
                    id = msgId,
                    senderEmail = msgSender,
                    content = msgContent,
                    time = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                };

                allGroups[groupId].msgList.Add(msg);
                DBFunctions.saveInfo(allGroups);
            }
        }

        public static void addGroupMemberToAdmin(int groupId, string emailTarget)
        {
            if (!allGroups[groupId].adminList.Contains(emailTarget))
            {
                allGroups[groupId].adminList.Add(emailTarget);
                DBFunctions.saveInfo(allGroups);
            }
        }

        public static void removeGroupMemberFromAdmin(int groupId, string emailTarget)
        {
            if (allGroups[groupId].adminList.Contains(emailTarget))
            {
                allGroups[groupId].adminList.Remove(emailTarget);
                DBFunctions.saveInfo(allGroups);
            }
        }

        public static void addGroupMember(int groupId, string emailTarget)
        {
            if (!allGroups[groupId].memberList.Contains(emailTarget))
            {
                allGroups[groupId].memberList.Add(emailTarget);
                DBFunctions.saveInfo(allGroups);
            }
        }

        public static void removeGroupMember(int groupId, string emailTarget)
        {
            if (allGroups[groupId].memberList.Contains(emailTarget))
            {
                allGroups[groupId].memberList.Remove(emailTarget);
                DBFunctions.saveInfo(allGroups);
            }
        }

        public static void addGroupCriterion(int groupId, string criterion)
        {
            if (!allGroups[groupId].customCriteriaList.Contains(criterion))
            {
                allGroups[groupId].customCriteriaList.Add(criterion);
                DBFunctions.saveInfo(allGroups);
            }
        }

        public static void removeGroupCriterion(int groupId, string criterion)
        {
            if (allGroups[groupId].customCriteriaList.Contains(criterion))
            {
                allGroups[groupId].customCriteriaList.Remove(criterion);
                DBFunctions.saveInfo(allGroups);
            }
        }

        public static void addGroupRestaurant(int groupId, int restaurantId)
        {
            if (!allGroups[groupId].restaurantList.Contains(restaurantId))
            {
                allGroups[groupId].restaurantList.Add(restaurantId);
                DBFunctions.saveInfo(allGroups);
            }
        }

        public static void removeGroupRestaurant(int groupId, int restaurantId)
        {
            if (allGroups[groupId].restaurantList.Contains(restaurantId))
            {
                allGroups[groupId].restaurantList.Remove(restaurantId);
                DBFunctions.saveInfo(allGroups);
            }
        }

        public static void addGroupEvent(int groupId, int eventId, long time, int resId, string comment)
        {
            if (getGroupEventExist(groupId, eventId) == -1)
            {
                EventInfo info = new EventInfo
                {
                    id = eventId,
                    time = time,
                    restaurantId = resId,
                    comment = comment,
                };

                if (!allGroups[groupId].eventList.Contains(info))
                {
                    allGroups[groupId].eventList.Add(info);
                    DBFunctions.saveInfo(allGroups);
                }
            }
        }

        public static void removeGroupEvent(int groupId, int eventId)
        {
            int index = getGroupEventExist(groupId, eventId);

            if (index != -1)
            {
                allGroups[groupId].eventList.RemoveAt(index);
                DBFunctions.saveInfo(allGroups);

                foreach (var memberEmail in allGroups[groupId].memberList)
                {
                    removeUserEvent(memberEmail, groupId, eventId);
                }
            }
        }

        // getters for user
        public static string getUserPassword(string email)
        {
            return allUsers[email].password;
        }

        public static string getUserDisplayName(string email)
        {
            return allUsers[email].name;
        }

        public static string getUserBio(string email)
        {
            return allUsers[email].bio;
        }

        public static List<string> getUserFriends(string email)
        {
            return allUsers[email].friendList;
        }

        public static List<string> getUserFriendRequests(string email)
        {
            return allUsers[email].friendReqList;
        }

        public static List<int> getUserGroups(string email)
        {
            return allUsers[email].groupList;
        }

        public static List<InvitationInfo> getUserGroupInvitations(string email)
        {
            return allUsers[email].invitationList;
        }

        public static List<CategoryInfo> getUserSavedCategories(string email)
        {
            return allUsers[email].categoryList;
        }

        public static List<UserEventInfo> getUserEvents(string email)
        {
            return allUsers[email].eventList;
        }

        // getters for user category
        public static string getUserCategoryName(string email, int catId)
        {
            return allUsers[email].categoryList[getCategoryExist(email, catId)].name;
        }

        public static List<int> getUserCategoryRestaurants(string email, int catId)
        {
            return allUsers[email].categoryList[getCategoryExist(email, catId)].restaurantList;
        }

        // getters for group
        public static string getGroupName(int groupId)
        {
            return allGroups[groupId].name;
        }

        public static List<string> getGroupAdmins(int groupId)
        {
            return allGroups[groupId].adminList;
        }

        public static List<string> getGroupMembers(int groupId)
        {
            return allGroups[groupId].memberList;
        }

        public static List<string> getGroupCustomCriteria(int groupId)
        {
            return allGroups[groupId].customCriteriaList;
        }

        public static List<int> getGroupSavedRestaurants(int groupId)
        {
            return allGroups[groupId].restaurantList;
        }

        public static List<MsgInfo> getGroupMessages(int groupId)
        {
            return allGroups[groupId].msgList;
        }

        public static List<EventInfo> getGroupEvents(int groupId)
        {
            return allGroups[groupId].eventList;
        }

        // getters for event
        public static long getEventTime(int groupId, int eventId)
        {
            return allGroups[groupId].eventList[getGroupEventExist(groupId, eventId)].time;
        }

        public static int getEventRestaurant(int groupId, int eventId)
        {
            return allGroups[groupId].eventList[getGroupEventExist(groupId, eventId)].restaurantId;
        }

        public static string getEventComment(int groupId, int eventId)
        {
            return allGroups[groupId].eventList[getGroupEventExist(groupId, eventId)].comment;
        }

        // getters for message
        public static string getMessageSender(int groupId, int msgId)
        {
            return allGroups[groupId].msgList[getGroupMsgExist(groupId, msgId)].senderEmail;
        }

        public static string getMessageContent(int groupId, int msgId)
        {
            return allGroups[groupId].msgList[getGroupMsgExist(groupId, msgId)].content;
        }

        public static long getMessageTime(int groupId, int msgId)
        {
            return allGroups[groupId].msgList[getGroupMsgExist(groupId, msgId)].time;
        }

        // getters for restaurant
        public static string getRestaurantName(int restaurantId)
        {
            return allRestaurants[restaurantId].name;
        }

        public static string getRestaurantAddress(int restaurantId)
        {
            return allRestaurants[restaurantId].address;
        }

        public static List<string> getRestaurantCriteria(int restaurantId)
        {
            return allRestaurants[restaurantId].criteriaList;
        }

        // Conditionals
        public static Boolean getUserExist(string email)
        {
            return allUsers.ContainsKey(email);
        }

        public static Boolean getTargetIsUserFriend(string emailUser, string emailTarget)
        {
            return allUsers[emailUser].friendList.Contains(emailTarget);
        }

        public static Boolean getGroupExist(int groupId)
        {
            return allGroups.ContainsKey(groupId);
        }

        // Conditionals with different types of arguments
        public static MsgInfo getGroupLastMsgInfo(int groupId)
        {
            int index = 0;
            for (int i = 1; i < allGroups[groupId].msgList.Count; i++)
            {
                if (allGroups[groupId].msgList[index].time < allGroups[groupId].msgList[i].time)
                {
                    index = i;
                }
            }

            return allGroups[groupId].msgList[index];
        }
        
        private static Tuple<int, Boolean> getUserCategoryHasRes(string email, int catId, int resId)
        {
            for (int i = 0; i < allUsers[email].categoryList.Count; i++)
            {
                if (allUsers[email].categoryList[i].id == catId)
                {
                    if (allUsers[email].categoryList[i].restaurantList.Contains(resId))
                    {
                        return new Tuple<int, Boolean>(i, true);
                    }
                    else
                    {
                        return new Tuple<int, Boolean>(i, false);
                    }
                }
            }

            return new Tuple<int, Boolean>(-1, false);
        }

        private static int getCategoryExist(string email, int catId)
        {
            for (int i = 0; i < allUsers[email].categoryList.Count; i++)
            {
                if (allUsers[email].categoryList[i].id == catId)
                {
                    return i;
                }
            }

            return -1;
        }

        private static int getGroupMsgExist(int groupId, int msgId)
        {
            for (int i = 0; i < allGroups[groupId].msgList.Count; i++)
            {
                if (allGroups[groupId].msgList[i].id == msgId)
                {
                    return i;
                }
            }

            return -1;
        }

        private static int getGroupEventExist(int groupId, int eventId)
        {
            for (int i = 0; i < allGroups[groupId].eventList.Count; i++)
            {
                if (allGroups[groupId].msgList[i].id == eventId)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
