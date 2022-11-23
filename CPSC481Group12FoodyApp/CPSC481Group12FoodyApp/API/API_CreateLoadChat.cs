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

            if (result.Equals("true"))
            {
                UserProfile.initializeChatList();
                createPage.navigate_helper.gotoChatList();
            }
            else
            {
                createPage.ErrorTextBlock.Text = result;
            }
        }

        public static void loadChatList(UserControl_ChatList chatListPage)
        {
            UserProfile.initializeChatList();
        }

        public static void enterOneChat(UserControl_ChatList chatListPage)
        {
        }

        public static void sendChatInvite(string emailTarget, string chatId)
        {
        }

        public static void acceptChatInvite(string emailUser, string chatId)
        {
        }

        public static void removeChatInvite(string emailUser, string chatId)
        {
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
