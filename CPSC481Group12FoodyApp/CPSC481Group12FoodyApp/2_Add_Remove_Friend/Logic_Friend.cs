using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class Logic_Friend
    {
        // add target to user's friends list, and add user to target user's friend requests
        public static void addFriend(UserControl_AddFriends addPage)
        {
            string emailTarget = addPage.AddFriendTextBox.Text;
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
                SessionData.saveUserInfoToDB();
                PageNavigator.gotoProfile();
                ComponentFunctions.refreshAll();
            }
        }

        public static void acceptFriendReq(string emailTarget)
        {
            SessionData.addUserFriend(SessionData.getCurrentUser(), emailTarget);
            SessionData.saveUserInfoToDB();
            ComponentFunctions.refreshAll();
        }

        public static void denyFriendReq(string emailTarget)
        {
            SessionData.removeUserFriendReq(SessionData.getCurrentUser(), emailTarget);
            SessionData.saveUserInfoToDB();
            ComponentFunctions.refreshAll();
        }

        public static void deleteFriend(string emailTarget)
        {
            SessionData.removeUserFriend(SessionData.getCurrentUser(), emailTarget);
            SessionData.saveUserInfoToDB();
            ComponentFunctions.refreshAll();
        }
    }
}
