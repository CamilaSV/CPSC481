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
    public static class API_ChatScreen
    {
        public static void enterOneChat(ChatScreen chatScreen, string emailUser, string chatId)
        {
            List<TupleEachMsg> wholeChat = Logic_ChatScreen.enterOneChat(emailUser, chatId);

            SessionData.initializeChat(chatId);
            chatScreen.GroupNameBlock.Text = SessionData.getCurrentChatName();
            PageNavigator.gotoOneChat();
        }

        public static void enterOneChat(ChatScreen chatScreen, string emailUser, int chatId)
        {
            enterOneChat(chatScreen, emailUser, chatId.ToString());
        }
    }
}
