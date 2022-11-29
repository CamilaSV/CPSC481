using System.Collections.Generic;
using System.Security.Policy;
using System.Windows.Documents;

namespace CPSC481Group12FoodyApp.Logic
{
    public class ProjComparer : IComparer<MsgInfo>, IComparer<EventInfo>, IComparer<UserEventInfo>
    {
        public int Compare(MsgInfo x, MsgInfo y)
        {
            return x.time.CompareTo(y.time);
        }

        public int Compare(EventInfo x, EventInfo y)
        {
            return x.time.CompareTo(y.time);
        }

        public int Compare(UserEventInfo x, UserEventInfo y)
        {
            return SessionData.getEventTime(x.groupId, x.eventId).CompareTo(SessionData.getEventTime(y.groupId, y.eventId));
        }
    }
}
