using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text.Json;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class SessionData_Event
    {
        private static Dictionary<EventId, EventInfo> allEvents;

        public static void initializeStartup()
        {
            allEvents = DBFunctions.getAllEventInfo();
        }

        // getters
        public static string getEventTime(string groupId, string eventId)
        {
            return allEvents[new EventId { groupId = groupId, id = eventId }].time;
        }

        public static string getEventRestaurant(string groupId, string eventId)
        {
            return allEvents[new EventId { groupId = groupId, id = eventId }].restaurantId;
        }

        public static string getEventComment(string groupId, string eventId)
        {
            return allEvents[new EventId { groupId = groupId, id = eventId }].comment;
        }

        // setters


        // different types of arguments
        public static string getEventTime(string groupId, int eventId)
        {
            return getEventTime(groupId.ToString(), eventId.ToString());
        }

        public static string getEventTime(int groupId, string eventId)
        {
            return getEventTime(groupId.ToString(), eventId.ToString());
        }

        public static string getEventTime(int groupId, int eventId)
        {
            return getEventTime(groupId.ToString(), eventId.ToString());
        }

        public static string getEventRestaurant(string groupId, int eventId)
        {
            return getEventRestaurant(groupId.ToString(), eventId.ToString());
        }

        public static string getEventRestaurant(int groupId, string eventId)
        {
            return getEventRestaurant(groupId.ToString(), eventId.ToString());
        }

        public static string getEventRestaurant(int groupId, int eventId)
        {
            return getEventRestaurant(groupId.ToString(), eventId.ToString());
        }

        public static string getEventComment(string groupId, int eventId)
        {
            return getEventComment(groupId.ToString(), eventId.ToString());
        }

        public static string getEventComment(int groupId, string eventId)
        {
            return getEventComment(groupId.ToString(), eventId.ToString());
        }

        public static string getEventComment(int groupId, int eventId)
        {
            return getEventComment(groupId.ToString(), eventId.ToString());
        }

    }
}
