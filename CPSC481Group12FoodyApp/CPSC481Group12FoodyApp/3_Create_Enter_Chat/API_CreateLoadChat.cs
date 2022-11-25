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
            string result = Logic_CreateLoadChat.createChat(createPage.GroupNameText.Text, SessionData.getCurrentEmail(), SessionData.getfriendsInvitedToChat());

            if (result.Equals("true"))
            {
                SessionData.initializeChatList();
                PageNavigator.gotoChatList();
            }
            else
            {
                createPage.ErrorTextBlock.Text = result;
            }
        }

        public static void loadChatList()
        {
            SessionData.initializeChatList();
        }

        public static void enterOneChat(UserControl_ChatList chatListPage, string chatId)
        {
            SessionData.initializeChat(chatId);
        }

        public static void deleteFriend(UserControl_Profile profilePage, string emailTarget)
        {
            Logic_AddRemFriend.deleteFriend(SessionData.getCurrentEmail(), emailTarget);
            SessionData.remFriendFromList(emailTarget);
            profilePage.FriendListTextBlock.Text = Logic_AddRemFriend.getAllFriends(SessionData.getCurrentEmail());
        }

        public static void enterOneChat(UserControl_ChatList chatListPage, int chatId)
        {
            SessionData.initializeChat(chatId);
        }
    }
}
