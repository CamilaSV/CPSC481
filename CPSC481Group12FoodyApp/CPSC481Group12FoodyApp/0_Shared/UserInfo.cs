using System;
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
        public List<int> criteriaChecked { get; set; }

        public UserInfo()
        {
            friendList = new List<string>();
            friendReqList = new List<string>();
            groupList = new List<int>();
            categoryList = new List<CategoryInfo>();
            eventList = new List<UserEventInfo>();
            invitationList = new List<InvitationInfo>();
            criteriaChecked = new List<int>();
        }

        public UserInfo(string emailUser, string password)
        {
            password = password;
            name = emailUser;
            bio = "I am a bio. Press edit button to edit me.";
            friendList = new List<string>();
            friendReqList = new List<string>();
            groupList = new List<int>();
            categoryList = new List<CategoryInfo>();
            eventList = new List<UserEventInfo>();
            invitationList = new List<InvitationInfo>();
            criteriaChecked = new List<int>();
        }

        public UserInfo(string emailUser, string password, string bio)
        {
            password = password;
            name = emailUser;
            bio = bio;
            friendList = new List<string>();
            friendReqList = new List<string>();
            groupList = new List<int>();
            categoryList = new List<CategoryInfo>();
            eventList = new List<UserEventInfo>();
            invitationList = new List<InvitationInfo>();
            criteriaChecked = new List<int>();
        }
    }
}
