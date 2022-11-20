using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;

namespace CPSC481Group12FoodyApp
{
    public static class PathFinder
    {
        private const string accDir = ".\\DB\\Accounts\\";
        private const string acc_email = "\\email.dat";
        private const string acc_pw = "\\password.dat";
        private const string acc_name = "\\display_name.dat";
        private const string acc_bio = "\\bio.dat";
        private const string acc_inv = "\\invitations.dat";
        private const string acc_fr = "\\friends.dat";
        private const string acc_chats = "\\chats.dat";
        private const string acc_cat = "\\saved_cat.dat";

        private const string chatDir = ".\\DB\\Chats\\";
        private const string chat_name = ".\\name.dat";
        private const string chat_admin = "\\admin.dat";
        private const string chat_member = "\\members.dat";
        private const string chat_log = "\\chat_log.dat";

        private const string both_res = "\\saved_res.dat";
        private const string both_fut = "\\future_sch.dat";
        private const string both_comp = "\\comp_sch.dat";


        public static string getAccDir(string email)
        {
            return accDir + email;
        }

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

        public static string getAccInv(string email)
        {
            return getAccDir(email) + acc_inv;
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

        public static string getAccFutSch(string email)
        {
            return getAccDir(email) + both_fut;
        }

        public static string getAccCompSch(string email)
        {
            return getAccDir(email) + both_comp;
        }

        // string arguments
        public static string getChatDir(string chatId)
        {
            return chatDir + chatId;
        }

        public static string getChatName(string chatId)
        {
            return getChatDir(chatId) + chat_name;
        }

        public static string getChatAdmin(string chatId)
        {
            return getChatDir(chatId) + chat_admin;
        }

        public static string getChatMembers(string chatId)
        {
            return getChatDir(chatId) + chat_member;
        }

        public static string getChatLog(string chatId)
        {
            return getChatDir(chatId) + chat_log;
        }

        public static string getChatRestaurants(string chatId)
        {
            return getChatDir(chatId) + both_res;
        }

        public static string getChatFutSch(string chatId)
        {
            return getChatDir(chatId) + both_fut;
        }

        public static string getChatCompSch(string chatId)
        {
            return getChatDir(chatId) + both_comp;
        }

        // int arguments
        public static string getChatDir(int chatId)
        {
            return chatDir + chatId;
        }

        public static string getChatName(int chatId)
        {
            return getChatDir(chatId) + chat_name;
        }

        public static string getChatAdmin(int chatId)
        {
            return getChatDir(chatId) + chat_admin;
        }

        public static string getChatMembers(int chatId)
        {
            return getChatDir(chatId) + chat_member;
        }

        public static string getChatLog(int chatId)
        {
            return getChatDir(chatId) + chat_log;
        }

        public static string getChatRestaurants(int chatId)
        {
            return getChatDir(chatId) + both_res;
        }

        public static string getChatFutSch(int chatId)
        {
            return getChatDir(chatId) + both_fut;
        }

        public static string getChatCompSch(int chatId)
        {
            return getChatDir(chatId) + both_comp;
        }
    }
}
