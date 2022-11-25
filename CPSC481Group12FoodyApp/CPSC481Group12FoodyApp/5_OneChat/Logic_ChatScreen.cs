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
        public static TupleOneChatLog enterOneChat(string emailUser, string chatId)
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

            return new TupleOneChatLog(emailUser, chatName, msgs);
        }

        public static TupleOneChatLog enterOneChat(string emailUser, int chatId)
        {
            return enterOneChat(emailUser, chatId.ToString());
        }
    }
}
