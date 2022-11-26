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
                SessionData.initializeUserChatList();
                PageNavigator.gotoChatList();
            }
            else
            {
                createPage.ErrorTextBlock.Text = result;
            }
        }

        public static void deleteFriendFromInviteList(UserControl_CreateNewChat createPage, string emailTarget)
        {
            // not finished
        }
    }
}
