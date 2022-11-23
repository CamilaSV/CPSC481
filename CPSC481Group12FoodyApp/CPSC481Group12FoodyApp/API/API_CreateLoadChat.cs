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
            string result = Logic_CreateLoadChat.createChat(chatName, emailCreator, emailsToInvite);
        }

        public static void loadChatList(string chatName, string emailUser)
        {
        }

        public static void previewOneChat(string chatId)
        {
        }

        public static void enterOneChat(string emailUser, string chatId)
        {
        }

        public static void enterOneChat(string emailUser, int chatId)
        {
        }

        public static void sendChatInvite(string emailTarget, string chatId)
        {
        }

        public static void sendChatInvite(string emailTarget, int chatId)
        {
        }

        public static void acceptChatInvite(string emailUser, string chatId)
        {
        }

        public static void acceptChatInvite(string emailUser, int chatId)
        {
        }

        public static void removeChatInvite(string emailUser, string chatId)
        {
        }

        public static void removeChatInvite(string emailUser, int chatId)
        {
        }
    }
}
