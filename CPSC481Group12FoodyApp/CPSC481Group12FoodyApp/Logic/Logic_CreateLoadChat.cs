using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;

namespace CPSC481Group12FoodyApp
{
    public static class Logic_CreateLoadChat
    {
        public static string createChat(string chatName, string emailCreator, string[] emailsToInvite)
        {
            string result;

            if (String.IsNullOrWhiteSpace(chatName))
            {
                result = "Chat name must not be empty.";
            }
            else
            {
                chatName = chatName.TrimEnd(); // remove whitespaces in the end

                int chatId;

                for (chatId = 0; Directory.Exists(PathFinder.getChatDir(chatId)); chatId++) ;
                Directory.CreateDirectory(PathFinder.getChatDir(chatId));

                StreamWriter fileWriter = File.CreateText(PathFinder.getChatName(chatId));
                fileWriter.WriteLine(chatName);
                fileWriter.Close();

                fileWriter = File.CreateText(PathFinder.getChatAdmin(chatId));
                fileWriter.WriteLine(emailCreator);
                fileWriter.Close();

                fileWriter = File.CreateText(PathFinder.getChatMembers(chatId));
                fileWriter.WriteLine(emailCreator);
                fileWriter.Close();

                File.Create(PathFinder.getChatLog(chatId)).Close();
                File.Create(PathFinder.getChatRestaurants(chatId)).Close();
                File.Create(PathFinder.getChatFutSch(chatId)).Close();
                File.Create(PathFinder.getChatCompSch(chatId)).Close();

                foreach (var eachEmail in emailsToInvite)
                {
                    fileWriter = File.AppendText(PathFinder.getAccInv(eachEmail));
                    fileWriter.WriteLine(chatId);
                    fileWriter.Close();
                }

                result = "true";
            }

            return result;
        }

        public static List<Tuple<string, string>> loadChatList(string chatName, string emailUser)
        {
            List<Tuple<string, string>> result = new List<Tuple<string, string>>();

            StreamReader fileReader = File.OpenText(PathFinder.getAccChats(emailUser));

            while (!fileReader.EndOfStream)
            {
                result.Add(previewOneChat(fileReader.ReadLine()));
            }

            fileReader.Close();

            return result;
        }

        public static Tuple<string, string> previewOneChat(string chatId)
        {
            StreamReader fileReader = File.OpenText(PathFinder.getChatName(chatId));
            string chatName = fileReader.ReadLine();
            fileReader.Close();

            string lastChat = File.ReadLines(PathFinder.getChatLog(chatId)).Last();

            return new Tuple<string, string>(chatName, lastChat); // get chat name and the very last chat
        }

        public static Tuple<string, string, string[]> enterOneChat(string emailUser, string chatId)
        {
            StreamReader fileReader = File.OpenText(PathFinder.getChatName(chatId));
            string chatName = fileReader.ReadLine();
            string[] chatLog = File.ReadAllLines(PathFinder.getChatLog(chatId));

            return new Tuple<string, string, string[]>(emailUser, chatName, chatLog);
        }
    }
}
