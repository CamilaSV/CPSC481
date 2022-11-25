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
    public static class API_ChatInfo
    {
        public static void loadChatInfo(ChatInfoScreen infoScreen)
        {

            PageNavigator.gotoChatInfo();
        }
    }
}
