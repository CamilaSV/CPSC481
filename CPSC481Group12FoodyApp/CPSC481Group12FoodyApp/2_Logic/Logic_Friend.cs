using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class Logic_Friend
    {
        // add target to user's friends list, and add user to target user's friend requests
        public static void addFriend(UserControl_AddFriends addPage)
        {
            SessionData.stopTimer();
            SessionData.updateUserInfoFromDB();
            string emailTarget = addPage.AddFriendTextBox.Text;
            if (emailTarget.Equals(SessionData.getCurrentUser()))
            {
                addPage.ErrorTextBlock.Foreground = Brushes.Indigo;
                addPage.ErrorTextBlock.Text = "You cannot add yourself as a friend.";
            }
            else if (SessionData.getTargetIsUserFriend(SessionData.getCurrentUser(), emailTarget))
            {
                addPage.ErrorTextBlock.Foreground = Brushes.Indigo;
                addPage.ErrorTextBlock.Text = "The user is already your friend.";
            }
            else if (!SessionData.getUserExist(emailTarget))
            {
                addPage.ErrorTextBlock.Foreground = Brushes.Indigo;
                addPage.ErrorTextBlock.Text = "The user does not exist.";
            }
            else
            {
                SessionData.addUserFriendReqToTarget(SessionData.getCurrentUser(), emailTarget);
                addPage.ErrorTextBlock.Foreground = Brushes.Blue;
                addPage.ErrorTextBlock.Text = "Friend request sent!";
            }
            SessionData.saveUserInfoToDB();
            SessionData.startTimer();
        }

        public static void acceptFriendReq(string emailTarget)
        {
            SessionData.stopTimer();
            SessionData.updateUserInfoFromDB();
            SessionData.addUserFriend(SessionData.getCurrentUser(), emailTarget);
            SessionData.saveUserInfoToDB();
            ComponentFunctions.refreshAll();
            SessionData.startTimer();
        }

        public static void denyFriendReq(string emailTarget)
        {
            SessionData.stopTimer();
            SessionData.updateUserInfoFromDB();
            SessionData.removeUserFriendReq(SessionData.getCurrentUser(), emailTarget);
            SessionData.saveUserInfoToDB();
            ComponentFunctions.refreshAll();
            SessionData.startTimer();
        }

        public static void deleteFriend(string emailTarget)
        {
            SessionData.stopTimer();
            SessionData.updateUserInfoFromDB();
            SessionData.removeUserFriend(SessionData.getCurrentUser(), emailTarget);
            SessionData.saveUserInfoToDB();
            ComponentFunctions.refreshAll();
            SessionData.startTimer();
        }
    }
}
