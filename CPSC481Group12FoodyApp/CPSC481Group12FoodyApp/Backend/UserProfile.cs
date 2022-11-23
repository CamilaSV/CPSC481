﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class UserProfile
    {
        // user data
        private static string currentUserEmail;
        private static List<string> currentFriendList = new List<string>();
        private static List<string> currentFriendReq = new List<string>();
        private static List<string> currentChatInv = new List<string>();
        private static List<Tuple<string, string>> currentEventList = new List<Tuple<string, string>>();

        // chat data
        private static string currentChatId;
        private static List<string> currentChatList = new List<string>();

        // data for one chat
        private static List<string> currentChatLog = new List<string>();
        private static List<string> currentChatEventList = new List<string>();

        // data when creating chat
        private static List<string> friendsInvitedToChat = new List<string>();

        // data when creating event under here?


        public static void initializeUser(string email)
        {
            currentUserEmail = email;
            currentFriendList = File.ReadAllLines(PathFinder.getAccFriends(email)).ToList();
            currentFriendReq = File.ReadAllLines(PathFinder.getAccFriendReq(email)).ToList();
            currentChatInv = File.ReadAllLines(PathFinder.getAccChatInv(email)).ToList();
            ComponentFunctions.refreshAll();
        }

        public static void initializeChat(string chatId)
        {
            currentChatId = chatId;
            currentChatLog = File.ReadAllLines(PathFinder.getChatLog(chatId)).ToList();
            ComponentFunctions.refreshAll();
        }

        public static void initializeChatInvite()
        {
            friendsInvitedToChat.Clear();
            ComponentFunctions.refreshChatCreate();
        }

        public static string getCurrentEmail()
        {
            return currentUserEmail;
        }

        public static List<string> getCurrentFriends()
        {
            return currentFriendList;
        }

        public static List<string> getCurrentFriendReq()
        {
            return currentFriendReq;
        }

        public static string getCurrentChatId()
        {
            return currentChatId;
        }

        public static List<string> getCurrentChatLog()
        {
            return currentChatLog;
        }

        public static List<string> getCurrentChatInv()
        {
            return currentChatInv;
        }

        public static List<string> getfriendsInvitedToChat()
        {
            return friendsInvitedToChat;
        }

        public static void addFriendToList(string item)
        {
            currentFriendList.Add(item);
            ComponentFunctions.refreshFriends();
            ComponentFunctions.refreshFriendsReq();
        }

        public static void addFriendReqToList(string item)
        {
            currentFriendReq.Add(item);
            ComponentFunctions.refreshFriends();
            ComponentFunctions.refreshFriendsReq();
        }

        public static void addInvToList(string item)
        {
            currentChatInv.Add(item);
            ComponentFunctions.refreshChats();
            ComponentFunctions.refreshChatsInv();
        }

        public static void addNewChatToList(string item)
        {
            currentChatList.Add(item);
            ComponentFunctions.refreshChats();
            ComponentFunctions.refreshChatsInv();
        }

        public static void addChatLogToList(string item)
        {
            currentChatLog.Add(item);
            ComponentFunctions.refreshChats();
        }

        public static void remFriendFromList(string item)
        {
            currentFriendList.Remove(item);
            ComponentFunctions.refreshFriends();
            ComponentFunctions.refreshFriendsReq();
        }

        public static void remFriendReqFromList(string item)
        {
            currentFriendReq.Remove(item);
            ComponentFunctions.refreshFriends();
            ComponentFunctions.refreshFriendsReq();
        }

        public static void remInvFromList(string item)
        {
            currentChatInv.Remove(item);
            ComponentFunctions.refreshChats();
            ComponentFunctions.refreshChatsInv();
        }

        public static void addFriendToChatCreateList(string item)
        {
            friendsInvitedToChat.Add(item);
            ComponentFunctions.refreshChatCreate();
        }

        public static void initializeChat(int chatId)
        {
            initializeChat(chatId.ToString());
        }
    }
}
