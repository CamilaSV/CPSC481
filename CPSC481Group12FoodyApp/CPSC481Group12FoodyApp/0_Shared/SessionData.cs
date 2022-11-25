using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class SessionData
    {
        // user data
        private static string currentUserEmail;
        private static List<string> currentUserFriendList;
        private static List<string> currentUserFriendReq;
        private static List<Tuple<string, string, TupleEachMsg>> currentUserChatList; // chat id, chat name, last message Tuple
        // chat invitations from other users; shares same index
        private static List<string> currentUserChatInv_Id; // chat id invitations
        private static List<string> currentUserChatInv_SenderEmail; // whoever sent the invite
        // event list used for personal calendar
        private static List<Tuple<string, string>> currentEventList;

        // data when creating chat
        private static List<string> friendsInvitedToChat; // gets invitation to be sent to other users

        // data for one chat's information
        private static string currentChatId;
        private static string currentChatName;
        private static List<TupleEachMsg> currentChatLog;
        // chat info
        private static List<string> currentChatMembers;
        private static List<string> currentChatCriteria;
        private static List<string> currentChatRestaurants;
        private static List<string> currentChatEventList;



        public static void initializeUser(string email)
        {
            currentUserEmail = email;
            currentUserFriendList = File.ReadAllLines(PathFinder.getAccFriends(currentUserEmail)).ToList();
            currentUserFriendReq = File.ReadAllLines(PathFinder.getAccFriendReq(currentUserEmail)).ToList();
            initializeChatInvitesReceived();
            initializeChatList();
            initializeChatInvitesToSend();
            initializeChatInfo();
        }

        public static void initializeChatList()
        {
            currentUserChatList = Logic_CreateLoadChat.loadChatList(currentUserEmail);
            currentUserChatList.Sort(delegate (Tuple<string, string, TupleEachMsg> msg1, Tuple<string, string, TupleEachMsg> msg2) { return long.Parse(msg2.Item3.getTime()).CompareTo(long.Parse(msg1.Item3.getTime())); });
            ComponentFunctions.refreshAll();
        }

        public static void initializeChatInvitesReceived()
        {
            currentUserChatInv_Id = File.ReadAllLines(PathFinder.getAccChatInvId(currentUserEmail)).ToList();
            currentUserChatInv_SenderEmail = File.ReadAllLines(PathFinder.getAccChatInvSender(currentUserEmail)).ToList();
            ComponentFunctions.refreshAll();
        }

        public static void initializeChatInvitesToSend()
        {
            friendsInvitedToChat = new List<string>();
            ComponentFunctions.refreshAll();
        }

        public static void initializeChat(string chatId)
        {
            // not finished
            currentChatId = chatId;
            ComponentFunctions.refreshAll();
        }

        public static void initializeChatInfo()
        {
            currentChatMembers = File.ReadAllLines(PathFinder.getChatMembers(currentUserEmail)).ToList();
            currentChatCriteria = File.ReadAllLines(PathFinder.getChatSavedCriteria(currentUserEmail)).ToList();
            currentChatRestaurants = File.ReadAllLines(PathFinder.getChatSavedRestaurants(currentUserEmail)).ToList();
            ComponentFunctions.refreshAll();
        }

        public static string getCurrentEmail()
        {
            return currentUserEmail;
        }

        public static List<string> getCurrentUserFriends()
        {
            return currentUserFriendList;
        }

        public static List<string> getCurrentUserFriendReq()
        {
            return currentUserFriendReq;
        }

        public static List<Tuple<string, string, TupleEachMsg>> getCurrentUserChatList()
        {
            return currentUserChatList;
        }

        public static string getCurrentChatId()
        {
            return currentChatId;
        }

        public static string getCurrentChatName()
        {
            return currentChatName;
        }

        public static List<TupleEachMsg> getCurrentChatLog()
        {
            return currentChatLog;
        }

        public static List<string> getCurrentUserChatInvId()
        {
            return currentUserChatInv_Id;
        }

        public static List<string> getCurrentUserChatInvSender()
        {
            return currentUserChatInv_SenderEmail;
        }

        public static List<string> getfriendsInvitedToChat()
        {
            return friendsInvitedToChat;
        }

        public static void addFriendToList(string item)
        {
            currentUserFriendList.Add(item);
            ComponentFunctions.refreshAll();
        }

        public static void addFriendReqToList(string item)
        {
            currentUserFriendReq.Add(item);
            ComponentFunctions.refreshAll();
        }

        public static void addInvToList(string email, string chatId)
        {
            currentUserChatInv_Id.Add(chatId);
            currentUserChatInv_SenderEmail.Add(email);
            ComponentFunctions.refreshAll();
        }

        public static void addNewChatToList(Tuple<string, string, TupleEachMsg> item)
        {
            currentUserChatList.Add(item);
            ComponentFunctions.refreshAll();
        }

        public static void addChatLogToList(TupleEachMsg item)
        {
            currentChatLog.Add(item);
            ComponentFunctions.refreshAll();
        }

        public static void remFriendFromList(string item)
        {
            currentUserFriendList.Remove(item);
            ComponentFunctions.refreshAll();
        }

        public static void remFriendReqFromList(string item)
        {
            currentUserFriendReq.Remove(item);
            ComponentFunctions.refreshAll();
        }

        public static void remOneInvFromList(string email, string chatId)
        {
            // removes one matching invite
            for (var i = 0; i < currentUserChatInv_Id.Count; i++)
            {
                if (currentUserChatInv_Id[i].Equals(chatId))
                {
                    if (currentUserChatInv_SenderEmail[i].Equals(email))
                    {
                        currentUserChatInv_Id.RemoveAt(i);
                        currentUserChatInv_SenderEmail.RemoveAt(i);

                        ComponentFunctions.refreshAll();
                        return;
                    }
                }
            }
        }

        public static void remAllInvFromList(string chatId)
        {
            // removes all invites from the same group; traverse in reverse so that it doesn't affect index number
            for (var i = currentUserChatInv_Id.Count - 1; i >= 0; i--)
            {
                if (currentUserChatInv_Id[i].Equals(chatId))
                {
                    currentUserChatInv_Id.RemoveAt(i);
                    currentUserChatInv_SenderEmail.RemoveAt(i);
                }
            }

            ComponentFunctions.refreshAll();
        }

        public static void remOneInvFromList(string email, int chatId)
        {
            remOneInvFromList(email, chatId.ToString());
        }

        public static void remAllInvFromList(int chatId)
        {
            remAllInvFromList(chatId.ToString());
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
