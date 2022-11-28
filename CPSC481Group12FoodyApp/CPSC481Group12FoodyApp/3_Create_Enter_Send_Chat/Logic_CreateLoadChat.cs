using CPSC481Group12FoodyApp._3_Create_Enter_Send_Chat.chat;
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
    public static class Logic_CreateLoadChat
    {

        


        public static ObservableCollection<propertyChange_Chat> displayUsersChatList()
        {
            ObservableCollection<propertyChange_Chat> chatListCollection = new ObservableCollection<propertyChange_Chat>();

            foreach (Tuple<string, string, TupleEachMsg> lastmsg in SessionData.getCurrentUserChatList())
            {
                propertyChange_Chat chatItem = new propertyChange_Chat
                {
                    Abbreviation = lastmsg.Item2.Substring(0, 1),
                    ChatId = lastmsg.Item1,
                    ChatName = lastmsg.Item2,
                    ChatLastSender = lastmsg.Item3.getEmail(),
                    ChatLastMsg = lastmsg.Item3.getMessage(),

                    ChatLastTime = DBSetter.getDateOrTimefromEpoch(lastmsg.Item3.getTime()),
                };
                chatListCollection.Add(chatItem);
            }

            return chatListCollection;
        }

        public static string createChat(string chatName, string emailCreator, List<string> emailsToInvite)
        {
            string result;

            if (String.IsNullOrWhiteSpace(chatName))
            {
                result = "Chat name must not be empty.";
            }
            else
            {
                chatName = chatName.TrimEnd(); // remove whitespaces in the end

                int chatId = DBSetter.findFirstNonExistingChatDirNumber();

                // create necessary files and directories for the chat group
                Directory.CreateDirectory(PathFinder.getChatMsgDir(chatId));
                Directory.CreateDirectory(PathFinder.getChatFutSchDir(chatId));
                Directory.CreateDirectory(PathFinder.getChatCompSchDir(chatId));

                DBSetter.createFileWithText(PathFinder.getChatName(chatId), chatName);
                DBSetter.createFileWithText(PathFinder.getChatAdmin(chatId), emailCreator);
                DBSetter.appendLineToFile(PathFinder.getChatMembers(chatId), emailCreator);

                File.Create(PathFinder.getChatSavedRestaurants(chatId)).Close();
                File.Create(PathFinder.getChatSavedCriteria(chatId)).Close();

                int firstNonExistingDir = DBSetter.findFirstNonExistingMsgDirNumber(chatId);

                Directory.CreateDirectory(PathFinder.getChatOneMsgDir(chatId, firstNonExistingDir));

                DBSetter.appendLineToFile(PathFinder.getChatOneMsgSender(chatId, firstNonExistingDir), "");
                DBSetter.appendLineToFile(PathFinder.getChatOneMsgTime(chatId, firstNonExistingDir), DBSetter.getCurrentEpochTime());
                // newline must not be made here
                StreamWriter fileWriter = File.CreateText(PathFinder.getChatOneMsgMessage(chatId, firstNonExistingDir));
                fileWriter.Write(DBSetter.getFirstLineFromFile(PathFinder.getAccName(emailCreator)) + " has created the group.");
                fileWriter.Close();

                DBSetter.appendLineToFile(PathFinder.getAccChats(emailCreator), chatId);
                Directory.CreateDirectory(PathFinder.getAccFutSchGroupDir(emailCreator, chatId));
                Directory.CreateDirectory(PathFinder.getAccCompSchGroupDir(emailCreator, chatId));

                foreach (var eachEmail in emailsToInvite)
                {
                    sendChatInvite(emailCreator, eachEmail, chatId);
                }

                result = "true";
            }

            return result;
        }

        public static List<Tuple<string, string, TupleEachMsg>> loadChatList(string emailUser)
        {
            List<Tuple<string, string, TupleEachMsg>> result = new List<Tuple<string, string, TupleEachMsg>>();

            StreamReader fileReader = File.OpenText(PathFinder.getAccChats(emailUser));
            while (!fileReader.EndOfStream)
            {
                result.Add(previewOneChat(fileReader.ReadLine()));
            }

            fileReader.Close();

            return result;
        }

        public static void sendChatInvite(string emailUser, string emailTarget, string chatId)
        {
            DBSetter.appendLineToFile(PathFinder.getAccChatInvId(emailTarget), chatId);
            DBSetter.appendLineToFile(PathFinder.getAccChatInvSender(emailTarget), emailUser);
        }

        public static Tuple<string, string, TupleEachMsg> previewOneChat(string chatId)
        {
            string chatName = DBSetter.getFirstLineFromFile(PathFinder.getChatName(chatId));
            List<string> sender = DBSetter.getAllSendersInOneChat(chatId);

            string lastSender = "";
            string lastMsg = "";
            string lastTime = "";
            if (sender.Any())
            {
                lastSender = DBSetter.getFirstLineFromFile(PathFinder.getChatOneMsgSender(chatId, DBSetter.findLastExistingDirNumber(chatId)));
                lastMsg = File.ReadAllText(PathFinder.getChatOneMsgMessage(chatId, DBSetter.findLastExistingDirNumber(chatId)));
                lastTime = DBSetter.getFirstLineFromFile(PathFinder.getChatOneMsgTime(chatId, DBSetter.findLastExistingDirNumber(chatId)));
            }

            return new Tuple<string, string, TupleEachMsg>(chatId, chatName, new TupleEachMsg(lastSender, lastMsg, lastTime));
        }

        public static Tuple<string, string, TupleEachMsg> previewOneChat(int chatId)
        {
            return previewOneChat(chatId.ToString());
        }

        public static void sendChatInvite(string emailUser, string emailTarget, int chatId)
        {
            sendChatInvite(emailUser, emailTarget, chatId.ToString());
        }
    }
}
