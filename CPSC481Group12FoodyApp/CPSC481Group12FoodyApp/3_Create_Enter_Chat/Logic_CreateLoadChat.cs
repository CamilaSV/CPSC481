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

            foreach (Tuple<string, string, TupleEachMsg> lastmsg in SessionData.getCurrentChatList())
            {
                propertyChange_Chat chatItem = new propertyChange_Chat
                {
                    Abbreviation = lastmsg.Item2.Substring(0, 1),
                    ChatId = lastmsg.Item1,
                    ChatName = lastmsg.Item2,
                    ChatLastSender = lastmsg.Item3.getEmail(),
                    ChatLastMsg = lastmsg.Item3.getMessage(),

                    ChatLastTime = SharedFunctions.getDateOrTimefromEpoch(lastmsg.Item3.getTime()),
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

                int chatId;

                for (chatId = 0; Directory.Exists(PathFinder.getChatDir(chatId)); chatId++) ; // find a unique chat id

                // create necessary files and directories for the chat group
                Directory.CreateDirectory(PathFinder.getChatDir(chatId));

                SharedFunctions.createFileWithText(PathFinder.getChatName(chatId), chatName);
                SharedFunctions.createFileWithText(PathFinder.getChatAdmin(chatId), emailCreator);

                File.Create(PathFinder.getChatLogSender(chatId)).Close();
                File.Create(PathFinder.getChatLogMessage(chatId)).Close();
                File.Create(PathFinder.getChatLogTime(chatId)).Close();
                File.Create(PathFinder.getChatSavedRestaurants(chatId)).Close();
                Directory.CreateDirectory(PathFinder.getChatFutSchDir(chatId));
                Directory.CreateDirectory(PathFinder.getChatCompSchDir(chatId));

                foreach (var eachEmail in emailsToInvite)
                {
                    sendChatInvite(emailCreator, eachEmail, chatId);
                }

                Logic_ChatInvites.acceptChatInvite(emailCreator, chatId); // the creator automatically accepts the invitation

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

        public static TupleOneChatLog enterOneChat(string emailUser, string chatId)
        {
            string chatName = SharedFunctions.getFirstLineFromFile(PathFinder.getChatName(chatId));
            string[] emails = File.ReadAllLines(PathFinder.getChatLogSender(chatId));
            string[] messages = File.ReadAllLines(PathFinder.getChatLogMessage(chatId));
            string[] times = File.ReadAllLines(PathFinder.getChatLogTime(chatId));

            List<TupleEachMsg> msgs = new List<TupleEachMsg>();

            for (int i = 0; i < emails.Length; i++)
            {
                msgs.Add(new TupleEachMsg(emails[i], messages[i], times[i]));
            }

            return new TupleOneChatLog(emailUser, chatName, msgs);
        }

        public static void sendChatInvite(string emailUser, string emailTarget, string chatId)
        {
            SharedFunctions.appendLineToFile(PathFinder.getAccChatInvId(emailTarget), chatId);
            SharedFunctions.appendLineToFile(PathFinder.getAccChatInvSender(emailTarget), emailUser);
        }

        public static Tuple<string, string, TupleEachMsg> previewOneChat(string chatId)
        {
            string chatName = SharedFunctions.getFirstLineFromFile(PathFinder.getChatName(chatId));
            List<string> tester = File.ReadAllLines(PathFinder.getChatLogSender(chatId)).ToList();

            string lastSender = "";
            string lastMsg = "";
            string lastTime = "";
            if (tester.Any())
            {
                lastSender = File.ReadLines(PathFinder.getChatLogSender(chatId)).Last();
                lastMsg = File.ReadLines(PathFinder.getChatLogMessage(chatId)).Last();
                lastTime = File.ReadLines(PathFinder.getChatLogTime(chatId)).Last();
            }

            return new Tuple<string, string, TupleEachMsg>(chatId, chatName, new TupleEachMsg(lastSender, lastMsg, lastTime));
        }

        public static Tuple<string, string, TupleEachMsg> previewOneChat(int chatId)
        {
            return previewOneChat(chatId.ToString());
        }

        public static TupleOneChatLog enterOneChat(string emailUser, int chatId)
        {
            return enterOneChat(emailUser, chatId.ToString());
        }

        public static void sendChatInvite(string emailUser, string emailTarget, int chatId)
        {
            sendChatInvite(emailUser, emailTarget, chatId.ToString());
        }
    }
}
