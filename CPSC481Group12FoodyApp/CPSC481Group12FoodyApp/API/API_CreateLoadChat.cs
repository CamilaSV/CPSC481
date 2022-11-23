using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;

using CPSC481Group12FoodyApp.Logic;

namespace CPSC481Group12FoodyApp
{
    public static class API_CreateLoadChat
    {
        public static void createChat(string chatName, string emailCreator, string[] emailsToInvite)
        {
        }

        public static void loadChatList(string chatName, string emailUser)
        {
        }

        public static void previewOneChat(string chatId)
        {
        }

        public static Tuple<string, string, string[]> enterOneChat(string emailUser, string chatId)
        {
            string chatName = SharedFunctions.getFirstLineFromFile(PathFinder.getChatName(chatId));
            string[] chatLog = File.ReadAllLines(PathFinder.getChatLog(chatId));

            return new Tuple<string, string, string[]>(emailUser, chatName, chatLog);
        }

        public static Tuple<string, string, string[]> enterOneChat(string emailUser, int chatId)
        {
            string chatName = SharedFunctions.getFirstLineFromFile(PathFinder.getChatName(chatId));
            string[] chatLog = File.ReadAllLines(PathFinder.getChatLog(chatId));

            return new Tuple<string, string, string[]>(emailUser, chatName, chatLog);
        }

        public static void sendChatInvite(string emailTarget, string chatId)
        {
            SharedFunctions.appendLineToFile(PathFinder.getAccChatInv(emailTarget), chatId);
        }

        public static void sendChatInvite(string emailTarget, int chatId)
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

        public static void acceptChatInvite(string emailUser, int chatId)
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

        public static void removeChatInvite(string emailUser, int chatId)
        {
            SharedFunctions.removeLineFromFile(PathFinder.getAccChatInv(emailUser), chatId);
        }
    }
}
