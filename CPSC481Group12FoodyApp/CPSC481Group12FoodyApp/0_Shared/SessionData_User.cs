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
                eventList = new List<EventId>(),
                categoryList = new List<string>(),
                restaurantList = new List<UserCatResInfo>(),
                invitationList = new List<InvitationInfo>(),
            };

            allUsers[email] = info;
        }

        public static void addUserNewGroup(string emailCreator, string groupId, string name)
        {
            SessionData_Group.createGroup(groupId, name, emailCreator);
            addUserGroup(emailCreator, groupId);
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

        public static List<string> getUserSavedCategories(string email)
        {
            return allUsers[email].categoryList;
        }

        public static List<EventId> getUserEvents(string email)
        {
            return allUsers[email].eventList;
        }

        public static List<UserCatResInfo> getUserSavedRestaurants(string email)
        {
            return allUsers[email].restaurantList;
        }

        // setters
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
            if (!allUsers[emailUser].friendList.Contains(emailTarget))
            {
                allUsers[emailUser].friendList.Add(emailTarget);
                removeUserFriendReq(emailUser, emailTarget);
                addUserFriend(emailTarget, emailUser);
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

        public static void addUserGroup(string emailUser, string groupId)
        {
            if (!allUsers[emailUser].groupList.Contains(groupId))
            {
                allUsers[emailUser].groupList.Add(groupId);
                // delete all invitations that invites to the added groupId
                allUsers[emailUser].invitationList.RemoveAll(invite => invite.inviteGroupId.Equals(groupId));
                SessionData_Group.addGroupMember(emailUser, groupId);
            }
        }

        public static void removeUserGroup(string emailUser, string groupId)
        {
            if (allUsers[emailUser].groupList.Contains(groupId))
            {
                allUsers[emailUser].groupList.Remove(groupId);
                SessionData_Group.removeGroupMember(emailUser, groupId);
            }
        }

        public static void addUserCategory(string emailUser, string categoryId, string name)
        {
            if (!allUsers[emailUser].categoryList.Contains(categoryId))
            {
                allUsers[emailUser].categoryList.Add(categoryId);
                SessionData_Category.createCategory(emailUser, categoryId, name);
            }
        }

        public static void removeUserCategory(string emailUser, string categoryId)
        {
            if (allUsers[emailUser].categoryList.Contains(categoryId))
            {
                allUsers[emailUser].categoryList.Remove(categoryId);
                // delete all restaurants that belongs to the categoryId
                allUsers[emailUser].restaurantList.RemoveAll(info => info.categoryId.Equals(categoryId));
                SessionData_Category.deleteCategory(emailUser, categoryId);
            }
        }


        public static void addUserEvent(string emailUser, EventId eventId)
        {
            if (!allUsers[emailUser].eventList.Contains(eventId))
            {
                allUsers[emailUser].eventList.Add(eventId);
            }
        }

        public static void removeUserEvent(string emailUser, EventId eventId)
        {
            if (allUsers[emailUser].eventList.Contains(eventId))
            {
                allUsers[emailUser].eventList.Remove(eventId);
            }
        }

        public static void addUserRestaurant(string emailUser, UserCatResInfo info)
        {
            if (!allUsers[emailUser].restaurantList.Contains(info))
            {
                allUsers[emailUser].restaurantList.Add(info);
            }
        }

        public static void removeUserRestaurant(string emailUser, UserCatResInfo info)
        {
            if (allUsers[emailUser].restaurantList.Contains(info))
            {
                allUsers[emailUser].restaurantList.Remove(info);
            }
        }

        public static void removeUserGroupInvite(string emailUser, InvitationInfo info)
        {
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

        public static void addUserGroupInviteToTarget(string emailTarget, InvitationInfo info)
        {
            if (!allUsers[emailTarget].invitationList.Contains(info))
            {
                allUsers[emailTarget].invitationList.Add(info);
            }
        }

        // different types of arguments
        public static void addUserGroup(string emailUser, int groupId)
        {
            addUserGroup(emailUser, groupId.ToString());
        }

        public static void removeUserGroup(string emailUser, int groupId)
        {
            removeUserGroup(emailUser, groupId.ToString());
        }

        public static void addUserCategory(string emailUser, int categoryId, string name)
        {
            addUserCategory(emailUser, categoryId.ToString(), name);
        }

        public static void removeUserCategory(string emailUser, int categoryId)
        {
            removeUserCategory(emailUser, categoryId.ToString());
        }
    }
}
