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
        public static void addFriend(string emailUser, string emailTarget)
        {
            SharedFunctions.appendLineToFile(PathFinder.getAccFriends(emailUser), emailTarget);
            SharedFunctions.appendLineToFile(PathFinder.getAccFriendReq(emailTarget), emailUser);
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

    }
}
