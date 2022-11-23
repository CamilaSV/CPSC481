using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class SessionData
    {
        // user data
        private static string currentUserEmail;
        private static List<string> currentFriendList = new List<string>();
        private static List<string> currentFriendReq = new List<string>();
        private static List<string> currentChatInv = new List<string>();
        private static List<Tuple<string, string>> currentEventList = new List<Tuple<string, string>>();

        // chat data
        private static string currentChatId;
        private static List<Tuple<string, string, TupleEachMsg>> currentChatList = new List<Tuple<string, string, TupleEachMsg>>(); // chat id, chat name, last message Tuple

        // data for one chat
        private static TupleOneChatLog currentChatLog;

        // data when creating chat
        private static List<string> friendsInvitedToChat = new List<string>();

        // data when creating event under here?


        public static void initializeUser(string email)
        {
            currentUserEmail = email;
            currentFriendList = File.ReadAllLines(PathFinder.getAccFriends(email)).ToList();
            currentFriendReq = File.ReadAllLines(PathFinder.getAccFriendReq(email)).ToList();
            currentChatInv = File.ReadAllLines(PathFinder.getAccChatInv(email)).ToList();
            initializeChatList();
            ComponentFunctions.refreshAll();
        }

        public static void initializeChatList()
        {
            currentChatList = Logic_CreateLoadChat.loadChatList(currentUserEmail);
            currentChatList.Sort(delegate (Tuple<string, string, TupleEachMsg> msg1, Tuple<string, string, TupleEachMsg> msg2) { return msg1.Item3.getTime().CompareTo(msg2.Item3.getTime()); });
            ComponentFunctions.refreshAll();
        }

        public static void initializeChat(string chatId)
        {
            currentChatId = chatId;
            ComponentFunctions.refreshAll();
        }

        public static void initializeChatInvite()
        {
            friendsInvitedToChat.Clear();
            ComponentFunctions.refreshAll();
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

        public static List<Tuple<string, string, TupleEachMsg>> getCurrentChatList()
        {
            return currentChatList;
        }

        public static string getCurrentChatId()
        {
            return currentChatId;
        }

        public static TupleOneChatLog getCurrentChatLog()
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
            ComponentFunctions.refreshAll();
        }

        public static void addFriendReqToList(string item)
        {
            currentFriendReq.Add(item);
            ComponentFunctions.refreshAll();
        }

        public static void addInvToList(string item)
        {
            currentChatInv.Add(item);
            ComponentFunctions.refreshAll();
        }

        public static void addNewChatToList(Tuple<string, string, TupleEachMsg> item)
        {
            currentChatList.Add(item);
            ComponentFunctions.refreshAll();
        }

        public static void addChatLogToList(TupleEachMsg item)
        {
            currentChatLog.Add(item);
            ComponentFunctions.refreshAll();
        }

        public static void remFriendFromList(string item)
        {
            currentFriendList.Remove(item);
            ComponentFunctions.refreshAll();
        }

        public static void remFriendReqFromList(string item)
        {
            currentFriendReq.Remove(item);
            ComponentFunctions.refreshAll();
        }

        public static void remInvFromList(string item)
        {
            currentChatInv.Remove(item);
            ComponentFunctions.refreshAll();
        }

        public static void addFriendToChatCreateList(string item)
        {
            friendsInvitedToChat.Add(item);
            ComponentFunctions.refreshAll();
        }

        public static void initializeChat(int chatId)
        {
            initializeChat(chatId.ToString());
        }
    }
}
