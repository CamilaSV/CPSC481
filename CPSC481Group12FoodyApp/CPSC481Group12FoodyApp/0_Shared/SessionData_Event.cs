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

        public static void createEvent(string groupId, string eventId, string time, string restaurantId, string comment)
        {
            EventId ev = new EventId { groupId = groupId, id = eventId };
            EventInfo info = new EventInfo 
            { 
                time = time,
                restaurantId = restaurantId,
                comment = comment,
            };

            allEvents[ev] = info;
        }

        public static void deleteEvent(EventId eventId)
        {
            if (allEvents.ContainsKey(eventId))
            {
                allEvents.Remove(eventId);
            }
        }

        // getters
        public static string getEventTime(EventId eventId)
        {
            return allEvents[eventId].time;
        }

        public static string getEventRestaurant(EventId eventId)
        {
            return allEvents[eventId].restaurantId;
        }

        public static string getEventComment(EventId eventId)
        {
            return allEvents[eventId].comment;
        }

        // different types of arguments
        public static void createEvent(string groupId, string eventId, string time, int restaurantId, string comment)
        {
            createEvent(groupId.ToString(), eventId.ToString(), time.ToString(), restaurantId.ToString(), comment);
        }

        public static void createEvent(string groupId, string eventId, long time, string restaurantId, string comment)
        {
            createEvent(groupId.ToString(), eventId.ToString(), time.ToString(), restaurantId.ToString(), comment);
        }

        public static void createEvent(string groupId, string eventId, long time, int restaurantId, string comment)
        {
            createEvent(groupId.ToString(), eventId.ToString(), time.ToString(), restaurantId.ToString(), comment);
        }

        public static void createEvent(string groupId, int eventId, string time, string restaurantId, string comment)
        {
            createEvent(groupId.ToString(), eventId.ToString(), time.ToString(), restaurantId.ToString(), comment);
        }

        public static void createEvent(string groupId, int eventId, string time, int restaurantId, string comment)
        {
            createEvent(groupId.ToString(), eventId.ToString(), time.ToString(), restaurantId.ToString(), comment);
        }
        public static void createEvent(string groupId, int eventId, long time, string restaurantId, string comment)
        {
            createEvent(groupId.ToString(), eventId.ToString(), time.ToString(), restaurantId.ToString(), comment);
        }

        public static void createEvent(string groupId, int eventId, long time, int restaurantId, string comment)
        {
            createEvent(groupId.ToString(), eventId.ToString(), time.ToString(), restaurantId.ToString(), comment);
        }

        public static void createEvent(int groupId, string eventId, string time, string restaurantId, string comment)
        {
            createEvent(groupId.ToString(), eventId.ToString(), time.ToString(), restaurantId.ToString(), comment);
        }

        public static void createEvent(int groupId, string eventId, string time, int restaurantId, string comment)
        {
            createEvent(groupId.ToString(), eventId.ToString(), time.ToString(), restaurantId.ToString(), comment);
        }

        public static void createEvent(int groupId, string eventId, long time, string restaurantId, string comment)
        {
            createEvent(groupId.ToString(), eventId.ToString(), time.ToString(), restaurantId.ToString(), comment);
        }

        public static void createEvent(int groupId, string eventId, int time, int restaurantId, string comment)
        {
            createEvent(groupId.ToString(), eventId.ToString(), time.ToString(), restaurantId.ToString(), comment);
        }

        public static void createEvent(int groupId, int eventId, string time, string restaurantId, string comment)
        {
            createEvent(groupId.ToString(), eventId.ToString(), time.ToString(), restaurantId.ToString(), comment);
        }

        public static void createEvent(int groupId, int eventId, string time, int restaurantId, string comment)
        {
            createEvent(groupId.ToString(), eventId.ToString(), time.ToString(), restaurantId.ToString(), comment);
        }

        public static void createEvent(int groupId, int eventId, long time, string restaurantId, string comment)
        {
            createEvent(groupId.ToString(), eventId.ToString(), time.ToString(), restaurantId.ToString(), comment);
        }

        public static void createEvent(int groupId, int eventId, long time, int restaurantId, string comment)
        {
            createEvent(groupId.ToString(), eventId.ToString(), time.ToString(), restaurantId.ToString(), comment);
        }
    }
}
