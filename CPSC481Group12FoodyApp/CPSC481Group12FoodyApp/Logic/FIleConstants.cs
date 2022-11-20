using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;

namespace CPSC481Group12FoodyApp
{
    public static class PathFinder
    {
        private const string accDir = "DB\\Accounts\\";
        private const string acc_email = "email.dat";
        private const string acc_pw = "password.dat";
        private const string acc_name = "display_name.dat";
        private const string acc_bio = "bio.dat";
        private const string acc_inv = "chat_invitations.dat";
        private const string acc_req = "friend_requests.dat";
        private const string acc_fr = "friends.dat";
        private const string acc_chats = "chats.dat";
        private const string acc_cat = "saved_cat.dat";

        private const string chatDir = "DB\\Groups\\";
        private const string chat_name = "name.dat";
        private const string chat_admin = "admin.dat";
        private const string chat_member = "members.dat";
        private const string chat_log = "chat_log.dat";

        private const string both_res = "saved_res.dat";

        private const string scheduleEventDir = "Events\\Schedule\\";
        private const string completeEventDir = "Events\\Complete\\";

        private const string ev_resname = "restaurant_name.dat";
        private const string ev_date = "date.dat";

        // get directory path for the account
        public static string getAccDir(string email)
        {
            return accDir + email + "\\";
        }

        // get directory path for the account's events
        public static string getAccFutSchDir(string email)
        {
            return getAccDir(email) + scheduleEventDir;
        }

        public static string getAccCompSchDir(string email)
        {
            return getAccDir(email) + completeEventDir;
        }

        // get directory path for the account's group-specific events
        public static string getAccFutSchGroupDir(string email, string chatId)
        {
            return getAccFutSchDir(email) + chatId + "\\";
        }

        public static string getAccFutSchGroupDir(string email, int chatId)
        {
            return getAccFutSchDir(email) + chatId + "\\";
        }

        public static string getAccCompSchGroupDir(string email, string chatId)
        {
            return getAccCompSchDir(email) + chatId + "\\";
        }

        public static string getAccCompSchGroupDir(string email, int chatId)
        {
            return getAccCompSchDir(email) + chatId + "\\";
        }

        // get directory path for the group
        public static string getChatDir(string chatId)
        {
            return chatDir + chatId + "\\";
        }

        public static string getChatDir(int chatId)
        {
            return chatDir + chatId + "\\";
        }

        // get directory path for the group's events folders
        public static string getChatFutSchDir(string chatId)
        {
            return getChatDir(chatId) + scheduleEventDir;
        }

        public static string getChatFutSchDir(int chatId)
        {
            return getChatDir(chatId) + scheduleEventDir;
        }

        public static string getChatCompSchDir(string chatId)
        {
            return getChatDir(chatId) + completeEventDir;
        }

        public static string getChatCompSchDir(int chatId)
        {
            return getChatDir(chatId) + completeEventDir;
        }

        // get directory path for the group's specific event
        public static string getChatFutSchEvDir(string chatId, string eventId)
        {
            return getChatFutSchDir(chatId) + eventId + "\\";
        }

        public static string getChatFutSchEvDir(string chatId, int eventId)
        {
            return getChatFutSchDir(chatId) + eventId + "\\";
        }

        public static string getChatFutSchEvDir(int chatId, string eventId)
        {
            return getChatFutSchDir(chatId) + eventId + "\\";
        }

        public static string getChatFutSchEvDir(int chatId, int eventId)
        {
            return getChatFutSchDir(chatId) + eventId + "\\";
        }

        public static string getChatCompSchEvDir(string chatId, string eventId)
        {
            return getChatCompSchDir(chatId) + eventId + "\\";
        }

        public static string getChatCompSchEvDir(string chatId, int eventId)
        {
            return getChatCompSchDir(chatId) + eventId + "\\";
        }

        public static string getChatCompSchEvDir(int chatId, string eventId)
        {
            return getChatCompSchDir(chatId) + eventId + "\\";
        }

        public static string getChatCompSchEvDir(int chatId, int eventId)
        {
            return getChatCompSchDir(chatId) + eventId + "\\";
        }

        // get file paths for the account
        public static string getAccEmail(string email)
        {
            return getAccDir(email) + acc_email;
        }

        public static string getAccPw(string email)
        {
            return getAccDir(email) + acc_pw;
        }

        public static string getAccName(string email)
        {
            return getAccDir(email) + acc_name;
        }

        public static string getAccBio(string email)
        {
            return getAccDir(email) + acc_bio;
        }

        public static string getAccChatInv(string email)
        {
            return getAccDir(email) + acc_inv;
        }

        public static string getAccFriendReq(string email)
        {
            return getAccDir(email) + acc_req;
        }

        public static string getAccFriends(string email)
        {
            return getAccDir(email) + acc_fr;
        }

        public static string getAccChats(string email)
        {
            return getAccDir(email) + acc_chats;
        }

        public static string getAccCategories(string email)
        {
            return getAccDir(email) + acc_cat;
        }

        public static string getAccRestaurants(string email)
        {
            return getAccDir(email) + both_res;
        }

        // get file path for the group's specific event's reataurant name
        public static string getAccFutSchGroupEvName(string email, string chatId, string eventId)
        {
            return getAccFutSchGroupDir(email, chatId) + ev_resname;
        }

        public static string getAccFutSchGroupEvName(string email, string chatId, int eventId)
        {
            return getAccFutSchGroupDir(email, chatId) + ev_resname;
        }

        public static string getAccFutSchGroupEvName(string email, int chatId, string eventId)
        {
            return getAccFutSchGroupDir(email, chatId) + ev_resname;
        }

        public static string getAccFutSchGroupEvName(string email, int chatId, int eventId)
        {
            return getAccFutSchGroupDir(email, chatId) + ev_resname;
        }

