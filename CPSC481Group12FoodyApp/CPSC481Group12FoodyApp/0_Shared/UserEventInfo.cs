using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
namespace CPSC481Group12FoodyApp.Logic
{
    public class UserEventInfo
    {
        public int groupId { get; set; }
        public int eventId { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            UserEventInfo other = obj as UserEventInfo;

            return (groupId == other.groupId) &&
                (eventId == other.eventId);
        }

        public override int GetHashCode()
        {
            return eventId.GetHashCode();
        }
    }
}
