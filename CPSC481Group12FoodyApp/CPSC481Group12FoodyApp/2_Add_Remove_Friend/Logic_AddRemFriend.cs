using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using CPSC481Group12FoodyApp.Logic;

namespace CPSC481Group12FoodyApp
{
    public static class Logic_AddRemFriend
    {
        // add target to user's friends list, and add user to target user's friend requests
        public static void addFriend(UserControl_AddFriends addPage, string emailTarget)
        {
            if (emailTarget.Equals(SessionData.getCurrentUser()))
            {
                addPage.ErrorTextBlock.Text = "You cannot add yourself as a friend.";
            }
            else if (SessionData.getTargetIsUserFriend(SessionData.getCurrentUser(), emailTarget))
            {
                addPage.ErrorTextBlock.Text = "The user is already your friend.";
            }
            else if (!SessionData.getUserExist(emailTarget))
            {
                addPage.ErrorTextBlock.Text = "The user does not exist.";
            }
            else
            {
                SessionData.addUserFriendReqToTarget(SessionData.getCurrentUser(), emailTarget);
            }
        }

        public static void acceptFriendReq(string emailTarget)
        {
            SessionData.addUserFriend(SessionData.getCurrentUser(), emailTarget);
        }

        public static void denyFriendReq(string emailTarget)
        {
            SessionData.removeUserFriendReq(SessionData.getCurrentUser(), emailTarget);
        }

        public static void deleteFriend(string emailTarget)
        {
            SessionData.removeUserFriend(SessionData.getCurrentUser(), emailTarget);
        }
    }
}
