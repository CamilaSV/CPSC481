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

        public static void createMessage(string groupId, string msgId, string msgSender, string msgContent)
        {
            MsgId msg = new MsgId { groupId = groupId, id = msgId };
            MsgInfo info = new MsgInfo { 
                senderEmail = msgSender, 
                content = msgContent, 
                time = DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString(),
            };

            allMsgs[msg] = info;
        }

        // getters
        public static string getMessageSender(MsgId msgId)
        {
            return allMsgs[msgId].senderEmail;
        }

        public static string getMessageContent(MsgId msgId)
        {
            return allMsgs[msgId].content;
        }

        public static string getMessageTime(MsgId msgId)
        {
            return allMsgs[msgId].time;
        }

        // different types of arguments
        public static void createMessage(string groupId, int msgId, string msgSender, string msgContent)
        {
            createMessage(groupId.ToString(), msgId.ToString(), msgSender, msgContent);
        }

        public static void createMessage(int groupId, string msgId, string msgSender, string msgContent)
        {
            createMessage(groupId.ToString(), msgId.ToString(), msgSender, msgContent);
        }

        public static void createMessage(int groupId, int msgId, string msgSender, string msgContent)
        {
            createMessage(groupId.ToString(), msgId.ToString(), msgSender, msgContent);
        }

    }
}