        public static string getAccCompSchGroupEvName(string email, string chatId, string eventId)
        {
            return getAccCompSchGroupDir(email, chatId) + ev_resname;
        }

        public static string getAccCompSchGroupEvName(string email, string chatId, int eventId)
        {
            return getAccCompSchGroupDir(email, chatId) + ev_resname;
        }

        public static string getAccCompSchGroupEvName(string email, int chatId, string eventId)
        {
            return getAccCompSchGroupDir(email, chatId) + ev_resname;
        }

        public static string getAccCompSchGroupEvName(string email, int chatId, int eventId)
        {
            return getAccCompSchGroupDir(email, chatId) + ev_resname;
        }

        // get file path for the group's specific event's date
        public static string getAccFutSchGroupEvDate(string email, string chatId, string eventId)
        {
            return getAccFutSchGroupDir(email, chatId) + ev_date;
        }

        public static string getAccFutSchGroupEvDate(string email, string chatId, int eventId)
        {
            return getAccFutSchGroupDir(email, chatId) + ev_date;
        }

        public static string getAccFutSchGroupEvDate(string email, int chatId, string eventId)
        {
            return getAccFutSchGroupDir(email, chatId) + ev_date;
        }

        public static string getAccFutSchGroupEvDate(string email, int chatId, int eventId)
        {
            return getAccFutSchGroupDir(email, chatId) + ev_date;
        }

        public static string getAccCompSchGroupEvDate(string email, string chatId, string eventId)
        {
            return getAccCompSchGroupDir(email, chatId) + ev_date;
        }

        public static string getAccCompSchGroupEvDate(string email, string chatId, int eventId)
        {
            return getAccCompSchGroupDir(email, chatId) + ev_date;
        }

        public static string getAccCompSchGroupEvDate(string email, int chatId, string eventId)
        {
            return getAccCompSchGroupDir(email, chatId) + ev_date;
        }

        public static string getAccCompSchGroupEvDate(string email, int chatId, int eventId)
        {
            return getAccCompSchGroupDir(email, chatId) + ev_date;
        }

        // get file paths for the group
        public static string getChatName(string chatId)
        {
            return getChatDir(chatId) + chat_name;
        }

        public static string getChatName(int chatId)
        {
            return getChatDir(chatId) + chat_name;
        }

        public static string getChatAdmin(string chatId)
        {
            return getChatDir(chatId) + chat_admin;
        }

        public static string getChatAdmin(int chatId)
        {
            return getChatDir(chatId) + chat_admin;
        }

        public static string getChatMembers(string chatId)
        {
            return getChatDir(chatId) + chat_member;
        }

        public static string getChatMembers(int chatId)
        {
            return getChatDir(chatId) + chat_member;
        }

        public static string getChatLog(string chatId)
        {
            return getChatDir(chatId) + chat_log;
        }

        public static string getChatLog(int chatId)
        {
            return getChatDir(chatId) + chat_log;
        }

        public static string getChatRestaurants(string chatId)
        {
            return getChatDir(chatId) + both_res;
        }

        public static string getChatRestaurants(int chatId)
        {
            return getChatDir(chatId) + both_res;
        }

        // get file path for the group's specific event's reataurant name
        public static string getChatFutSchEvName(string chatId, string eventId)
        {
            return getChatFutSchEvDir(chatId, eventId) + ev_resname;
        }

        public static string getChatFutSchEvName(string chatId, int eventId)
        {
            return getChatFutSchEvDir(chatId, eventId) + ev_resname;
        }

        public static string getChatFutSchEvName(int chatId, string eventId)
        {
            return getChatFutSchEvDir(chatId, eventId) + ev_resname;
        }

        public static string getChatFutSchEvName(int chatId, int eventId)
        {
            return getChatFutSchEvDir(chatId, eventId) + ev_resname;
        }

        public static string getChatCompSchEvName(string chatId, string eventId)
        {
            return getChatCompSchEvDir(chatId, eventId) + ev_resname;
        }

        public static string getChatCompSchEvName(string chatId, int eventId)
        {
            return getChatCompSchEvDir(chatId, eventId) + ev_resname;
        }

        public static string getChatCompSchEvName(int chatId, string eventId)
        {
            return getChatCompSchEvDir(chatId, eventId) + ev_resname;
        }

        public static string getChatCompSchEvName(int chatId, int eventId)
        {
            return getChatCompSchEvDir(chatId, eventId) + ev_resname;
        }

        // get file path for the group's specific event's date
        public static string getChatFutSchEvDate(string chatId, string eventId)
        {
            return getChatFutSchEvDir(chatId, eventId) + ev_date;
        }

        public static string getChatFutSchEvDate(string chatId, int eventId)
        {
            return getChatFutSchEvDir(chatId, eventId) + ev_date;
        }

        public static string getChatFutSchEvDate(int chatId, string eventId)
        {
            return getChatFutSchEvDir(chatId, eventId) + ev_date;
        }

        public static string getChatFutSchEvDate(int chatId, int eventId)
        {
            return getChatFutSchEvDir(chatId, eventId) + ev_date;
        }

        public static string getChatCompSchEvDate(string chatId, string eventId)
        {
            return getChatCompSchEvDir(chatId, eventId) + ev_resname;
        }

        public static string getChatCompSchEvDate(string chatId, int eventId)
        {
            return getChatCompSchEvDir(chatId, eventId) + ev_resname;
        }

        public static string getChatCompSchEvDate(int chatId, string eventId)
        {
            return getChatCompSchEvDir(chatId, eventId) + ev_resname;
        }

        public static string getChatCompSchEvDate(int chatId, int eventId)
        {
            return getChatCompSchEvDir(chatId, eventId) + ev_resname;
        }
    }
}
