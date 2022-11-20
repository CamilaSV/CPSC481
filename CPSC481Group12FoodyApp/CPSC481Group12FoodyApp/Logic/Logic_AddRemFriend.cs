using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;

namespace CPSC481Group12FoodyApp
{
    public static class Logic_AddRemFriend
    {
        // add target to user's friends list, and add user to target user's friend requests
        public static void addFriend(string emailUser, string emailFriend)
        {
            StreamWriter fileWriter = File.AppendText(PathFinder.getAccFriends(emailUser));
            fileWriter.WriteLine(emailFriend);
            fileWriter.Close();

            fileWriter = File.AppendText(PathFinder.getAccFriendReq(emailFriend));
            fileWriter.WriteLine(emailUser);
            fileWriter.Close();
        }

        // delete target from user's friends list
        public static void deleteFriend(string emailUser, string emailFriend)
        {
            string[] allFriends = File.ReadAllLines(PathFinder.getAccFriends(emailUser));

            StreamWriter fileWriter = File.CreateText(PathFinder.getAccFriends(emailUser));
            foreach (string line in allFriends)
            {
                if (!line.Equals(emailFriend))
                {
                    fileWriter.WriteLine(line);
                }
            }

            fileWriter.Close();
        }

        // add target to user's friends list, and delete target from user's friend requests
        public static void acceptFriendReq(string emailUser, string emailFriend)
        {
            StreamWriter fileWriter = File.AppendText(PathFinder.getAccFriends(emailUser));
            fileWriter.WriteLine(emailFriend);
            fileWriter.Close();

            removeFriendReq(emailUser, emailFriend);
        }

        // delete target from user's friend requests
        public static void removeFriendReq(string emailUser, string emailFriend)
        {
            string[] allFriendReqs = File.ReadAllLines(PathFinder.getAccFriendReq(emailUser));

            StreamWriter fileWriter = File.CreateText(PathFinder.getAccFriendReq(emailUser));
            foreach (string line in allFriendReqs)
            {
                if (!line.Equals(emailFriend))
                {
                    fileWriter.WriteLine(line);
                }
            }

            fileWriter.Close();
        }
    }
}
