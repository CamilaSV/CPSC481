using System.Collections.Generic;
namespace CPSC481Group12FoodyApp.Logic
{
    public class GroupInfo
    {
        public string name { get; set; }
        public List<string> adminList { get; set; }
        public List<string> memberList { get; set; }
        public Dictionary<string, int> customCriteriaList { get; set; } // email, criterionId
        public List<int> restaurantList { get; set; }
        public List<MsgInfo> msgList { get; set; }
        public List<EventInfo> eventList { get; set; }
    }
}
