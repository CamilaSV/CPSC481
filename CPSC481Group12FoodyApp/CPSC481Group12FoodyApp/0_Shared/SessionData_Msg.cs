using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text.Json;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class SessionData_Msg
    {
        private static Dictionary<MsgId, MsgInfo> allMsgs;

        public static void initializeStartup()
        {
            allMsgs = DBFunctions.getAllMessageInfo();
        }

        // getters
        public static string getMessageSender(string groupId, string msgId)
        {
            return allMsgs[new MsgId { groupId = groupId, id = msgId }].senderEmail;
        }

        public static string getMessageContent(string groupId, string msgId)
        {
            return allMsgs[new MsgId { groupId = groupId, id = msgId }].content;
        }

        public static string getMessageTime(string groupId, string msgId)
        {
            return allMsgs[new MsgId { groupId = groupId, id = msgId }].time;
        }

        // setters


        // different types of arguments
        public static string getMessageSender(string groupId, int msgId)
        {
            return getMessageSender(groupId.ToString(), msgId.ToString());
        }

        public static string getMessageSender(int groupId, string msgId)
        {
            return getMessageSender(groupId.ToString(), msgId.ToString());
        }

        public static string getMessageSender(int groupId, int msgId)
        {
            return getMessageSender(groupId.ToString(), msgId.ToString());
        }

        public static string getMessageContent(string groupId, int msgId)
        {
            return getMessageContent(groupId.ToString(), msgId.ToString());
        }

        public static string getMessageContent(int groupId, string msgId)
        {
            return getMessageContent(groupId.ToString(), msgId.ToString());
        }

        public static string getMessageContent(int groupId, int msgId)
        {
            return getMessageContent(groupId.ToString(), msgId.ToString());
        }

        public static string getMessageTime(string groupId, int msgId)
        {
            return getMessageTime(groupId.ToString(), msgId.ToString());
        }

        public static string getMessageTime(int groupId, string msgId)
        {
            return getMessageTime(groupId.ToString(), msgId.ToString());
        }

        public static string getMessageTime(int groupId, int msgId)
        {
            return getMessageTime(groupId.ToString(), msgId.ToString());
        }
    }
}
