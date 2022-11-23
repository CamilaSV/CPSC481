using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class Logic_AddRemFriend
    {
        // add target to user's friends list, and add user to target user's friend requests
        public static string addFriend(string emailUser, string emailTarget)
        {
            string result;

            if (emailTarget.Equals(UserProfile.getCurrentEmail()))
            {
                result = "You cannot add yourself as a friend.";
            }
            else if (SharedFunctions.isLineInFile(PathFinder.getAccFriends(emailUser), emailTarget))
            {
                result = "The user is already your friend.";
            }
            else if (!Directory.Exists(PathFinder.getAccDir(emailTarget)))
            {
                result = "The user does not exist.";
            }
            else
            {
                SharedFunctions.appendLineToFile(PathFinder.getAccFriends(emailUser), emailTarget);

                // if the target exists in user's friend request, remove that request. Otherwise, send friend request to the target.
                if (SharedFunctions.isLineInFile(PathFinder.getAccFriendReq(emailUser), emailTarget))
                {
                    SharedFunctions.removeLineFromFile(PathFinder.getAccFriendReq(emailUser), emailTarget);
                }
                else
                {
                    SharedFunctions.appendLineToFile(PathFinder.getAccFriendReq(emailTarget), emailUser);
                }

                result = "true";
            }

            return result;
        }

        // delete target from user's friends list
        public static void deleteFriend(string emailUser, string emailTarget)
        {
            SharedFunctions.removeLineFromFile(PathFinder.getAccFriends(emailUser), emailTarget);
        }

        // add target to user's friends list, and delete target from user's friend requests
        public static void acceptFriendReq(string emailUser, string emailTarget)
        {
            SharedFunctions.appendLineToFile(PathFinder.getAccFriends(emailUser), emailTarget);
            removeFriendReq(emailUser, emailTarget);
        }

        // delete target from user's friend requests
        public static void removeFriendReq(string emailUser, string emailTarget)
        {
            SharedFunctions.removeLineFromFile(PathFinder.getAccFriendReq(emailUser), emailTarget);
        }

        public static string getAllFriends(string emailUser)
        {
            return File.ReadAllText(PathFinder.getAccFriends(emailUser));
        }
    }
}
