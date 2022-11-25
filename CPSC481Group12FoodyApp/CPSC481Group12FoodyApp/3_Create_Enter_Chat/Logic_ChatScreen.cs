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
        public static ObservableCollection<propertyChange_ChatScreen> displayChatMsgList()
        {
            ObservableCollection<propertyChange_ChatScreen> chatMsgCollection = new ObservableCollection<propertyChange_ChatScreen>();

            foreach (TupleEachMsg oneMsg in SessionData.getCurrentChatLog())
            {
                if (oneMsg.getEmail().Equals(SessionData.getCurrentEmail()))
                {
                    chatMsgCollection.Add(new propertyChange_ChatScreen
                    {
                        IsUser_abbreviation = oneMsg.getEmail().Substring(0, 1),
                        IsUser_chatSenderEmail = oneMsg.getEmail(),
                        IsUser_chatSenderName = SharedFunctions.getFirstLineFromFile(PathFinder.getAccName(oneMsg.getEmail())),
                        IsUser_chatMsg = oneMsg.getMessage(),
                        IsUser_chatTime = oneMsg.getTime(),
                    } );
                }
                else
                {
                    chatMsgCollection.Add(new propertyChange_ChatScreen
                    {
                        NotUser_abbreviation = oneMsg.getEmail().Substring(0, 1),
                        NotUser_chatSenderEmail = oneMsg.getEmail(),
                        NotUser_chatSenderName = SharedFunctions.getFirstLineFromFile(PathFinder.getAccName(oneMsg.getEmail())),
                        NotUser_chatMsg = oneMsg.getMessage(),
                        NotUser_chatTime = oneMsg.getTime(),
                    });
                }
            }

            return chatMsgCollection;
        }

        public static List<TupleEachMsg> enterOneChat(string emailUser, string chatId)
        {
            string chatName = SharedFunctions.getFirstLineFromFile(PathFinder.getChatName(chatId));
            string[] emails = File.ReadAllLines(PathFinder.getChatLogSender(chatId));
            string[] messages = File.ReadAllLines(PathFinder.getChatLogMessage(chatId));
            string[] times = File.ReadAllLines(PathFinder.getChatLogTime(chatId));

            List<TupleEachMsg> msgs = new List<TupleEachMsg>();

            for (int i = 0; i < emails.Length; i++)
            {
                msgs.Add(new TupleEachMsg(emails[i], messages[i], times[i]));
            }

            return msgs;
        }

        public static List<TupleEachMsg> enterOneChat(string emailUser, int chatId)
        {
            return enterOneChat(emailUser, chatId.ToString());
        }
    }
}
