using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Printing;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class Logic_ChatInvites
    {
        public static ObservableCollection<propertyChange_ChatInvite> displayUsersGroupInviteList()
        {
            ObservableCollection<propertyChange_ChatInvite> invListCollection = new ObservableCollection<propertyChange_ChatInvite>();

            for (int i = 0; i < SessionData.getCurrentChatInvId().Count; i++)
            {
                propertyChange_ChatInvite invItem = new propertyChange_ChatInvite
                {
                    GroupId = SessionData.getCurrentChatInvId()[i],
                    GroupName = SharedFunctions.getFirstLineFromFile(PathFinder.getChatName(SessionData.getCurrentChatInvId()[i])),
                    SenderEmail = SessionData.getCurrentChatInvSender()[i],
                    SenderName = SharedFunctions.getFirstLineFromFile(PathFinder.getAccName(SessionData.getCurrentChatInvSender()[i])),
                };
                invListCollection.Add(invItem);
            }

            return invListCollection;
        }

        public static void acceptChatInvite(string emailUser, string chatId)
        {
            SharedFunctions.appendLineToFile(PathFinder.getChatMembers(chatId), emailUser);
            removeAllChatInvites(emailUser, chatId);

            SharedFunctions.appendLineToFile(PathFinder.getAccChats(emailUser), chatId);
            Directory.CreateDirectory(PathFinder.getAccFutSchGroupDir(emailUser, chatId));
            Directory.CreateDirectory(PathFinder.getAccCompSchGroupDir(emailUser, chatId));

            SharedFunctions.appendLineToFile(PathFinder.getChatLogSender(chatId), "");
            SharedFunctions.appendLineToFile(PathFinder.getChatLogMessage(chatId),
                SharedFunctions.getFirstLineFromFile(PathFinder.getAccName(emailUser)) + " has joined the group.");
            SharedFunctions.appendLineToFile(PathFinder.getChatLogTime(chatId), SharedFunctions.getCurrentEpochTime());
        }

        public static void removeAllChatInvites(string emailUser, string chatId)
        {
            List<string> filepaths = new List<string>()
            {   
                PathFinder.getAccChatInvId(emailUser),
                PathFinder.getAccChatInvSender(emailUser) 
            };
            SharedFunctions.removeLineFromMultipleFiles(filepaths, chatId);
        }

        public static void removeOneChatInvite(string emailUser, string emailSender, string chatId)
        {
            List<string> filepaths = new List<string>()
            {
                PathFinder.getAccChatInvId(emailUser),
                PathFinder.getAccChatInvSender(emailUser)
            };

            List<string> linesToRemove = new List<string>() { emailSender, chatId };

            SharedFunctions.removeLinesOnMatchAll(filepaths, linesToRemove);
        }

        public static void acceptChatInvite(string emailUser, int chatId)
        {
            acceptChatInvite(emailUser, chatId.ToString());
        }

        public static void removeAllChatInvites(string emailUser, int chatId)
        {
            removeAllChatInvites(emailUser, chatId.ToString());
        }

        public static void removeOneChatInvite(string emailUser, string emailSender, int chatId)
        {
            removeOneChatInvite(emailUser, emailSender, chatId.ToString());
        }

    }
}
