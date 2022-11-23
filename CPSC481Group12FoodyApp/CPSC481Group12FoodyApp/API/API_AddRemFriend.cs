using System;
using System.IO;
using System.Net.Mail;

using CPSC481Group12FoodyApp.Logic;

namespace CPSC481Group12FoodyApp
{
    public static class API_AddRemFriend
    {
        public static void addFriend(UserControl_AddFriends addPage, UserControl_Profile profilePage, string emailTarget)
        {
            string result = Logic_AddRemFriend.addFriend(UserProfile.getCurrentEmail(), emailTarget);

            if (result.Equals("true"))
            {
                UserProfile.addFriendToList(emailTarget);
                profilePage.FriendListTextBlock.Text = Logic_AddRemFriend.getAllFriends(UserProfile.getCurrentEmail());
                addPage.navigate_helper.gotoProfile();
            }
            else
            {
                addPage.ErrorTextBlock.Text = result;
            }
        }

        public static void deleteFriend(UserControl_Profile profilePage, string emailTarget)
        {
            Logic_AddRemFriend.deleteFriend(UserProfile.getCurrentEmail(), emailTarget);
            UserProfile.remFriendFromList(emailTarget);
            profilePage.FriendListTextBlock.Text = Logic_AddRemFriend.getAllFriends(UserProfile.getCurrentEmail());
        }

        public static void acceptFriendReq(string emailTarget)
        {
            Logic_AddRemFriend.acceptFriendReq(UserProfile.getCurrentEmail(), emailTarget);
            UserProfile.addFriendToList(emailTarget);
            UserProfile.remFriendReqFromList(emailTarget);
        }

        public static void denyFriendReq(string emailTarget)
        {
            Logic_AddRemFriend.removeFriendReq(UserProfile.getCurrentEmail(), emailTarget);
            UserProfile.remFriendFromList(emailTarget);
        }
    }
}
 