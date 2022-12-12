using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Interop;
using System.Windows.Threading;
using System.Xml.Linq;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class SessionData
    {

        private static string currentUser = "";
        private static int currentGroupId = -1;
        private static List<string> currentInviteTargets = new List<string>();
        private static Dictionary<string, UserInfo> allUsers;
        private static Dictionary<int, GroupInfo> allGroups;
        private static Dictionary<int, RestaurantInfo> allRestaurants;
        private static Dictionary<int, PresetCriteriaInfo> allPresetCriteria;

        private static List<long> suggestedEventTimes;

        private static int currentCatId;
        private static int currentResId;

        private static DispatcherTimer timer;

        public static void stopTimer()
        {
            timer.Stop();
            while (timer.IsEnabled) ;
        }

        public static void startTimer()
        {
            timer.Start();
        }

        public static void setCurrentCatId(int catId)
        {
            currentCatId = catId;
        }

        public static void setCurrentResId(int resId)
        {
            currentResId = resId;
        }

        public static int getCurrentCatId()
        {
            return currentCatId;
        }

        public static int getCurrentResId()
        {
            return currentResId;
        }

        public static void initializeStartup()
        {
            allUsers = DBFunctions.getAllUserInfo();
            allGroups = DBFunctions.getAllGroupInfo();
            allRestaurants = DBFunctions.getAllRestaurantInfo();
            allPresetCriteria = DBFunctions.getAllCriteriaInfo();

            suggestedEventTimes = new List<long>();
            timer = new DispatcherTimer();
            timer.Tick += timeSpent;
            timer.Interval = new TimeSpan(0, 0, 0, 3);
            timer.Start();
        }

        private static void timeSpent(Object source, EventArgs e)
        {
            updateUserInfoFromDB();
            updateGroupInfoFromDB();
            ComponentFunctions.refreshAll();
        }

        public static void loginUser(string emailUser)
        {
            currentUser = emailUser;
        }

        public static string getCurrentUser()
        {
            return currentUser;
        }

        public static void setCurrentGroupId(int groupId)
        {
            currentGroupId = groupId;
        }

        public static int getCurrentGroupId()
        {
            return currentGroupId;
        }

        // setters for user
        public static void createUser(string emailUser, string password)
        {
            UserInfo info = new UserInfo(emailUser, password);

            allUsers[emailUser] = info;
        }

        public static void addUserNewGroup(string emailCreator, int groupId, string name)
        {
            createGroup(groupId, name);
            addGroupMemberToAdmin(groupId, emailCreator);
            addUserGroup(emailCreator, groupId);
            addGroupMember(groupId, emailCreator);
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
            }
        }

        public static void removeUserFriendReq(string emailUser, string emailTarget)
        {
            if (allUsers[emailUser].friendReqList.Contains(emailTarget))
            {
                allUsers[emailUser].friendReqList.Remove(emailTarget);
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
                    restaurantList = new Dictionary<int, string>(),
                };

                allUsers[emailUser].categoryList.Add(info);
            }
        }

        public static void removeUserCategory(string emailUser, int categoryId)
        {
            int index = getCategoryExist(emailUser, categoryId);
            if (index != -1)
            {
                allUsers[emailUser].categoryList.RemoveAt(index);
            }
        }

        public static void addUserGroup(string emailUser, int groupId)
        {
            if (!allUsers[emailUser].groupList.Contains(groupId))
            {
                allUsers[emailUser].groupList.Add(groupId);
                // delete all invitations that invites to the added groupId
                allUsers[emailUser].invitationList.RemoveAll(invite => invite.inviteGroupId.Equals(groupId));
            }
        }

        public static void removeUserGroup(string emailUser, int groupId)
        {
            if (allUsers[emailUser].groupList.Contains(groupId))
            {
                allUsers[emailUser].groupList.Remove(groupId);
            }
        }

        public static void addUserEvent(string emailUser, int groupId, int eventId)
        {
            UserEventInfo eventInfo = new UserEventInfo { groupId = groupId, eventId = eventId };

            if (!allUsers[emailUser].eventList.Contains(eventInfo))
            {
                allUsers[emailUser].eventList.Add(eventInfo);
            }

            var eventIndex = getGroupEventExist(groupId, eventId);
            if (eventIndex != -1)
            {
                if (allGroups[groupId].eventList[eventIndex].denied.Contains(emailUser))
                {
                    allGroups[groupId].eventList[eventIndex].denied.Remove(emailUser);
                }

                if (!allGroups[groupId].eventList[eventIndex].attendees.Contains(emailUser))
                {
                    allGroups[groupId].eventList[eventIndex].attendees.Add(emailUser);
                }
            }
        }

        public static void removeUserEvent(string emailUser, int groupId, int eventId)
        {
            UserEventInfo eventInfo = new UserEventInfo { groupId = groupId, eventId = eventId };

            if (allUsers[emailUser].eventList.Contains(eventInfo))
            {
                allUsers[emailUser].eventList.Remove(eventInfo);
            }

            var eventIndex = getGroupEventExist(groupId, eventId);
            if (eventIndex != -1)
            {
                if (allGroups[groupId].eventList[eventIndex].attendees.Contains(emailUser))
                {
                    allGroups[groupId].eventList[eventIndex].attendees.Remove(emailUser);
                }

                if (!allGroups[groupId].eventList[eventIndex].denied.Contains(emailUser))
                {
                    allGroups[groupId].eventList[eventIndex].denied.Add(emailUser);
                }
            }
        }

        public static void addUserRestaurant(string emailUser, int catId, int resId)
        {
            Tuple<int, Boolean> index = getUserCategoryHasRes(emailUser, catId, resId);
            if ((index.Item1 != -1) && (index.Item2 == false))
            {
                allUsers[emailUser].categoryList[index.Item1].restaurantList.Add(resId, "");
            }
        }

        public static void removeUserRestaurant(string emailUser, int catId, int resId)
        {
            Tuple<int, Boolean> index = getUserCategoryHasRes(emailUser, catId, resId);
            if (index.Item2 == true)
            {
                allUsers[emailUser].categoryList[index.Item1].restaurantList.Remove(resId);
            }
        }

        public static void editUserResNotes(string emailUser, int catId, int resId, string note)
        {
            allUsers[emailUser].categoryList[catId].restaurantList[resId] = note;
        }

        public static string getUserResNotes(string emailUser, int catId, int resId)
        {
            return allUsers[emailUser].categoryList[catId].restaurantList[resId];
        }

        public static void removeUserGroupInvite(string emailUser, int groupId, string emailSender)
        {
            InvitationInfo info = new InvitationInfo { inviteGroupId = groupId, inviteSenderEmail = emailSender };
            if (allUsers[emailUser].invitationList.Contains(info))
            {
                allUsers[emailUser].invitationList.Remove(info);
            }
        }

        // these ones are different from the above that the user alters target's information
        public static void addUserFriendReqToTarget(string emailUser, string emailTarget)
        {
            if (!allUsers[emailTarget].friendReqList.Contains(emailUser))
            {
                allUsers[emailTarget].friendReqList.Add(emailUser);
            }
        }

        public static void sendGroupInviteToTarget(string emailTarget, int groupId, string emailSender)
        {
            if (getUserExist(emailTarget))
            {
                InvitationInfo info = new InvitationInfo { inviteGroupId = groupId, inviteSenderEmail = emailSender };
                if (!allUsers[emailTarget].invitationList.Contains(info))
                {
                    allUsers[emailTarget].invitationList.Add(info);
                }
            }
        }

        public static void addTargetToInviteGroupList(string emailTarget)
        {
            currentInviteTargets.Add(emailTarget);
        }

        public static void removeTargetFromInviteGroupList(string emailTarget)
        {
            currentInviteTargets.Remove(emailTarget);
        }

        public static void removeInviteTargetList()
        {
            currentInviteTargets.Clear();
        }

        public static void setUserPassword(string email, string password)
        {
            allUsers[email].name = password;
        }

        public static void setUserDisplayName(string email, string name)
        {
            allUsers[email].name = name;
        }

        public static void setUserBio(string email, string bio)
        {
            allUsers[email].bio = bio;
        }

        public static void setCategoryName(string email, int catId, string name)
        {
            allUsers[email].categoryList[catId].name = name;
        }

        // setters for group/event
        public static void createGroup(int groupId, string groupName)
        {
            GroupInfo info = new GroupInfo(groupName);

            allGroups[groupId] = info;
        }

        public static void deleteGroup(int groupId)
        {
            if (allGroups.ContainsKey(groupId))
            {
                allGroups.Remove(groupId);

                // delete all events in each user?
                foreach (var user in allUsers)
                {
                    user.Value.eventList.RemoveAll(ev => ev.groupId.Equals(groupId));
                }
            }
        }

        public static void addGroupMsg(int groupId, string msgSender, string msgContent)
        {
            int msgId = getFirstAvailableMsgId(groupId);
            MsgInfo msg = new MsgInfo(msgId, msgSender, msgContent);

            allGroups[groupId].msgList.Add(msg);
        }

        public static void addGroupMsg(int groupId, int eventId)
        {
            int msgId = getFirstAvailableMsgId(groupId);
            MsgInfo msg = new MsgInfo(msgId, groupId, eventId);

            allGroups[groupId].msgList.Add(msg);
        }

        public static void removeGroupMsg(int groupId, int msgId)
        {
            MsgInfo info = new MsgInfo(msgId);
            if (allGroups[groupId].msgList.Contains(info))
            {
                allGroups[groupId].msgList.Remove(info);
            }
        }

        public static void addGroupMemberToAdmin(int groupId, string emailTarget)
        {
            if (!allGroups[groupId].adminList.Contains(emailTarget))
            {
                allGroups[groupId].adminList.Add(emailTarget);
            }
        }

        public static void removeGroupMemberFromAdmin(int groupId, string emailTarget)
        {
            if (allGroups[groupId].adminList.Contains(emailTarget))
            {
                allGroups[groupId].adminList.Remove(emailTarget);
            }
        }

        public static void addGroupMember(int groupId, string emailTarget)
        {
            if (!allGroups[groupId].memberList.Contains(emailTarget))
            {
                allGroups[groupId].memberList.Add(emailTarget);
                addGroupMsg(groupId, "", emailTarget + " has joined the group.");
            }
        }

        public static void removeGroupMember(int groupId, string emailTarget)
        {
            if (allGroups[groupId].memberList.Contains(emailTarget))
            {
                allGroups[groupId].memberList.Remove(emailTarget);
            }
        }

        public static void addGroupCriterion(int groupId, string email, int criterionId)
        {
            if (!allGroups[groupId].customCriteriaList.ContainsKey(email))
            {
                allGroups[groupId].customCriteriaList.Add(email, criterionId);
            }
        }

        public static void removeGroupCriterion(int groupId, string email)
        {
            if (allGroups[groupId].customCriteriaList.ContainsKey(email))
            {
                allGroups[groupId].customCriteriaList.Remove(email);
            }
        }

        public static Dictionary<int, PresetCriteriaInfo> getAllPresetCriteria()
        {
            return allPresetCriteria;
        }

        public static string getCriterionName(int criterionId)
        {
            return allPresetCriteria[criterionId].criteria;
        }

        public static void addGroupRestaurant(int groupId, int restaurantId)
        {
            if (!allGroups[groupId].restaurantList.Contains(restaurantId))
            {
                allGroups[groupId].restaurantList.Add(restaurantId);
            }
        }

        public static void addGroupVote(int groupId, int resId)
        {

            if (getVoteInfoExist(groupId, resId) == -1)
            {
                VoteInfo voteInfo = new VoteInfo
                {
                    resId = resId,
                    usersVoted = new List<string>(),
                };
                allGroups[groupId].voteInfo.Add(voteInfo);
                //addGroupMsg(groupId, "", emailTarget + " has joined the group.");
            }

        }

        public static void addGroupVote(int groupId, string resId, string emailUser)
        {
            addGroupVote(groupId, Int32.Parse(resId));
        }

        private static int getVoteInfoExist(int groupId, int restId)
        {
            for (int i = 0; i < allGroups[groupId].voteInfo.Count; i++)
            {
                if (allGroups[groupId].voteInfo[i].resId == restId)
                {
                    return i;
                }
            }
            return -1;
        }


        private static Tuple<int, Boolean> getVoteInfoUserHasVote(int groupId, int resId, string emailUser)
        {
            for (int i = 0; i < allGroups[groupId].voteInfo.Count; i++)
            {
                if (allGroups[groupId].voteInfo[i].resId == resId)
                {
                    if (allGroups[groupId].voteInfo[i].usersVoted.Contains(emailUser))
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

        public static int getVoteCountRestaurant(int groupId, int resId)
        {
            for (int i = 0; i < allGroups[groupId].voteInfo.Count; i++)
            {
                if (allGroups[groupId].voteInfo[i].resId == resId)
                {
                    return allGroups[groupId].voteInfo[i].usersVoted.Count;
                }
            }
            return 0;
        }

        public static int getNumberOfGroupMembers(int groupId, int resId)
        {
            return allGroups[groupId].memberList.Count;
        }

        public static void addUserVote(int groupId, int resId, string emailUser)
        {
            Tuple<int, Boolean> index = getVoteInfoUserHasVote(groupId, resId, emailUser);
            if ((index.Item1 != -1) && (index.Item2 == false))
            {
                allGroups[groupId].voteInfo[index.Item1].usersVoted.Add(emailUser);
            }
        }

        public static void removeUserVote(int groupId, int resId, string emailUser)
        {
            Tuple<int, Boolean> index = getVoteInfoUserHasVote(groupId, resId, emailUser);
            if ((index.Item1 != -1) && (index.Item2 == true))
            {
                allGroups[groupId].voteInfo[index.Item1].usersVoted.Remove(emailUser);
            }
        }

        public static bool getHasUserVoted(int groupId, int resId, string emailUser)
        {
            Tuple<int, Boolean> index = getVoteInfoUserHasVote(groupId, resId, emailUser);
            if ((index.Item1 != -1) && (index.Item2 == true))
            {
                return true;

            }
            return false;
        }


        /*
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
        }*/



        //public static void addGroupVote(int groupId, string resId, string emailUser)
        //{
        //    addGroupVote(emailUser, Int32.Parse(resId), emailUser);
        //}




        /*
         * public static void addUserRestaurant(string emailUser, int catId, int resId)
        {
            Tuple<int, Boolean> index = getUserCategoryHasRes(emailUser, catId, resId);
            if ((index.Item1 != -1) && (index.Item2 == false))
            {
                allUsers[emailUser].categoryList[index.Item1].restaurantList.Add(resId, "");
            }
        }
         * 
         * 
        public static void removeUserVote(string emailUser, int resId, int resId)
        {
            Tuple<int, Boolean> index = getUserCategoryHasRes(emailUser, catId, resId);
            if (index.Item2 == true)
            {
                allUsers[emailUser].categoryList[index.Item1].restaurantList.Remove(resId);
            }
        }*/


        /*
        private static Tuple<int, Boolean> getUserCategoryHasRes(string email, int catId, int resId)
        {
            for (int i = 0; i < allUsers[email].categoryList.Count; i++)
            {
                if (allUsers[email].categoryList[i].id == catId)
                {
                    if (allUsers[email].categoryList[i].restaurantList.ContainsKey(resId))
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

        /*
         * 
         * public static string getUserCategoryName(string email, int catId)
        {
            return allUsers[email].categoryList[getCategoryExist(email, catId)].name;
        }
         * 
         * public static void addGroupCriterion(int groupId, string email, int criterionId)
        {
            if (!allGroups[groupId].customCriteriaList.ContainsKey(email))
            {
                allGroups[groupId].customCriteriaList.Add(email, criterionId);
            }
        }

         * 
         * 
         * public static void addUserCategory(string emailUser, int categoryId, string name)
        {
            if (getCategoryExist(emailUser, categoryId) == -1)
            {
                CategoryInfo info = new CategoryInfo
                {
                    id = categoryId,
                    name = name,
                    restaurantList = new Dictionary<int, string>(),
                };

                allUsers[emailUser].categoryList.Add(info);
            }
        }
         * 
         * public static void addUserFriend(string emailUser, string emailTarget)
        {
            if (!allUsers[emailUser].friendList.Contains(emailTarget))
            {
                allUsers[emailUser].friendList.Add(emailTarget);
                addUserFriend(emailTarget, emailUser);
                removeUserFriendReq(emailUser, emailTarget);
            }
        }

          public static void addGroupMember(int groupId, string emailTarget)
        {
            if (!allGroups[groupId].memberList.Contains(emailTarget))
            {
                allGroups[groupId].memberList.Add(emailTarget);
                addGroupMsg(groupId, "", emailTarget + " has joined the group.");
            }
        }

        public static void addGroupMsg(int groupId, string msgSender, string msgContent)
        {
            int msgId = getFirstAvailableMsgId(groupId);
            MsgInfo msg = new MsgInfo
            {
                id = msgId,
                senderEmail = msgSender,
                content = msgContent,
                time = getEpochFromDateOrTime(DateTime.Now),
            };

            allGroups[groupId].msgList.Add(msg);
            allGroups[groupId].msgList.Sort((m1, m2) => m1.time.CompareTo(m2.time)); // always sort messages depending on time
        }

         * 
         */

        public static void removeGroupRestaurant(int groupId, int restaurantId)
        {
            if (allGroups[groupId].restaurantList.Contains(restaurantId))
            {
                allGroups[groupId].restaurantList.Remove(restaurantId);
            }
        }

        public static void addGroupEvent(int groupId, int eventId, long time, int resId, string comment)
        {
            if (getGroupEventExist(groupId, eventId) == -1)
            {
                EventInfo info = new EventInfo(eventId, time, resId, comment);

                if (!allGroups[groupId].eventList.Contains(info))
                {
                    allGroups[groupId].eventList.Add(info);
                    addGroupMsg(groupId, eventId);
                }
            }
        }

        public static void removeGroupEvent(int groupId, int eventId)
        {
            int index = getGroupEventExist(groupId, eventId);

            if (index != -1)
            {
                allGroups[groupId].eventList.RemoveAt(index);

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

        public static Dictionary<int,string> getUserCategoryRestaurants(string email, int catId)
        {
            return allUsers[email].categoryList[getCategoryExist(email, catId)].restaurantList;
        }

        public static List<string> getTargetsToInviteToGroup()
        {
            return currentInviteTargets;
        }

        // getters for group
        public static string getGroupName(int groupId)
        {
            if (groupId == -1)
            {
                return "";
            }
            return allGroups[groupId].name;
        }

        public static List<string> getGroupAdmins(int groupId)
        {
            if (groupId == -1)
            {
                return new List<string>();
            }
            return allGroups[groupId].adminList;
        }

        public static List<string> getGroupMembers(int groupId)
        {
            if (groupId == -1)
            {
                return new List<string>();
            }
            return allGroups[groupId].memberList;
        }

        public static Dictionary<string, int> getGroupCustomCriteria(int groupId)
        {
            if (groupId == -1)
            {
                return new Dictionary<string, int>();
            }
            return allGroups[groupId].customCriteriaList;
        }

        public static List<int> getGroupSavedRestaurants(int groupId)
        {
            if (groupId == -1)
            {
                return new List<int>();
            }
            return allGroups[groupId].restaurantList;
        }

        public static List<MsgInfo> getGroupMessages(int groupId)
        {
            if (groupId == -1)
            {
                return new List<MsgInfo>();
            }
            return allGroups[groupId].msgList;
        }

        public static List<EventInfo> getGroupEvents(int groupId)
        {
            if (groupId == -1)
            {
                return new List<EventInfo>();
            }
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

        public static List<int> getRestaurantCriteria(int restaurantId)
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
            return allGroups[groupId].msgList.Last();
        }
        
        private static Tuple<int, Boolean> getUserCategoryHasRes(string email, int catId, int resId)
        {
            for (int i = 0; i < allUsers[email].categoryList.Count; i++)
            {
                if (allUsers[email].categoryList[i].id == catId)
                {
                    if (allUsers[email].categoryList[i].restaurantList.ContainsKey(resId))
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

        public static int getGroupEventExist(int groupId, int eventId)
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

        public static long getEpochFromDateOrTime(DateTime date)
        {
            DateTimeOffset offset = new DateTimeOffset(date);

            return offset.ToUnixTimeMilliseconds();
        }

        public static string convertDateTimeToString(DateTime epochDateTime)
        {
            string dateOrTime;

            if (epochDateTime.Date < DateTime.Now.Date)
            {
                // at least 1 day has passed; only show date
                dateOrTime = epochDateTime.ToString("MM-dd", new CultureInfo("en-US"));
            }
            else
            {
                dateOrTime = epochDateTime.ToString("hh:mm tt", new CultureInfo("en-US"));
            }

            return dateOrTime;
        }

        public static string convertEventDateTimeToString(DateTime epochDateTime)
        {
            string dateOrTime;

            dateOrTime = epochDateTime.ToString("YYYY-MM-dd hh:mm tt", new CultureInfo("en-US"));

            return dateOrTime;
        }

        public static DateTime getDateOrTimefromEpoch(long epochTime)
        {
            DateTimeOffset timeoff = DateTimeOffset.FromUnixTimeMilliseconds(epochTime);

            return timeoff.DateTime.ToLocalTime();
        }

        public static string getDateTimeStringfromEpoch(long epochTime)
        {
            return convertDateTimeToString(getDateOrTimefromEpoch(epochTime));
        }

        public static int getFirstAvailableEventId(int groupId)
        {
            SortedSet<int> allIds = new SortedSet<int>();

            foreach(var id in allGroups[groupId].eventList)
            {
                allIds.Add(id.id);
            }

            return getFirstAvailableId(allIds);
        }

        public static int getFirstAvailableCategoryId(string email)
        {
            SortedSet<int> allIds = new SortedSet<int>();

            foreach (var id in allUsers[email].categoryList)
            {
                allIds.Add(id.id);
            }

            return getFirstAvailableId(allIds);
        }

        public static int getFirstAvailableMsgId(int groupId)
        {
            SortedSet<int> allIds = new SortedSet<int>();

            foreach (var id in allGroups[groupId].msgList)
            {
                allIds.Add(id.id);
            }

            return getFirstAvailableId(allIds);
        }

        public static int getFirstAvailableGroupId()
        {
            int index;
            for (index = 0; allGroups.ContainsKey(index); index++) ;

            return index;
        }

        private static int getFirstAvailableId(SortedSet<int> allIds)
        {
            int returnId = 0;
            foreach (var id in allIds)
            {
                if (id != returnId)
                {
                    break;
                }

                returnId++;
            }

            return returnId;
        }

        public static void addEventCustomTime(int groupId, long eventTime)
        {
            if (!allGroups[groupId].suggestedTimes.Contains(eventTime))
            {
                allGroups[groupId].suggestedTimes.Add(eventTime);
            }
        }

        public static void removeEventCustomTime(int groupId, long eventTime)
        {
            if (allGroups[groupId].suggestedTimes.Contains(eventTime))
            {
                allGroups[groupId].suggestedTimes.RemoveAll(a => (a == eventTime));
            }
        }

        public static void addEventSuggestTime(long eventTime)
        {
            suggestedEventTimes.Add(eventTime);
        }

        public static void removeEventSuggestTime(long eventTime)
        {
            suggestedEventTimes.Remove(eventTime);
        }

        public static void addUserDietaryChecked(string email, int criterionId)
        {
            if (!allUsers[email].criteriaChecked.Contains(criterionId))
            {
                allUsers[email].criteriaChecked.Add(criterionId);
            }
        }

        public static void addUserDietaryUnchecked(string email, int criterionId)
        {
            if (allUsers[email].criteriaChecked.Contains(criterionId))
            {
                allUsers[email].criteriaChecked.Remove(criterionId);
            }
        }

        public static List<int> getUserDietaryChecked(string email) {
            return allUsers[email].criteriaChecked;
        }

        public static Boolean getTargetIsPendingInvite(int groupId, string emailUser, string emailTarget)
        {
            InvitationInfo info = new InvitationInfo { inviteGroupId = groupId, inviteSenderEmail = emailUser };
            return allUsers[emailTarget].invitationList.Contains(info);
        }

        public static Boolean getTargetIsGroupAdmin(int groupId, string email)
        {
            return allGroups[groupId].adminList.Contains(email);
        }

        public static List<long> getEventCustomTimesOnGroupDate(int groupId)
        {
            return allGroups[groupId].suggestedTimes;
        }

        public static List<int> getUserAllRestaurantsNotSaved(string email)
        {
            List<int> restaurantsNotSaved = new List<int>();
            var allRes = allUsers[email].categoryList[getCurrentCatId()].restaurantList;

            for (int i = 0; i < allRestaurants.Count; i++)
            {
                if (!allRes.ContainsKey(i))
                {
                    restaurantsNotSaved.Add(i);
                }
            }

            return restaurantsNotSaved;
        }

        public static List<int> getAllRestaurantsNotSaved(int groupId)
        {
            List<int> restaurantsNotSaved = new List<int>();
            var allRes = allGroups[groupId].restaurantList;

            for (int i = 0; i < allRestaurants.Count; i++)
            {
                if (!allRes.Contains(i))
                {
                    restaurantsNotSaved.Add(i);
                }
            }

            return restaurantsNotSaved;
        }

        public static List<int> getAllRestaurantsNotSaved(string groupId)
        {
            return getAllRestaurantsNotSaved(Int32.Parse(groupId));
        }

        public static List<long> getEventCustomTimesOnGroupDate(string groupId)
        {
            return getEventCustomTimesOnGroupDate(Int32.Parse(groupId));
        }

        public static Boolean getTargetIsPendingInvite(string groupId, string emailUser, string emailTarget)
        {
            return getTargetIsPendingInvite(Int32.Parse(groupId), emailUser, emailTarget);
        }

        public static Boolean getTargetIsGroupAdmin(string groupId, string email)
        {
            return getTargetIsGroupAdmin(Int32.Parse(groupId), email);
        }

        public static void addUserCategory(string emailUser, string categoryId, string name)
        {
            addUserCategory(emailUser, Int32.Parse(categoryId), name);
        }

        public static void addUserEvent(string emailUser, int groupId, string eventId)
        {
            addUserEvent(emailUser, groupId, Int32.Parse(eventId));
        }

        public static void addUserEvent(string emailUser, string groupId, int eventId)
        {
            addUserEvent(emailUser, Int32.Parse(groupId), eventId);
        }

        public static void addUserEvent(string emailUser, string groupId, string eventId)
        {
            addUserEvent(emailUser, Int32.Parse(groupId), Int32.Parse(eventId));
        }

        public static void removeUserEvent(string emailUser, int groupId, string eventId)
        {
            removeUserEvent(emailUser, groupId, Int32.Parse(eventId));
        }

        public static void removeUserEvent(string emailUser, string groupId, int eventId)
        {
            removeUserEvent(emailUser, Int32.Parse(groupId), eventId);
        }

        public static void removeUserEvent(string emailUser, string groupId, string eventId)
        {
            removeUserEvent(emailUser, Int32.Parse(groupId), Int32.Parse(eventId));
        }

        public static void addUserRestaurant(string emailUser, int catId, string resId)
        {
            addUserRestaurant(emailUser, catId, Int32.Parse(resId));
        }

        public static void addUserRestaurant(string emailUser, string catId, int resId)
        {
            addUserRestaurant(emailUser, Int32.Parse(catId), resId);
        }

        public static void addUserRestaurant(string emailUser, string catId, string resId)
        {
            addUserRestaurant(emailUser, Int32.Parse(catId), Int32.Parse(resId));
        }

        public static void removeUserRestaurant(string emailUser, int catId, string resId)
        {
            removeUserRestaurant(emailUser, catId, Int32.Parse(resId));
        }

        public static void removeUserRestaurant(string emailUser, string catId, int resId)
        {
            removeUserRestaurant(emailUser, Int32.Parse(catId), resId);
        }

        public static void removeUserRestaurant(string emailUser, string catId, string resId)
        {
            removeUserRestaurant(emailUser, Int32.Parse(catId), Int32.Parse(resId));
        }

        public static void setCurrentGroupId(string groupId)
        {
            setCurrentGroupId(Int32.Parse(groupId));
        }

        public static void addGroupCriterion(int groupId, string email, string criterionId)
        {
            addGroupCriterion(groupId, email, Int32.Parse(criterionId));
        }

        public static void addGroupCriterion(string groupId, string email, int criterionId)
        {
            addGroupCriterion(Int32.Parse(groupId), email, criterionId);
        }

        public static void addGroupCriterion(string groupId, string email, string criterionId)
        {
            addGroupCriterion(Int32.Parse(groupId), email, Int32.Parse(criterionId));
        }

        public static void removeGroupCriterion(string groupId, string email)
        {
            removeGroupCriterion(Int32.Parse(groupId), email);
        }

        public static string getCriterionName(string criterionId)
        {
            return getCriterionName(Int32.Parse(criterionId));
        }

        public static int getEventRestaurant(string groupId, string eventId)
        {
            return getEventRestaurant(Int32.Parse(groupId), Int32.Parse(eventId));
        }

        public static void addEventCustomTime(int groupId, string eventTime)
        {
            addEventCustomTime(groupId, long.Parse(eventTime));
        }

        public static void addEventCustomTime(string groupId, long eventTime)
        {
            addEventCustomTime(Int32.Parse(groupId), eventTime);
        }

        public static void addEventCustomTime(string groupId, string eventTime)
        {
            addEventCustomTime(Int32.Parse(groupId), long.Parse(eventTime));
        }

        public static void removeEventCustomTime(int groupId, string eventTime)
        {
            removeEventCustomTime(groupId, long.Parse(eventTime));
        }

        public static void removeEventCustomTime(string groupId, long eventTime)
        {
            removeEventCustomTime(Int32.Parse(groupId), eventTime);
        }

        public static void removeEventCustomTime(string groupId, string eventTime)
        {
            removeEventCustomTime(Int32.Parse(groupId), long.Parse(eventTime));
        }

        public static void addEventSuggestTime(string eventTime)
        {
            addEventSuggestTime(long.Parse(eventTime));
        }

        public static void removeEventSuggestTime(string eventTime)
        {
            removeEventSuggestTime(long.Parse(eventTime));
        }

        public static void updateUserInfoFromDB()
        {
            allUsers = allUsers.Concat(DBFunctions.getAllUserInfo()).GroupBy(keyval => keyval.Key).ToDictionary(keyval => keyval.Key, keyval => keyval.Last().Value);
        }

        public static void updateGroupInfoFromDB()
        {
            allGroups = allGroups.Concat(DBFunctions.getAllGroupInfo()).GroupBy(keyval => keyval.Key).ToDictionary(keyval => keyval.Key, keyval => keyval.Last().Value);
        }

        public static void saveUserInfoToDB()
        {
            DBFunctions.saveInfo(allUsers);
        }

        public static void saveGroupInfoToDB()
        {
            DBFunctions.saveInfo(allGroups);
        }
    }
}
