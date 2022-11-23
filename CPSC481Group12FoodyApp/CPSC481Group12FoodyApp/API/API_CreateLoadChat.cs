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

        public static void enterOneChat(UserControl_ChatList chatListPage, string chatId)
        {
            UserProfile.initializeChat(chatId);
        }

        public static void deleteFriend(UserControl_Profile profilePage, string emailTarget)
        {
            Logic_AddRemFriend.deleteFriend(UserProfile.getCurrentEmail(), emailTarget);
            UserProfile.remFriendFromList(emailTarget);
            profilePage.FriendListTextBlock.Text = Logic_AddRemFriend.getAllFriends(UserProfile.getCurrentEmail());
        }

        public static void acceptChatInvite(string chatId)
        {
            Logic_CreateLoadChat.acceptChatInvite(UserProfile.getCurrentEmail(), chatId);
            UserProfile.addNewChatToList(Logic_CreateLoadChat.previewOneChat(chatId));
            UserProfile.remInvFromList(chatId);
        }

        public static void removeChatInvite(string chatId)
        {
            Logic_CreateLoadChat.removeChatInvite(UserProfile.getCurrentEmail(), chatId);
            UserProfile.remInvFromList(chatId);
        }

        public static void acceptChatInvite(int chatId)
        {
            acceptChatInvite(chatId.ToString());
        }

        public static void removeChatInvite(int chatId)
        {
            removeChatInvite(chatId.ToString());
        }

        public static void enterOneChat(UserControl_ChatList chatListPage, int chatId)
        {
            UserProfile.initializeChat(chatId);
        }
    }
}
