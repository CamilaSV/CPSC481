﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Printing;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class Logic_Chat
    {
        public static void sendMsg(string emailSender, int groupId, string chatMsg)
        {
            SessionData.stopTimer();
            SessionData.updateGroupInfoFromDB();
            SessionData.addGroupMsg(groupId, emailSender, chatMsg);
            SessionData.saveGroupInfoToDB();
            ComponentFunctions.refreshAll();
            SessionData.startTimer();
        }

        public static void sendMsg(string emailSender, string groupId, string chatMsg)
        {
            sendMsg(emailSender, Int32.Parse(groupId), chatMsg);
        }
    }
}
