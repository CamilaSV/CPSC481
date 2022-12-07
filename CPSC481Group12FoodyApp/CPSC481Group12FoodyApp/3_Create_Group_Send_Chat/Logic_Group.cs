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

//                SessionData.sendGroupInviteToTarget(createPage.InviteeTextBox.Text, groupId, SessionData.getCurrentUser());
                sendInvites(groupId);
                SessionData.saveGroupInfoToDB();
                PageNavigator.gotoChatList();
            }
        }

        public static void sendInvites(int groupId)
        {
            foreach (var eachEmail in SessionData.getTargetsToInviteToGroup())
            {
                SessionData.sendGroupInviteToTarget(eachEmail, groupId, SessionData.getCurrentUser());
            }
            SessionData.removeInviteTargetList();
            SessionData.saveUserInfoToDB();
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

        public static void promoteGroupMember(int groupId, string emailTarget)
        {
            SessionData.addGroupMemberToAdmin(groupId, emailTarget);
            SessionData.saveGroupInfoToDB();
            ComponentFunctions.refreshAll();
        }

        public static void demoteGroupMember(int groupId, string emailTarget)
        {
            SessionData.removeGroupMemberFromAdmin(groupId, emailTarget);
            SessionData.saveGroupInfoToDB();
            ComponentFunctions.refreshAll();
        }

        public static void addGroupCriteria(int criterionId, string targetEmail)
        {
            SessionData.addGroupCriterion(SessionData.getCurrentGroupId(), targetEmail, criterionId);
            SessionData.saveGroupInfoToDB();
            ComponentFunctions.refreshAll();
        }

        public static void removeGroupCriteria(string targetEmail)
        {
            SessionData.removeGroupCriterion(SessionData.getCurrentGroupId(), targetEmail);
            SessionData.saveGroupInfoToDB();
            ComponentFunctions.refreshAll();
        }

        public static void addGroupEventCustomTime(DateTime dateTime)
        {
            SessionData.addEventCustomTime(SessionData.getCurrentGroupId(), SessionData.getEpochFromDateOrTime(dateTime));
            SessionData.saveGroupInfoToDB();
            ComponentFunctions.refreshAll();
        }

        public static void removeGroupEventCustomTime(DateTime dateTime)
        {
            SessionData.removeEventCustomTime(SessionData.getCurrentGroupId(), SessionData.getEpochFromDateOrTime(dateTime));
            SessionData.saveGroupInfoToDB();
            ComponentFunctions.refreshAll();
        }

        public static void addGroupRestaurant(int restaurantId)
        {
            SessionData.addGroupRestaurant(SessionData.getCurrentGroupId(), restaurantId);
            SessionData.saveGroupInfoToDB();
            ComponentFunctions.refreshAll();
        }

        public static void removeGroupRestaurant(int restaurantId)
        {
            SessionData.removeGroupRestaurant(SessionData.getCurrentGroupId(), restaurantId);
            ComponentFunctions.refreshAll();
        }

        public static void createGroupEvent(int restaurantId, long date, string comment)
        {
            int eventId = SessionData.getFirstAvailableEventId(SessionData.getCurrentGroupId());
            SessionData.addGroupEvent(SessionData.getCurrentGroupId(), eventId, date, restaurantId, comment);
            SessionData.saveUserInfoToDB();
            SessionData.saveGroupInfoToDB();
            ComponentFunctions.refreshAll();
        }

        public static void removeGroupEvent(int eventId)
        {
            SessionData.removeGroupEvent(SessionData.getCurrentGroupId(), eventId);
            SessionData.saveUserInfoToDB();
            SessionData.saveGroupInfoToDB();
            ComponentFunctions.refreshAll();
        }

        public static void createGroupEvent(int restaurantId, DateTime date, string comment)
        {
            createGroupEvent(restaurantId, SessionData.getEpochFromDateOrTime(date), comment);
        }

        public static void createGroupEvent(string restaurantId, long date, string comment)
        {
            createGroupEvent(Int32.Parse(restaurantId), date, comment);
        }

        public static void createGroupEvent(string restaurantId, DateTime date, string comment)
        {
            createGroupEvent(Int32.Parse(restaurantId), SessionData.getEpochFromDateOrTime(date), comment);
        }

        public static void addGroupMember(string groupId, string emailTarget)
        {
            addGroupMember(Int32.Parse(groupId), emailTarget);
        }

        public static void removeGroupMember(string groupId, string emailTarget)
        {
            removeGroupMember(Int32.Parse(groupId), emailTarget);
        }

        public static void addGroupCriteria(string criterionId, string targetEmail)
        {
            addGroupCriteria(Int32.Parse(criterionId), targetEmail);
        }

        public static void addGroupRestaurant(string restaurantId)
        {
            addGroupRestaurant(Int32.Parse(restaurantId));
        }

        public static void removeGroupRestaurant(string restaurantId)
        {
            removeGroupRestaurant(Int32.Parse(restaurantId));
        }
    }
}
