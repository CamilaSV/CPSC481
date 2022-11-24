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

        // chat invitations from other users; shares same index
        private static List<string> currentChatInv_Id = new List<string>(); // chat id invitations
        private static List<string> currentChatInv_SenderEmail = new List<string>(); // whoever sent the invite

        private static List<Tuple<string, string>> currentEventList = new List<Tuple<string, string>>();

        // chat data
        private static string currentChatId;
        private static List<Tuple<string, string, TupleEachMsg>> currentChatList = new List<Tuple<string, string, TupleEachMsg>>(); // chat id, chat name, last message Tuple

        // data for one chat
        private static TupleOneChatLog currentChatLog;

        // data when creating chat
        private static List<string> friendsInvitedToChat = new List<string>(); // gets invitation to be sent to other users

        // data when creating event under here?


        public static void initializeUser(string email)
        {
            currentUserEmail = email;
            currentFriendList = File.ReadAllLines(PathFinder.getAccFriends(currentUserEmail)).ToList();
            currentFriendReq = File.ReadAllLines(PathFinder.getAccFriendReq(currentUserEmail)).ToList();
            initializeChatInvitesReceived();
            initializeChatList();
            initializeChatInvitesToSend();
        }

        public static void initializeChatList()
        {
            currentChatList = Logic_CreateLoadChat.loadChatList(currentUserEmail);
            currentChatList.Sort(delegate (Tuple<string, string, TupleEachMsg> msg1, Tuple<string, string, TupleEachMsg> msg2) { return long.Parse(msg1.Item3.getTime()).CompareTo(long.Parse(msg2.Item3.getTime())); });
        }

        public static void initializeChatInvitesReceived()
        {
            currentChatInv_Id = File.ReadAllLines(PathFinder.getAccChatInvId(currentUserEmail)).ToList();
            currentChatInv_SenderEmail = File.ReadAllLines(PathFinder.getAccChatInvSender(currentUserEmail)).ToList();
        }

        public static void initializeChatInvitesToSend()
        {
            friendsInvitedToChat.Clear();
        }

        public static void initializeChat(string chatId)
        {
            // not finished
            currentChatId = chatId;
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

        public static List<string> getCurrentChatInv_Id()
        {
            return currentChatInv_Id;
        }

        public static List<string> getCurrentChatInv_SenderEmail()
        {
            return currentChatInv_SenderEmail;
        }

        public static List<string> getfriendsInvitedToChat()
        {
            return friendsInvitedToChat;
        }

        public static void addFriendToList(string item)
        {
            currentFriendList.Add(item);
        }

        public static void addFriendReqToList(string item)
        {
            currentFriendReq.Add(item);
        }

        public static void addInvToList(string email, string chatId)
        {
            currentChatInv_Id.Add(chatId);
            currentChatInv_SenderEmail.Add(email);
        }

        public static void addNewChatToList(Tuple<string, string, TupleEachMsg> item)
        {
            currentChatList.Add(item);
        }

        public static void addChatLogToList(TupleEachMsg item)
        {
            currentChatLog.Add(item);
        }

        public static void remFriendFromList(string item)
        {
            currentFriendList.Remove(item);
        }

        public static void remFriendReqFromList(string item)
        {
            currentFriendReq.Remove(item);
        }

        public static void remInvFromList(string chatId)
        {
            // removes all invites from the same group; traverse in reverse so that it doesn't affect index number
            for (var i = currentChatInv_Id.Count - 1; i >= 0; i--)
            {
                if (currentChatInv_Id[i].Equals(chatId))
                {
                    currentChatInv_Id.RemoveAt(i);
                    currentChatInv_SenderEmail.RemoveAt(i);
                }
            }
        }

        public static void addFriendToChatCreateList(string item)
        {
            friendsInvitedToChat.Add(item);
        }

        public static void initializeChat(int chatId)
        {
            initializeChat(chatId.ToString());
        }
    }
}
