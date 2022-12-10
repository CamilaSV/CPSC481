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
                SessionData.stopTimer();
                SessionData.updateUserInfoFromDB();
                SessionData.updateGroupInfoFromDB();
                groupId = SessionData.getFirstAvailableGroupId();
                SessionData.addUserNewGroup(SessionData.getCurrentUser(), groupId, groupName);

                foreach (var eachEmail in SessionData.getTargetsToInviteToGroup())
                {
                    SessionData.sendGroupInviteToTarget(eachEmail, groupId, SessionData.getCurrentUser());
                }
                SessionData.removeInviteTargetList();

                SessionData.saveUserInfoToDB();
                SessionData.saveGroupInfoToDB();
                PageNavigator.gotoChatList();
                SessionData.startTimer();
            }
        }

        public static void sendInvites(int groupId)
        {
            SessionData.stopTimer();
            SessionData.updateUserInfoFromDB();
            foreach (var eachEmail in SessionData.getTargetsToInviteToGroup())
            {
                SessionData.sendGroupInviteToTarget(eachEmail, groupId, SessionData.getCurrentUser());
            }
            SessionData.removeInviteTargetList();
            SessionData.saveUserInfoToDB();
            SessionData.startTimer();
        }

        public static void acceptGroupInvite(int groupId)
        {
            SessionData.stopTimer();
            SessionData.updateUserInfoFromDB();
            SessionData.updateGroupInfoFromDB();
            SessionData.addUserGroup(SessionData.getCurrentUser(), groupId);
            SessionData.addGroupMember(groupId, SessionData.getCurrentUser());
            SessionData.saveUserInfoToDB();
            SessionData.saveGroupInfoToDB();
            ComponentFunctions.refreshAll();
            SessionData.startTimer();
        }

        public static void removeOneGroupInvite(string emailUser, int groupId, string emailSender)
        {
            SessionData.stopTimer();
            SessionData.updateUserInfoFromDB();
            SessionData.removeUserGroupInvite(emailUser, groupId, emailSender);
            SessionData.saveUserInfoToDB();
            ComponentFunctions.refreshAll();
            SessionData.startTimer();
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

        public static void removeGroupMember(int groupId, string emailTarget)
        {
            SessionData.stopTimer();
            SessionData.updateUserInfoFromDB();
            SessionData.updateGroupInfoFromDB();
            SessionData.removeGroupMember(groupId, emailTarget);
            SessionData.removeUserGroup(emailTarget, groupId);
            SessionData.saveUserInfoToDB();
            SessionData.saveGroupInfoToDB();
            ComponentFunctions.refreshAll();
            SessionData.startTimer();
        }

        public static void promoteGroupMember(int groupId, string emailTarget)
        {
            SessionData.stopTimer();
            SessionData.updateGroupInfoFromDB();
            SessionData.addGroupMemberToAdmin(groupId, emailTarget);
            SessionData.saveGroupInfoToDB();
            ComponentFunctions.refreshAll();
            SessionData.startTimer();
        }

        public static void demoteGroupMember(int groupId, string emailTarget)
        {
            SessionData.stopTimer();
            SessionData.updateGroupInfoFromDB();
            SessionData.removeGroupMemberFromAdmin(groupId, emailTarget);
            SessionData.saveGroupInfoToDB();
            ComponentFunctions.refreshAll();
            SessionData.startTimer();
        }

        public static void addGroupCriteria(int criterionId, string targetEmail)
        {
            SessionData.stopTimer();
            SessionData.updateGroupInfoFromDB();
            SessionData.addGroupCriterion(SessionData.getCurrentGroupId(), targetEmail, criterionId);
            SessionData.saveGroupInfoToDB();
            ComponentFunctions.refreshAll();
            SessionData.startTimer();
        }

        public static void removeGroupCriteria(string targetEmail)
        {
            SessionData.stopTimer();
            SessionData.updateGroupInfoFromDB();
            SessionData.removeGroupCriterion(SessionData.getCurrentGroupId(), targetEmail);
            SessionData.saveGroupInfoToDB();
            ComponentFunctions.refreshAll();
            SessionData.startTimer();
        }

        public static void addGroupEventCustomTime(DateTime dateTime)
        {
            SessionData.stopTimer();
            SessionData.updateGroupInfoFromDB();
            SessionData.addEventCustomTime(SessionData.getCurrentGroupId(), SessionData.getEpochFromDateOrTime(dateTime));
            SessionData.saveGroupInfoToDB();
            ComponentFunctions.refreshAll();
            SessionData.startTimer();
        }

        public static void removeGroupEventCustomTime(DateTime dateTime)
        {
            SessionData.stopTimer();
            SessionData.updateGroupInfoFromDB();
            SessionData.removeEventCustomTime(SessionData.getCurrentGroupId(), SessionData.getEpochFromDateOrTime(dateTime));
            SessionData.saveGroupInfoToDB();
            ComponentFunctions.refreshAll();
            SessionData.startTimer();
        }

        public static void addGroupRestaurant(int restaurantId)
        {
            SessionData.stopTimer();
            SessionData.updateGroupInfoFromDB();
            SessionData.addGroupRestaurant(SessionData.getCurrentGroupId(), restaurantId);
            SessionData.saveGroupInfoToDB();
            ComponentFunctions.refreshAll();
            SessionData.startTimer();
        }

        public static void removeGroupRestaurant(int restaurantId)
        {
            SessionData.stopTimer();
            SessionData.updateGroupInfoFromDB();
            SessionData.removeGroupRestaurant(SessionData.getCurrentGroupId(), restaurantId);
            SessionData.saveGroupInfoToDB();
            ComponentFunctions.refreshAll();
            SessionData.startTimer();
        }

        public static void addUserVote(int resId)
        {
            SessionData.addUserVote(SessionData.getCurrentGroupId(), resId, SessionData.getCurrentUser());
            SessionData.saveGroupInfoToDB();
            ComponentFunctions.refreshAll();
        }

        public static void addGroupVote(int restaurantId)
        {
            SessionData.addGroupVote(SessionData.getCurrentGroupId(), restaurantId);
            SessionData.saveUserInfoToDB();
            SessionData.saveGroupInfoToDB();
            ComponentFunctions.refreshAll();
        }

        public static void createGroupEvent(int restaurantId, long date, string comment)
        {
            SessionData.stopTimer();
            SessionData.updateUserInfoFromDB();
            SessionData.updateGroupInfoFromDB();
            int eventId = SessionData.getFirstAvailableEventId(SessionData.getCurrentGroupId());
            SessionData.addGroupEvent(SessionData.getCurrentGroupId(), eventId, date, restaurantId, comment);
            SessionData.saveUserInfoToDB();
            SessionData.saveGroupInfoToDB();
            ComponentFunctions.refreshAll();
            SessionData.startTimer();
        }

        public static void removeGroupEvent(int eventId)
        {
            SessionData.stopTimer();
            SessionData.updateUserInfoFromDB();
            SessionData.updateGroupInfoFromDB();
            SessionData.removeGroupEvent(SessionData.getCurrentGroupId(), eventId);
            SessionData.saveUserInfoToDB();
            SessionData.saveGroupInfoToDB();
            ComponentFunctions.refreshAll();
            SessionData.startTimer();
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
