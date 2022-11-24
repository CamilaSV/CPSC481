using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class PathFinder
    {
        // get paths for restaurant data
        public static string getResDir(string restaurantId) {
            return resDir + restaurantId + "\\";
        }

        public static string getRestaurantId(string restaurantId)
        {
            return getResDir(restaurantId) + res_id;
        }

        public static string getRestaurantName(string restaurantId)
        {
            return getResDir(restaurantId) + res_name;
        }

        public static string getRestaurantCriteria(string restaurantId)
        {
            return getResDir(restaurantId) + res_criteria;
        }

        public static string getRestaurantAddress(string restaurantId)
        {
            return getResDir(restaurantId) + res_address;
        }

        // get directory path for the account
        public static string getAccDir(string email)
        {
            return accDir + email + "\\";
        }

        public static string getAccCatDir(string email)
        {
            return getAccDir(email) + accCatDir;
        }

        public static string getAccOneCategoryDir(string email, string categoryId)
        {
            return getAccCatDir(email) + categoryId + "\\";
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

        public static string getAccCompSchGroupDir(string email, string chatId)
        {
            return getAccCompSchDir(email) + chatId + "\\";
        }

        // get directory path for the group
        public static string getChatDir(string chatId)
        {
            return chatDir + chatId + "\\";
        }

        // get directory path for the group's events folder
        public static string getChatFutSchDir(string chatId)
        {
            return getChatDir(chatId) + scheduleEventDir;
        }

        public static string getChatCompSchDir(string chatId)
        {
            return getChatDir(chatId) + completeEventDir;
        }

        // get directory path for the group's specific event
        public static string getChatFutSchEvDir(string chatId, string eventId)
        {
            return getChatFutSchDir(chatId) + eventId + "\\";
        }

        public static string getChatCompSchEvDir(string chatId, string eventId)
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

        public static string getAccChatInvId(string email)
        {
            return getAccDir(email) + acc_inv_id;
        }

        public static string getAccChatInvSender(string email)
        {
            return getAccDir(email) + acc_inv_sender;
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

        public static string getAccOneCategoryName(string email, string categoryId)
        {
            return getAccOneCategoryDir(email, categoryId) + accCat_name;
        }

        public static string getAccOneCategoryRestaurants(string email, string categoryId)
        {
            return getAccOneCategoryDir(email, categoryId) + accCat_res;
        }

        // get file path for the group's specific event's restaurant name
        public static string getAccFutSchGroupEvId(string email, string chatId, string eventId)
        {
            return getAccFutSchGroupDir(email, chatId) + ev_id;
        }

        public static string getAccCompSchGroupEvId(string email, string chatId, string eventId)
        {
            return getAccCompSchGroupDir(email, chatId) + ev_id;
        }

        public static string getAccFutSchGroupEvName(string email, string chatId, string eventId)
        {
            return getAccFutSchGroupDir(email, chatId) + ev_resname;
        }

        public static string getAccCompSchGroupEvName(string email, string chatId, string eventId)
        {
            return getAccCompSchGroupDir(email, chatId) + ev_resname;
        }

        // get file path for the group's specific event's date
        public static string getAccFutSchGroupEvDate(string email, string chatId, string eventId)
        {
            return getAccFutSchGroupDir(email, chatId) + ev_date;
        }

        public static string getAccCompSchGroupEvDate(string email, string chatId, string eventId)
        {
            return getAccCompSchGroupDir(email, chatId) + ev_date;
        }

        // get file paths for the group
        public static string getChatId(string chatId)
        {
            return getChatDir(chatId) + chat_id;
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

        public static string getChatLogSender(string chatId)
        {
            return getChatDir(chatId) + chat_log_sender;
        }

        public static string getChatLogMessage(string chatId)
        {
            return getChatDir(chatId) + chat_log_message;
        }

        public static string getChatLogTime(string chatId)
        {
            return getChatDir(chatId) + chat_log_time;
        }

        public static string getChatSavedRestaurants(string chatId)
        {
            return getChatDir(chatId) + chat_restaurants;
        }

        // get file path for the group's specific event's reataurant name
        public static string getChatFutSchEvName(string chatId, string eventId)
        {
            return getChatFutSchEvDir(chatId, eventId) + ev_resname;
        }

        public static string getChatCompSchEvName(string chatId, string eventId)
        {
            return getChatCompSchEvDir(chatId, eventId) + ev_resname;
        }

        // get file path for the group's specific event's date
        public static string getChatFutSchEvDate(string chatId, string eventId)
        {
            return getChatFutSchEvDir(chatId, eventId) + ev_date;
        }

        public static string getChatCompSchEvDate(string chatId, string eventId)
        {
            return getChatCompSchEvDir(chatId, eventId) + ev_resname;
        }

        // these are put here just to send important methods to the top
        private const string accDir = "DB\\Accounts\\";

        private const string acc_email = "email.dat";
        private const string acc_pw = "password.dat";
        private const string acc_name = "display_name.dat";
        private const string acc_bio = "bio.dat";
        private const string acc_inv_id = "chat_invitations_id.dat";
        private const string acc_inv_sender = "chat_invitations_sender.dat";
        private const string acc_req = "friend_requests.dat";
        private const string acc_fr = "friends.dat";
        private const string acc_chats = "chats.dat";

        private const string accCatDir = "Categories\\";
        private const string accCat_name = "category_name.dat";
        private const string accCat_res = "restaurants.dat";

        private const string chatDir = "DB\\Groups\\";
        private const string chat_id = "chat_id.dat";
        private const string chat_name = "name.dat";
        private const string chat_admin = "admin.dat";
        private const string chat_member = "members.dat";
        private const string chat_log_sender = "chat_log_sender.dat";
        private const string chat_log_message = "chat_log_message.dat";
        private const string chat_log_time = "chat_log_time.dat";
        private const string chat_restaurants = "saved_res.dat";

        private const string scheduleEventDir = "Events\\Schedule\\";
        private const string completeEventDir = "Events\\Complete\\";

        private const string ev_id = "event_id.dat";
        private const string ev_resname = "restaurant_name.dat";
        private const string ev_date = "date.dat";

        private const string resDir = "DB\\Restaurants\\";
        private const string res_id = "res_id.dat";
        private const string res_name = "res_name.dat";
        private const string res_criteria = "res_criteria.dat";
        private const string res_address = "res_address.dat";

        // polymorphism methods go down here
        public static string getResDir(int restaurantId)
        {
            return getResDir(restaurantId.ToString());
        }

        public static string getRestaurantId(int restaurantId)
        {
            return getRestaurantId(restaurantId.ToString());
        }

        public static string getRestaurantName(int restaurantId)
        {
            return getRestaurantName(restaurantId.ToString());
        }

        public static string getRestaurantCriteria(int restaurantId)
        {
            return getRestaurantCriteria(restaurantId.ToString());
        }

        public static string getRestaurantAddress(int restaurantId)
        {
            return getRestaurantAddress(restaurantId.ToString());
        }

        public static string getAccOneCategoryDir(string email, int categoryId)
        {
            return getAccOneCategoryDir(email, categoryId.ToString());
        }

        public static string getAccFutSchGroupDir(string email, int chatId)
        {
            return getAccFutSchGroupDir(email, chatId.ToString());
        }

        public static string getAccCompSchGroupDir(string email, int chatId)
        {
            return getAccCompSchGroupDir(email, chatId.ToString());
        }

        public static string getAccOneCategoryName(string email, int categoryId)
        {
            return getAccOneCategoryName(email, categoryId.ToString());
        }

        public static string getAccOneCategoryRestaurants(string email, int categoryId)
        {
            return getAccOneCategoryRestaurants(email, categoryId.ToString());
        }

        public static string getChatDir(int chatId)
        {
            return getChatDir(chatId.ToString());
        }

        public static string getChatFutSchDir(int chatId)
        {
            return getChatFutSchDir(chatId.ToString());
        }

        public static string getChatCompSchDir(int chatId)
        {
            return getChatCompSchDir(chatId.ToString());
        }

        public static string getChatFutSchEvDir(string chatId, int eventId)
        {
            return getChatFutSchEvDir(chatId.ToString(), eventId.ToString());
        }

        public static string getChatFutSchEvDir(int chatId, string eventId)
        {
            return getChatFutSchEvDir(chatId.ToString(), eventId.ToString());
        }

        public static string getChatFutSchEvDir(int chatId, int eventId)
        {
            return getChatFutSchEvDir(chatId.ToString(), eventId.ToString());
        }

        public static string getChatCompSchEvDir(string chatId, int eventId)
        {
            return getChatCompSchEvDir(chatId.ToString(), eventId.ToString());
        }

        public static string getChatCompSchEvDir(int chatId, string eventId)
        {
            return getChatCompSchEvDir(chatId.ToString(), eventId.ToString());
        }

        public static string getChatCompSchEvDir(int chatId, int eventId)
        {
            return getChatCompSchEvDir(chatId.ToString(), eventId.ToString());
        }

        public static string getAccFutSchGroupEvId(string email, string chatId, int eventId)
        {
            return getAccFutSchGroupEvId(email, chatId.ToString(), eventId.ToString());
        }

        public static string getAccFutSchGroupEvId(string email, int chatId, string eventId)
        {
            return getAccFutSchGroupEvId(email, chatId.ToString(), eventId.ToString());
        }

        public static string getAccFutSchGroupEvId(string email, int chatId, int eventId)
        {
            return getAccFutSchGroupEvId(email, chatId.ToString(), eventId.ToString());
        }

        public static string getAccCompSchGroupEvId(string email, string chatId, int eventId)
        {
            return getAccCompSchGroupEvId(email, chatId.ToString(), eventId.ToString());
        }

        public static string getAccCompSchGroupEvId(string email, int chatId, string eventId)
        {
            return getAccCompSchGroupEvId(email, chatId.ToString(), eventId.ToString());
        }

        public static string getAccCompSchGroupEvId(string email, int chatId, int eventId)
        {
            return getAccCompSchGroupEvId(email, chatId.ToString(), eventId.ToString());
        }

        public static string getAccFutSchGroupEvName(string email, string chatId, int eventId)
        {
            return getAccFutSchGroupEvName(email, chatId.ToString(), eventId.ToString());
        }

        public static string getAccFutSchGroupEvName(string email, int chatId, string eventId)
        {
            return getAccFutSchGroupEvName(email, chatId.ToString(), eventId.ToString());
        }

        public static string getAccFutSchGroupEvName(string email, int chatId, int eventId)
        {
            return getAccFutSchGroupEvName(email, chatId.ToString(), eventId.ToString());
        }

        public static string getAccCompSchGroupEvName(string email, string chatId, int eventId)
        {
            return getAccCompSchGroupEvName(email, chatId.ToString(), eventId.ToString());
        }

        public static string getAccCompSchGroupEvName(string email, int chatId, string eventId)
        {
            return getAccCompSchGroupEvName(email, chatId.ToString(), eventId.ToString());
        }

        public static string getAccCompSchGroupEvName(string email, int chatId, int eventId)
        {
            return getAccCompSchGroupEvName(email, chatId.ToString(), eventId.ToString());
        }

        public static string getAccFutSchGroupEvDate(string email, string chatId, int eventId)
        {
            return getAccFutSchGroupEvDate(email, chatId.ToString(), eventId.ToString());
        }

        public static string getAccFutSchGroupEvDate(string email, int chatId, string eventId)
        {
            return getAccFutSchGroupEvDate(email, chatId.ToString(), eventId.ToString());
        }

        public static string getAccFutSchGroupEvDate(string email, int chatId, int eventId)
        {
            return getAccFutSchGroupEvDate(email, chatId.ToString(), eventId.ToString());
        }

        public static string getAccCompSchGroupEvDate(string email, string chatId, int eventId)
        {
            return getAccCompSchGroupEvDate(email, chatId.ToString(), eventId.ToString());
        }

        public static string getAccCompSchGroupEvDate(string email, int chatId, string eventId)
        {
            return getAccCompSchGroupEvDate(email, chatId.ToString(), eventId.ToString());
        }

        public static string getAccCompSchGroupEvDate(string email, int chatId, int eventId)
        {
            return getAccCompSchGroupEvDate(email, chatId.ToString(), eventId.ToString());
        }

        public static string getChatId(int chatId)
        {
            return getChatId(chatId.ToString());
        }

        public static string getChatName(int chatId)
        {
            return getChatName(chatId.ToString());
        }

        public static string getChatAdmin(int chatId)
        {
            return getChatAdmin(chatId.ToString());
        }

        public static string getChatMembers(int chatId)
        {
            return getChatMembers(chatId.ToString());
        }

        public static string getChatLogSender(int chatId)
        {
            return getChatLogSender(chatId.ToString());
        }

        public static string getChatLogMessage(int chatId)
        {
            return getChatLogMessage(chatId.ToString());
        }

        public static string getChatLogTime(int chatId)
        {
            return getChatLogTime(chatId.ToString());
        }

        public static string getChatSavedRestaurants(int chatId)
        {
            return getChatSavedRestaurants(chatId.ToString());
        }

        public static string getChatFutSchEvName(string chatId, int eventId)
        {
            return getChatFutSchEvName(chatId.ToString(), eventId.ToString());
        }

        public static string getChatFutSchEvName(int chatId, string eventId)
        {
            return getChatFutSchEvName(chatId.ToString(), eventId.ToString());
        }

        public static string getChatFutSchEvName(int chatId, int eventId)
        {
            return getChatFutSchEvName(chatId.ToString(), eventId.ToString());
        }

        public static string getChatCompSchEvName(string chatId, int eventId)
        {
            return getChatCompSchEvName(chatId.ToString(), eventId.ToString());
        }

        public static string getChatCompSchEvName(int chatId, string eventId)
        {
            return getChatCompSchEvName(chatId.ToString(), eventId.ToString());
        }

        public static string getChatCompSchEvName(int chatId, int eventId)
        {
            return getChatCompSchEvName(chatId.ToString(), eventId.ToString());
        }

        public static string getChatFutSchEvDate(string chatId, int eventId)
        {
            return getChatFutSchEvDate(chatId.ToString(), eventId.ToString());
        }

        public static string getChatFutSchEvDate(int chatId, string eventId)
        {
            return getChatFutSchEvDate(chatId.ToString(), eventId.ToString());
        }

        public static string getChatFutSchEvDate(int chatId, int eventId)
        {
            return getChatFutSchEvDate(chatId.ToString(), eventId.ToString());
        }

        public static string getChatCompSchEvDate(string chatId, int eventId)
        {
            return getChatCompSchEvDate(chatId.ToString(), eventId.ToString());
        }

        public static string getChatCompSchEvDate(int chatId, string eventId)
        {
            return getChatCompSchEvDate(chatId.ToString(), eventId.ToString());
        }

        public static string getChatCompSchEvDate(int chatId, int eventId)
        {
            return getChatCompSchEvDate(chatId.ToString(), eventId.ToString());
        }
    }
}
