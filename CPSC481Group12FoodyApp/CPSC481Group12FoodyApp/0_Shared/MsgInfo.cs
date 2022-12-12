using System;
using System.Collections.Generic;
namespace CPSC481Group12FoodyApp.Logic
{
    public class MsgInfo
    {
        public int id { get; set; }
        public string senderEmail { get; set; }
        public string content { get; set; }
        public long time { get; set; }
        public int evId { get; set; }
        public string resName { get; set; }
        public long evTime { get; set; }

        public MsgInfo() { }

        public MsgInfo(int msgId)
        {
            id = msgId;
        }

        public MsgInfo(int msgId, string msgSender, string msgContent)
        {
            id = msgId;
            senderEmail = msgSender;
            content = msgContent;
            evId = -1;
            evTime = 0;
            time = SessionData.getEpochFromDateOrTime(DateTime.Now);
        }

        public MsgInfo(int msgId, int groupId, int eventId)
        {
            id = msgId;
            senderEmail = "event";
            evId = eventId;
            evTime = SessionData.getEventTime(groupId, eventId);
            resName = SessionData.getRestaurantName(SessionData.getEventRestaurant(groupId, eventId));
            time = SessionData.getEpochFromDateOrTime(DateTime.Now);
        }

        public MsgInfo(int msgId, string msgSender, string msgContent, long msgTime)
        {
            id = msgId;
            senderEmail = msgSender;
            content = msgContent;
            evId = -1;
            evTime = 0;
            time = msgTime;
        }

        public MsgInfo(int msgId, int groupId, int eventId, long msgTime)
        {
            id = msgId;
            senderEmail = "event";
            evId = eventId;
            evTime = SessionData.getEventTime(groupId, eventId);
            resName = SessionData.getRestaurantName(SessionData.getEventRestaurant(groupId, eventId));
            time = msgTime;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            MsgInfo other = obj as MsgInfo;

            return id == other.id;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }
    }
}
