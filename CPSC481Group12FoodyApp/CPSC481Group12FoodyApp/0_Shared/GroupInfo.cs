using System.Collections.Generic;
namespace CPSC481Group12FoodyApp.Logic
{
    public class GroupInfo
    {
        public string name { get; set; }
        public List<string> adminList { get; set; }
        public List<string> memberList { get; set; }
        public List<string> customCriteriaList { get; set; }
        public List<string> restaurantList { get; set; }
        public List<MsgId> msgList { get; set; }
        public List<EventId> eventList { get; set; }
    }
}
