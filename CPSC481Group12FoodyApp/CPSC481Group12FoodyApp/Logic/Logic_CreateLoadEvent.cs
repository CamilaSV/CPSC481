using System;
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

            StreamWriter fileWriter = File.CreateText(PathFinder.getChatFutSchEvName(chatId, eventId));
            fileWriter.WriteLine(restaurantName);
            fileWriter.Close();

            fileWriter = File.CreateText(PathFinder.getChatFutSchEvDate(chatId, eventId));
            fileWriter.WriteLine(date);
            fileWriter.Close();

            string[] members = File.ReadAllLines(PathFinder.getChatMembers(chatId));

            foreach (var eachMember in members)
            {
                fileWriter = File.CreateText(PathFinder.getAccFutSchGroupEvName(eachMember, chatId, eventId));
                fileWriter.WriteLine(restaurantName);
                fileWriter.Close();

                fileWriter = File.CreateText(PathFinder.getAccFutSchGroupEvDate(eachMember, chatId, eventId));
                fileWriter.WriteLine(date);
                fileWriter.Close();

            }
        }
    }
}
