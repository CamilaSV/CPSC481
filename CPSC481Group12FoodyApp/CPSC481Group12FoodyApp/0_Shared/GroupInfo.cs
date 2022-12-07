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
        public List<long> suggestedTimes { get; set; }

        public GroupInfo()
        {
            adminList = new List<string>();
            memberList = new List<string>();
            customCriteriaList= new Dictionary<string, int>();
            restaurantList= new List<int>();
            msgList = new List<MsgInfo>();
            eventList = new List<EventInfo>();
            suggestedTimes = new List<long>();
        }
    }
}
