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
            int groupId;

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
                ComponentFunctions.refreshAll();
                PageNavigator.gotoChatList();
            }
        }

        public static void acceptGroupInvite(int groupId)
        {
            SessionData.addUserGroup(SessionData.getCurrentUser(), groupId);
            addGroupMember(groupId, SessionData.getCurrentUser());
            ComponentFunctions.refreshAll();
        }

        public static void removeOneGroupInvite(string emailUser, int groupId, string emailSender)
        {
            SessionData.removeUserGroupInvite(emailUser, groupId, emailSender);
            SessionData.saveUserInfoToDB();
            ComponentFunctions.refreshAll();
        }

        public static void addTargetToInviteList(string emailTarget)
        {
            SessionData.addTargetToInviteGroupList(emailTarget);
            ComponentFunctions.refreshAll();
        }

        public static void removeTargetFromInviteList(string emailTarget)
        {
            SessionData.removeTargetFromInviteGroupList(emailTarget);
            ComponentFunctions.refreshAll();
        }

        public static void addGroupMember(int groupId, string emailTarget)
        {
            SessionData.addGroupMember(groupId, emailTarget);
            SessionData.saveUserInfoToDB();
            SessionData.saveGroupInfoToDB();
            ComponentFunctions.refreshAll();
        }

        public static void removeGroupMember(int groupId, string emailTarget)
        {
            SessionData.removeGroupMember(groupId, emailTarget);
            SessionData.removeUserGroup(emailTarget, groupId);
            SessionData.saveUserInfoToDB();
            SessionData.saveGroupInfoToDB();
            ComponentFunctions.refreshAll();
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

        public static void addGroupMember(string groupId, string emailTarget)
        {
            addGroupMember(Int32.Parse(groupId), emailTarget);
        }

        public static void removeGroupMember(string groupId, string emailTarget)
        {
            removeGroupMember(Int32.Parse(groupId), emailTarget);
        }

    }
}
