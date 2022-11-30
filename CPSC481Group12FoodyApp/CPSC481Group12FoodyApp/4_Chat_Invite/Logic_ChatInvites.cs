using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Printing;
using System.Windows;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class Logic_ChatInvites
    {
        public static ObservableCollection<propertyChange_ChatInvite> displayUsersGroupInviteList()
        {
            ObservableCollection<propertyChange_ChatInvite> invListCollection = new ObservableCollection<propertyChange_ChatInvite>();

            propertyChange_ChatInvite invItem;
            foreach (var invite in SessionData.getUserGroupInvitations(SessionData.getCurrentUser()))
            {
                invItem = new propertyChange_ChatInvite
                {
                    GroupId = invite.inviteGroupId.ToString(),
                    GroupName = SessionData.getGroupName(invite.inviteGroupId),
                    SenderEmail = invite.inviteSenderEmail,
                    SenderName = SessionData.getUserDisplayName(invite.inviteSenderEmail),
                };
                invListCollection.Add(invItem);
            }

            return invListCollection;
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
    }
}
