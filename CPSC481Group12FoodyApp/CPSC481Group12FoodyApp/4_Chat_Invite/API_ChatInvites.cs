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
            SessionData.remInvFromList(chatId);
            ComponentFunctions.refreshAll();
        }

        public static void removeChatInvite(string chatId)
        {
            Logic_ChatInvites.removeChatInvite(SessionData.getCurrentEmail(), chatId);
            SessionData.remInvFromList(chatId);
            ComponentFunctions.refreshAll();
        }

        public static void acceptChatInvite(int chatId)
        {
            acceptChatInvite(chatId.ToString());
        }

        public static void removeChatInvite(int chatId)
        {
            removeChatInvite(chatId.ToString());
        }
    }
}
