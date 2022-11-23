using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class Logic_CreateLoadChat
    {
        public static string createChat(string chatName, string emailCreator, string[] emailsToInvite)
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

                File.Create(PathFinder.getChatLog(chatId)).Close();
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

        public static List<Tuple<string, string>> loadChatList(string chatName, string emailUser)
        {
            List<Tuple<string, string>> result = new List<Tuple<string, string>>();

            StreamReader fileReader = File.OpenText(PathFinder.getAccChats(emailUser));
            while (!fileReader.EndOfStream)
            {
                result.Add(previewOneChat(fileReader.ReadLine()));
            }

            fileReader.Close();

            return result;
        }

        public static Tuple<string, string> previewOneChat(string chatId)
        {
            string chatName = SharedFunctions.getFirstLineFromFile(PathFinder.getChatName(chatId));
            string lastChat = File.ReadLines(PathFinder.getChatLog(chatId)).Last();

            return new Tuple<string, string>(chatName, lastChat); // get chat name and the very last chat
        }

        public static Tuple<string, string, string[]> enterOneChat(string emailUser, string chatId)
        {
            string chatName = SharedFunctions.getFirstLineFromFile(PathFinder.getChatName(chatId));
            string[] chatLog = File.ReadAllLines(PathFinder.getChatLog(chatId));

            return new Tuple<string, string, string[]>(emailUser, chatName, chatLog);
        }

        public static void sendChatInvite(string emailTarget, string chatId)
        {
            SharedFunctions.appendLineToFile(PathFinder.getAccChatInv(emailTarget), chatId);
        }

        public static void acceptChatInvite(string emailUser, string chatId)
        {
            SharedFunctions.appendLineToFile(PathFinder.getChatMembers(chatId), emailUser);
            Directory.CreateDirectory(PathFinder.getAccFutSchGroupDir(emailUser, chatId));
            Directory.CreateDirectory(PathFinder.getAccCompSchGroupDir(emailUser, chatId));
            removeChatInvite(emailUser, chatId);
        }

        public static void removeChatInvite(string emailUser, string chatId)
        {
            SharedFunctions.removeLineFromFile(PathFinder.getAccChatInv(emailUser), chatId);
        }

        public static Tuple<string, string> previewOneChat(int chatId)
        {
            return previewOneChat(chatId.ToString());
        }

        public static Tuple<string, string, string[]> enterOneChat(string emailUser, int chatId)
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
