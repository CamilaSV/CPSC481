using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class SessionData_User
    {
        private static Dictionary<string, UserInfo> allUsers;

        public static void initializeStartup()
        {
            allUsers = DBFunctions.getAllUserInfo();
        }

        // getters
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

        public static List<string> getUserGroups(string email)
        {
            return allUsers[email].groupList;
        }

        public static List<InvitationInfo> getUserGroupInvitations(string email)
        {
            return allUsers[email].invitationList;
        }

        public static List<string> getUserEvents(string email)
        {
            return allUsers[email].eventList;
        }

        public static List<string> getUserSavedCategories(string email)
        {
            return allUsers[email].categoryList;
        }

        public static List<UserCatResInfo> getUserSavedRestaurants(string email)
        {
            return allUsers[email].restaurantList;
        }

        // setters
        public static void createUser(string email, string password)
        {
            UserInfo info = new UserInfo
            {
                password = password,
                name = email,
                bio = "",
                friendList = new List<string>(),
                friendReqList = new List<string>(),
                groupList = new List<string>(),
                eventList = new List<string>(),
                categoryList = new List<string>(),
                restaurantList = new List<UserCatResInfo>(),
                invitationList = new List<InvitationInfo>(),
            };

            allUsers.Add(email, info);
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

        public static void addUserFriend(string emailUser, string emailTarget)
        {
            allUsers[emailUser].friendList.Add(emailTarget);
            removeUserFriendReq(emailUser, emailTarget);
        }

        public static void removeUserFriend(string emailUser, string emailTarget)
        {
            allUsers[emailUser].friendList.Remove(emailTarget);
        }

        public static void removeUserFriendReq(string emailUser, string emailTarget)
        {
            allUsers[emailUser].friendReqList.Remove(emailTarget);
        }

        public static void addGroup(string emailUser, string groupId)
        {
            if (!allUsers[emailUser].groupList.Contains(groupId))
            {
                allUsers[emailUser].groupList.Add(groupId);
                // delete all invitations that invites to the added groupId
                allUsers[emailUser].invitationList.RemoveAll(invite => invite.inviteGroupId.Equals(groupId));
            }
        }

        public static void removeGroup(string emailUser, string groupId)
        {
            allUsers[emailUser].groupList.Remove(groupId);
        }

        public static void addEvent(string emailUser, string eventId)
        {
            if (!allUsers[emailUser].eventList.Contains(eventId))
            {
                allUsers[emailUser].eventList.Add(eventId);
            }
        }

        public static void removeEvent(string emailUser, string eventId)
        {
            allUsers[emailUser].eventList.Remove(eventId);
        }

        public static void addCategory(string emailUser, string categoryId)
        {
            if (!allUsers[emailUser].categoryList.Contains(categoryId))
            {
                allUsers[emailUser].categoryList.Add(categoryId);
            }
        }

        public static void removeCategory(string emailUser, string categoryId)
        {
            allUsers[emailUser].categoryList.Remove(categoryId);
            // delete all restaurants that belongs to the categoryId
            allUsers[emailUser].restaurantList.RemoveAll(info => info.categoryId.Equals(categoryId));
        }

        public static void addRestaurant(string emailUser, string categoryId, string restaurantId)
        {
            UserCatResInfo info = new UserCatResInfo { categoryId = categoryId, restaurantId = restaurantId };
            if (!allUsers[emailUser].restaurantList.Contains(info))
            {
                allUsers[emailUser].restaurantList.Add(info);
            }
        }

        public static void removeRestaurant(string emailUser, string categoryId, string restaurantId)
        {
            UserCatResInfo info = new UserCatResInfo { categoryId = categoryId, restaurantId = restaurantId };
            allUsers[emailUser].restaurantList.Remove(info);
        }

        public static void removeUserGroupInvite(string emailUser, string emailTarget, string groupId)
        {
            InvitationInfo info = new InvitationInfo { inviteGroupId = groupId, inviteSenderEmail = emailTarget };
            allUsers[emailUser].invitationList.Remove(info);
        }

        // these ones are different from the above that the user alters target's information
        public static void addUserFriendReqToTarget(string emailUser, string emailTarget)
        {
            if (!allUsers[emailTarget].friendReqList.Contains(emailUser))
            {
                allUsers[emailTarget].friendReqList.Add(emailUser);
            }
        }

        public static void addUserGroupInviteToTarget(string emailUser, string emailTarget, string groupId)
        {
            InvitationInfo info = new InvitationInfo { inviteGroupId = groupId, inviteSenderEmail = emailUser };
            if (!allUsers[emailTarget].invitationList.Contains(info))
            {
                allUsers[emailTarget].invitationList.Add(info);
            }
        }

        // different types of arguments
        public static void addGroup(string emailUser, int groupId)
        {
            addGroup(emailUser, groupId.ToString());
        }

        public static void removeGroup(string emailUser, int groupId)
        {
            removeGroup(emailUser, groupId.ToString());
        }

        public static void addEvent(string emailUser, int eventId)
        {
            addEvent(emailUser, eventId.ToString());
        }

        public static void removeEvent(string emailUser, int eventId)
        {
            removeEvent(emailUser, eventId.ToString());
        }

        public static void addCategory(string emailUser, int categoryId)
        {
            addCategory(emailUser, categoryId.ToString());
        }

        public static void removeCategory(string emailUser, int categoryId)
        {
            removeCategory(emailUser, categoryId.ToString());
        }

        public static void addRestaurant(string emailUser, string categoryId, int restaurantId)
        {
            addRestaurant(emailUser, categoryId.ToString(), restaurantId.ToString());
        }

        public static void addRestaurant(string emailUser, int categoryId, string restaurantId)
        {
            addRestaurant(emailUser, categoryId.ToString(), restaurantId.ToString());
        }

        public static void addRestaurant(string emailUser, int categoryId, int restaurantId)
        {
            addRestaurant(emailUser, categoryId.ToString(), restaurantId.ToString());
        }

        public static void removeRestaurant(string emailUser, string categoryId, int restaurantId)
        {
            removeRestaurant(emailUser, categoryId.ToString(), restaurantId.ToString());
        }

        public static void removeRestaurant(string emailUser, int categoryId, string restaurantId)
        {
            removeRestaurant(emailUser, categoryId.ToString(), restaurantId.ToString());
        }

        public static void removeRestaurant(string emailUser, int categoryId, int restaurantId)
        {
            removeRestaurant(emailUser, categoryId.ToString(), restaurantId.ToString());
        }

        public static void removeUserGroupInvite(string emailUser, string emailTarget, int groupId)
        {
            removeUserGroupInvite(emailUser, emailTarget, groupId.ToString());
        }

        public static void addUserGroupInviteToTarget(string emailUser, string emailTarget, int groupId)
        {
            addUserGroupInviteToTarget(emailUser, emailTarget, groupId.ToString());
        }
    }
}
