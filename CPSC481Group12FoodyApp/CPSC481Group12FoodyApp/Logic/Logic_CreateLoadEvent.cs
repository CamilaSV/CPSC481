﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;

namespace CPSC481Group12FoodyApp
{
    public static class Logic_CreateLoadEvent
    {
        public static void createEvent(string chatId, string restaurantName, DateTime date)
        {
            int eventId;

            for (eventId = 0; 
                File.Exists(PathFinder.getChatFutSchEvName(chatId, eventId)) 
                || File.Exists(PathFinder.getChatCompSchEvName(chatId, eventId)); 
                eventId++) ;

            Directory.CreateDirectory(PathFinder.getChatFutSchEvDir(chatId, eventId));

            SharedFunctions.appendLineToFile(PathFinder.getChatFutSchEvName(chatId, eventId), restaurantName);
            SharedFunctions.appendLineToFile(PathFinder.getChatFutSchEvDate(chatId, eventId), date);

            string[] members = File.ReadAllLines(PathFinder.getChatMembers(chatId));

            foreach (var eachMember in members)
            {
                SharedFunctions.appendLineToFile(PathFinder.getAccFutSchGroupEvName(eachMember, chatId, eventId), restaurantName);
                SharedFunctions.appendLineToFile(PathFinder.getAccFutSchGroupEvDate(eachMember, chatId, eventId), date);
            }
        }
    }
}
