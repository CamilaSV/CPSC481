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
        public static void createChat(UserControl_CreateNewChat createPage)
        {
            string result = Logic_CreateLoadChat.createChat(createPage.GroupNameText.Text, UserProfile.getCurrentEmail(), UserProfile.getfriendsInvitedToChat());
            createPage.navigate_helper.gotoChatList();
        }

        public static void loadChatList(UserControl_ChatList chatListPage)
        {
            List<Tuple<string, string>> result = Logic_CreateLoadChat.loadChatList(UserProfile.getCurrentEmail());

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
