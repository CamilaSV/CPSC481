using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using CPSC481Group12FoodyApp.Logic;

namespace CPSC481Group12FoodyApp
{
    public static class API_ChatInvites
    {
        public static void acceptChatInvite(string chatId)
        {
            Logic_ChatInvites.acceptChatInvite(SessionData.getCurrentEmail(), chatId);
            SessionData.addNewChatToList(Logic_CreateLoadChat.previewOneChat(chatId));
            removeAllChatInvites(chatId);
        }

        public static void removeAllChatInvites(string chatId)
        {
            Logic_ChatInvites.removeAllChatInvites(SessionData.getCurrentEmail(), chatId);
            SessionData.remAllInvFromList(chatId);
        }

        public static void removeOneChatInvite(string emailSender, string chatId)
        {
            Logic_ChatInvites.removeOneChatInvite(SessionData.getCurrentEmail(), emailSender, chatId);
            SessionData.remOneInvFromList(emailSender, chatId);
        }

        public static void acceptChatInvite(int chatId)
        {
            acceptChatInvite(chatId.ToString());
        }

        public static void removeAllChatInvites(int chatId)
        {
            removeAllChatInvites(chatId.ToString());
        }

        public static void removeOneChatInvite(string emailSender, int chatId)
        {
            removeOneChatInvite(emailSender, chatId.ToString());
        }
    }
}
