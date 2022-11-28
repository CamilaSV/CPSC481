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

            for (int i = 0; i < SessionData.getCurrentUserChatInvId().Count; i++)
            {
                propertyChange_ChatInvite invItem = new propertyChange_ChatInvite
                {
                    GroupId = SessionData.getCurrentUserChatInvId()[i],
                    GroupName = DBSetter.getFirstLineFromFile(PathFinder.getChatName(SessionData.getCurrentUserChatInvId()[i])),
                    SenderEmail = SessionData.getCurrentUserChatInvSender()[i],
                    SenderName = DBSetter.getFirstLineFromFile(PathFinder.getAccName(SessionData.getCurrentUserChatInvSender()[i])),
                };
                invListCollection.Add(invItem);
            }

            return invListCollection;
        }

        public static void acceptChatInvite(string emailUser, string chatId)
        {
            // create necessary files and directories for the chat group
            Directory.CreateDirectory(PathFinder.getChatMsgDir(chatId));
            Directory.CreateDirectory(PathFinder.getChatFutSchDir(chatId));
            Directory.CreateDirectory(PathFinder.getChatCompSchDir(chatId));

            DBSetter.createFileWithText(PathFinder.getChatName(chatId), DBSetter.getFirstLineFromFile(PathFinder.getChatName(chatId)));
            DBSetter.appendLineToFile(PathFinder.getChatMembers(chatId), emailUser);

            File.AppendText(PathFinder.getChatAdmin(chatId));
            File.Create(PathFinder.getChatSavedRestaurants(chatId)).Close();
            File.Create(PathFinder.getChatSavedCriteria(chatId)).Close();

            int firstNonExistingDir = DBSetter.findFirstNonExistingMsgDirNumber(chatId);

            Directory.CreateDirectory(PathFinder.getChatOneMsgDir(chatId, firstNonExistingDir));

            DBSetter.appendLineToFile(PathFinder.getChatOneMsgSender(chatId, firstNonExistingDir), "");
            DBSetter.appendLineToFile(PathFinder.getChatOneMsgTime(chatId, firstNonExistingDir), DBSetter.getCurrentEpochTime());
            // newline must not be made here
            StreamWriter fileWriter = File.CreateText(PathFinder.getChatOneMsgMessage(chatId, firstNonExistingDir));
            fileWriter.Write(DBSetter.getFirstLineFromFile(PathFinder.getAccName(emailUser)) + " has joined the group.");
            fileWriter.Close();

            DBSetter.appendLineToFile(PathFinder.getAccChats(emailUser), chatId);
            Directory.CreateDirectory(PathFinder.getAccFutSchGroupDir(emailUser, chatId));
            Directory.CreateDirectory(PathFinder.getAccCompSchGroupDir(emailUser, chatId));

            removeAllChatInvites(emailUser, chatId);
        }

        public static void removeAllChatInvites(string emailUser, string chatId)
        {
            List<string> filepaths = new List<string>()
            {   
                PathFinder.getAccChatInvId(emailUser),
                PathFinder.getAccChatInvSender(emailUser) 
            };
            DBSetter.removeLineFromMultipleFiles(filepaths, chatId);
        }

        public static void removeOneChatInvite(string emailUser, string emailSender, string chatId)
        {
            List<string> filepaths = new List<string>()
            {
                PathFinder.getAccChatInvId(emailUser),
                PathFinder.getAccChatInvSender(emailUser)
            };

            List<string> linesToRemove = new List<string>() { emailSender, chatId };

            DBSetter.removeLinesOnMatchAll(filepaths, linesToRemove);
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
