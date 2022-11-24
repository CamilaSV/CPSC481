using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Printing;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class Logic_CreateLoadChat
    {
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
                SharedFunctions.createFileWithText(PathFinder.getChatMembers(chatId), emailCreator);

                File.Create(PathFinder.getChatLogSender(chatId)).Close();
                File.Create(PathFinder.getChatLogMessage(chatId)).Close();
                File.Create(PathFinder.getChatLogTime(chatId)).Close();
                File.Create(PathFinder.getChatSavedRestaurants(chatId)).Close();
                Directory.CreateDirectory(PathFinder.getChatFutSchDir(chatId));
                Directory.CreateDirectory(PathFinder.getChatCompSchDir(chatId));

                foreach (var eachEmail in emailsToInvite)
                {
                    sendChatInvite(eachEmail, chatId);
                }

                // create necessary directories for the chat creator
                Directory.CreateDirectory(PathFinder.getAccFutSchGroupDir(emailCreator, chatId));
                Directory.CreateDirectory(PathFinder.getAccCompSchGroupDir(emailCreator, chatId));

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
                msgs.Add(new TupleEachMsg(emails[i], messages[i], DateTime.Parse(times[i])));
            }

            return new TupleOneChatLog(emailUser, chatName, msgs);
        }

        public static void sendChatInvite(string emailTarget, string chatId)
        {
            SharedFunctions.appendLineToFile(PathFinder.getAccChatInv(emailTarget), chatId);
        }

        public static void acceptChatInvite(string emailUser, string chatId)
        {
            SharedFunctions.appendLineToFile(PathFinder.getChatMembers(chatId), emailUser);
            removeChatInvite(emailUser, chatId);

            SharedFunctions.appendLineToFile(PathFinder.getAccChats(emailUser), chatId);
            Directory.CreateDirectory(PathFinder.getAccFutSchGroupDir(emailUser, chatId));
            Directory.CreateDirectory(PathFinder.getAccCompSchGroupDir(emailUser, chatId));
        }

        public static void removeChatInvite(string emailUser, string chatId)
        {
            SharedFunctions.removeLineFromFile(PathFinder.getAccChatInv(emailUser), chatId);
        }

        public static Tuple<string, string, TupleEachMsg> previewOneChat(string chatId)
        {
            string chatName = SharedFunctions.getFirstLineFromFile(PathFinder.getChatName(chatId));

            string lastSender = File.ReadLines(PathFinder.getChatLogSender(chatId)).Last();
            string lastMsg = File.ReadLines(PathFinder.getChatLogMessage(chatId)).Last();
            DateTime lastTime = DateTime.Parse(File.ReadLines(PathFinder.getChatLogSender(chatId)).Last());

            return new Tuple<string, string, TupleEachMsg>(chatId, chatName, new TupleEachMsg(lastSender, lastMsg, lastTime));
        }

        public static ObservableCollection<propertyChange_Chat> displayUsersChatList()
        {
            ObservableCollection<propertyChange_Chat> chatListCollection = new ObservableCollection<propertyChange_Chat>();

            if (SessionData.getCurrentChatList().Any())
            {
                foreach (Tuple<string, string, TupleEachMsg> lastmsg in SessionData.getCurrentChatList())
                {
                    propertyChange_Chat requestItem = new propertyChange_Chat
                    {
                        ChatId = lastmsg.Item1,
                        ChatName = lastmsg.Item2,
                        ChatLastSender = lastmsg.Item3.getEmail(),
                        ChatLastMsg = lastmsg.Item3.getMessage(),

                        ChatLastTime = lastmsg.Item3.getTime(),
                    };
                    chatListCollection.Add(requestItem);
                }
            }

            return chatListCollection;
        }

        public static Tuple<string, string, TupleEachMsg> previewOneChat(int chatId)
        {
            return previewOneChat(chatId.ToString());
        }

        public static TupleOneChatLog enterOneChat(string emailUser, int chatId)
        {
            return enterOneChat(emailUser, chatId.ToString());
        }

        public static void sendChatInvite(string emailTarget, int chatId)
        {
            sendChatInvite(emailTarget, chatId.ToString());
        }

        public static void acceptChatInvite(string emailUser, int chatId)
        {
            acceptChatInvite(emailUser, chatId.ToString());
        }

        public static void removeChatInvite(string emailUser, int chatId)
        {
            removeChatInvite(emailUser, chatId.ToString());
        }
    }
}
