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
    public static class Logic_ChatInvites
    {
        public static ObservableCollection<propertyChange_ChatInvite> displayUsersGroupInviteList()
        {
            ObservableCollection<propertyChange_ChatInvite> invListCollection = new ObservableCollection<propertyChange_ChatInvite>();

            foreach (Tuple<string, string, TupleEachMsg> lastmsg in SessionData.getCurrentChatInv())
            {
                propertyChange_ChatInvite invItem = new propertyChange_ChatInvite
                {
                    ChatId = lastmsg.Item1,
                    ChatName = lastmsg.Item2,
                    ChatLastSender = lastmsg.Item3.getEmail(),
                    ChatLastMsg = lastmsg.Item3.getMessage(),

                    ChatLastTime = SharedFunctions.getDateOrTimefromEpoch(lastmsg.Item3.getTime()),
                };
                invListCollection.Add(invItem);
            }

            return invListCollection;
        }

        public static void acceptChatInvite(string emailUser, string chatId)
        {
            SharedFunctions.appendLineToFile(PathFinder.getChatMembers(chatId), emailUser);
            removeChatInvite(emailUser, chatId);

            SharedFunctions.appendLineToFile(PathFinder.getAccChats(emailUser), chatId);
            Directory.CreateDirectory(PathFinder.getAccFutSchGroupDir(emailUser, chatId));
            Directory.CreateDirectory(PathFinder.getAccCompSchGroupDir(emailUser, chatId));

            SharedFunctions.appendLineToFile(PathFinder.getChatLogSender(chatId), "");
            SharedFunctions.appendLineToFile(PathFinder.getChatLogMessage(chatId),
                SharedFunctions.getFirstLineFromFile(PathFinder.getAccName(emailUser)) + " has joined the group.");
            SharedFunctions.appendLineToFile(PathFinder.getChatLogTime(chatId), SharedFunctions.getCurrentEpochTime());
        }

        public static void removeChatInvite(string emailUser, string chatId)
        {
            SharedFunctions.removeLineFromFile(PathFinder.getAccChatInv(emailUser), chatId);
        }

        public static void acceptChatInvite(string emailUser, int chatId)
        {
            acceptChatInvite(emailUser, chatId.ToString());
        }

        public static void removeChatInvite(string emailUser, int chatId)
        {
            removeChatInvite(emailUser, chatId.ToString());
        }
    }
}
