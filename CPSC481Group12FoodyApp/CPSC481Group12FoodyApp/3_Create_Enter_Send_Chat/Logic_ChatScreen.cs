using CPSC481Group12FoodyApp._3_Create_Enter_Send_Chat.chat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Printing;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class Logic_ChatScreen
    {

        public static ObservableCollection<ChatBoxDesignModel> displayChatModels()
        {
            ObservableCollection<ChatBoxDesignModel> chatMsgCollection = new ObservableCollection<ChatBoxDesignModel>();
            string email;
            string abbreviation;
            string name;

            for (int i = 0; i < SessionData.getCurrentChatLog_Sender().Count; i++)
            {
                email = SessionData.getCurrentChatLog_Sender()[i];
                if (String.IsNullOrEmpty(email))
                {
                    abbreviation = "";
                    name = "";
                }
                else
                {
                    abbreviation = SessionData.getCurrentChatLog_Sender()[i].Substring(0, 1);
                    name = SharedFunctions.getFirstLineFromFile(PathFinder.getAccName(email));
                }

                if (email.Equals(SessionData.getCurrentEmail()))
                {
                    chatMsgCollection.Add(new ChatBoxDesignModel
                    {
                        IsUser_abbreviation = abbreviation,
                        IsUser_chatSenderEmail = email,
                        IsUser_chatSenderName = name,
                        IsUser_chatMsg = SessionData.getCurrentChatLog_Message()[i],
                        IsUser_chatTime = SessionData.getCurrentChatLog_Time()[i],
                    });
                }
                else
                {
                    chatMsgCollection.Add(new ChatBoxDesignModel
                    {
                        NotUser_abbreviation = abbreviation,
                        NotUser_chatSenderEmail = email,
                        NotUser_chatSenderName = name,
                        NotUser_chatMsg = SessionData.getCurrentChatLog_Message()[i],
                        NotUser_chatTime = SessionData.getCurrentChatLog_Time()[i],
                    });
                }
            }

            return chatMsgCollection;
        }

        public static ObservableCollection<propertyChange_ChatScreen> displayChatMsgList()
        {
            ObservableCollection<propertyChange_ChatScreen> chatMsgCollection = new ObservableCollection<propertyChange_ChatScreen>();
            string email;
            string abbreviation;
            string name;

            for (int i = 0; i < SessionData.getCurrentChatLog_Sender().Count; i++)
            {
                email = SessionData.getCurrentChatLog_Sender()[i];
                if (String.IsNullOrEmpty(email))
                {
                    abbreviation = "";
                    name = "";
                }
                else
                {
                    abbreviation = SessionData.getCurrentChatLog_Sender()[i].Substring(0, 1);
                    name = SharedFunctions.getFirstLineFromFile(PathFinder.getAccName(email));
                }

                if (email.Equals(SessionData.getCurrentEmail()))
                {
                    chatMsgCollection.Add(new propertyChange_ChatScreen
                    {
                        IsUser_abbreviation = abbreviation,
                        IsUser_chatSenderEmail = email,
                        IsUser_chatSenderName = name,
                        IsUser_chatMsg = SessionData.getCurrentChatLog_Message()[i],
                        IsUser_chatTime = SessionData.getCurrentChatLog_Time()[i],
                    } );
                }
                else
                {
                    chatMsgCollection.Add(new propertyChange_ChatScreen
                    {
                        NotUser_abbreviation = abbreviation,
                        NotUser_chatSenderEmail = email,
                        NotUser_chatSenderName = name,
                        NotUser_chatMsg = SessionData.getCurrentChatLog_Message()[i],
                        NotUser_chatTime = SessionData.getCurrentChatLog_Time()[i],
                    });
                }
            }

            return chatMsgCollection;
        }

        public static List<TupleEachMsg> enterOneChat(string emailUser, string chatId)
        {
            string chatName = SharedFunctions.getFirstLineFromFile(PathFinder.getChatName(chatId));

            int firstNonExistingDir = SharedFunctions.findFirstNonExistingMsgDirNumber(chatId);

            string email;
            string message;
            string time;

            List<TupleEachMsg> msgs = new List<TupleEachMsg>();

            for (int i = 0; i < firstNonExistingDir; i++)
            {
                email = SharedFunctions.getFirstLineFromFile(PathFinder.getChatOneMsgSender(chatId, SharedFunctions.findLastExistingDirNumber(chatId)));
                message = File.ReadAllText(PathFinder.getChatOneMsgMessage(chatId, SharedFunctions.findLastExistingDirNumber(chatId)));
                time = SharedFunctions.getFirstLineFromFile(PathFinder.getChatOneMsgTime(chatId, SharedFunctions.findLastExistingDirNumber(chatId)));
                msgs.Add(new TupleEachMsg(email, message, time));
            }

            return msgs;
        }

        public static void sendMsg(string emailSender, string chatId, string chatMsg, string chatTime)
        {
            int firstNonExistingDir = SharedFunctions.findFirstNonExistingMsgDirNumber(chatId);

            Directory.CreateDirectory(PathFinder.getChatOneMsgDir(chatId, firstNonExistingDir));

            SharedFunctions.appendLineToFile(PathFinder.getChatOneMsgSender(chatId, firstNonExistingDir), emailSender);
            SharedFunctions.appendLineToFile(PathFinder.getChatOneMsgTime(chatId, firstNonExistingDir), chatTime);
            // newline must not be made here
            StreamWriter fileWriter = File.CreateText(PathFinder.getChatOneMsgMessage(chatId, firstNonExistingDir));
            fileWriter.Write(chatMsg);
            fileWriter.Close();
        }

        public static List<TupleEachMsg> enterOneChat(string emailUser, int chatId)
        {
            return enterOneChat(emailUser, chatId.ToString());
        }

        public static void sendMsg(string emailSender, int chatId, string chatMsg, string chatTime)
        {
            sendMsg(emailSender, chatId.ToString(), chatMsg, chatTime);
        }
    }
}
