using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CPSC481Group12FoodyApp
{
    public class propertyChange_ChatScreen
    {
        public string IsUser_abbreviation { get; set; }
        public string IsUser_chatSenderEmail { get; set; }
        public string IsUser_chatSenderName { get; set; }
        public string IsUser_chatMsg { get; set; }
        public string IsUser_chatTime { get; set; }
        public string NotUser_abbreviation { get; set; }
        public string NotUser_chatSenderEmail { get; set; }
        public string NotUser_chatSenderName { get; set; }
        public string NotUser_chatMsg { get; set; }
        public string NotUser_chatTime { get; set; }
    }
}
