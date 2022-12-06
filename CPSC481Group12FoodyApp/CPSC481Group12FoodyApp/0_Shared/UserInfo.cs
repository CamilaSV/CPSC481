﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
namespace CPSC481Group12FoodyApp.Logic
{
    public class UserInfo
    {
        public string password { get; set; }
        public string name { get; set; }
        public string bio { get; set; }
        public List<string> friendList { get; set; }
        public List<string> friendReqList { get; set; }
        public List<int> groupList { get; set; }
        public List<CategoryInfo> categoryList { get; set; }
        public List<UserEventInfo> eventList { get; set; }
        public List<InvitationInfo> invitationList { get; set; }
        public List<CustomEventTimeInfo> suggestedTimes { get; set; }
    }
}
