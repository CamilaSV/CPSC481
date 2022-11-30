using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Printing;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input.Manipulations;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class Logic_Group
    {
        public static void createGroup(UserControl_CreateNewChat createPage)
        {
            string groupName = createPage.GroupNameText.Text;
            int groupId, msgId;

            if (String.IsNullOrWhiteSpace(groupName))
            {
                createPage.ErrorTextBlock.Text = "Group name must not be empty.";
            }
            else
            {
                groupId = SessionData.getFirstAvailableGroupId();
                SessionData.addUserNewGroup(SessionData.getCurrentUser(), groupId, groupName);

                foreach (var eachEmail in SessionData.getTargetsToInviteToGroup())
                {
                    SessionData.sendGroupInviteToTarget(eachEmail, groupId, SessionData.getCurrentUser());
                }
                SessionData.sendGroupInviteToTarget(createPage.InviteeTextBox.Text, groupId, SessionData.getCurrentUser());
                SessionData.saveUserInfoToDB();
                SessionData.saveGroupInfoToDB();
                SessionData.removeInviteTargetList();
                ComponentFunctions.refreshChats();
                ComponentFunctions.refreshChatCreate();
                PageNavigator.gotoChatList();
            }
        }

        public static void acceptGroupInvite(int groupId)
        {
            SessionData.addUserGroup(SessionData.getCurrentUser(), groupId);
            SessionData.saveUserInfoToDB();
            SessionData.saveGroupInfoToDB();
            ComponentFunctions.refreshChatsInv();
            ComponentFunctions.refreshChats();
        }

        public static void removeOneGroupInvite(string emailUser, int groupId, string emailSender)
        {
            SessionData.removeUserGroupInvite(emailUser, groupId, emailSender);
            SessionData.saveUserInfoToDB();
            ComponentFunctions.refreshChatsInv();
        }

        public static void addTargetToInviteList(string emailTarget)
        {
            SessionData.addTargetToInviteGroupList(emailTarget);
            ComponentFunctions.refreshChatCreate();
        }

        public static void removeTargetFromInviteList(string emailTarget)
        {
            SessionData.removeTargetFromInviteGroupList(emailTarget);
            ComponentFunctions.refreshChatCreate();
        }

        public static void addGroupMember()
        {

        }

        public static void removeGroupMember()
        {

        }

        public static void addGroupCriteria()
        {

        }

        public static void removeGroupCriteria()
        {

        }

        public static void addRestaurant()
        {

        }

        public static void removeRestaurant()
        {

        }

        public static void createEvent(string chatId, string restaurantName, DateTime date)
        {
        }
    }
}
