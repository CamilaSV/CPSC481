using CPSC481Group12FoodyApp._3_Create_Enter_Send_Chat.chat;
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

namespace CPSC481Group12FoodyApp.Logic
{
    public static class Logic_CreateLoadChat
    {
        public static ObservableCollection<propertyChange_Chat> displayUsersChatList()
        {
            ObservableCollection<propertyChange_Chat> chatListCollection = new ObservableCollection<propertyChange_Chat>();

            MsgInfo msg;
            string name;
            propertyChange_Chat chatItem;
            foreach (var groupId in SessionData.getUserGroups(SessionData.getCurrentUser()))
            {
                msg = SessionData.getGroupLastMsgInfo(groupId);
                name = SessionData.getUserDisplayName(msg.senderEmail);
                chatItem = new propertyChange_Chat
                {
                    Abbreviation = name.Substring(0, 1),
                    ChatId = groupId.ToString(),
                    ChatName = SessionData.getGroupName(groupId),
                    ChatLastSender = msg.senderEmail,
                    ChatLastMsg = msg.content,

                    ChatLastTime = SessionData.getDateOrTimefromEpoch(msg.time),
                };
                chatListCollection.Add(chatItem);
            }

            return chatListCollection;
        }

        public static void createChat(UserControl_CreateNewChat createPage)
        {
            string groupName = createPage.GroupNameText.Text;
            int groupId;

            if (String.IsNullOrWhiteSpace(groupName))
            {
                createPage.ErrorTextBlock.Text = "Group name must not be empty.";
            }
            else
            {
                for (groupId = 0; SessionData.getGroupExist(groupId); groupId++) ;
                SessionData.createGroup(groupId, groupName, SessionData.getCurrentUser());

                foreach (var eachEmail in SessionData.getTargetsToInviteToGroup())
                {
                    SessionData.sendGroupInviteToTarget(eachEmail, groupId, SessionData.getCurrentUser());
                }

                PageNavigator.gotoChatList();
            }
        }
    }
}
