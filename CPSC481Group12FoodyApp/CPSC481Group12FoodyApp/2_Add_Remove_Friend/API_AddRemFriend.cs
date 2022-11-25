using System;
using System.IO;
using System.Net.Mail;
using CPSC481Group12FoodyApp.Logic;

namespace CPSC481Group12FoodyApp
{
    public static class API_AddRemFriend
    {
        public static void addFriend(UserControl_AddFriends addPage, string emailTarget)
        {
            string result = Logic_AddRemFriend.addFriend(SessionData.getCurrentEmail(), emailTarget);

            if (result.Equals("true"))
            {
                SessionData.addFriendToList(emailTarget);
                ComponentFunctions.refreshAll();
                addPage.navigate_helper.gotoProfile();
            }
            else
            {
                addPage.ErrorTextBlock.Text = result;
            }
        }

        public static void deleteFriend(string emailTarget)
        {
            Logic_AddRemFriend.deleteFriend(SessionData.getCurrentEmail(), emailTarget);
            SessionData.remFriendFromList(emailTarget);
        }

        public static void acceptFriendReq(string emailTarget)
        {
            Logic_AddRemFriend.acceptFriendReq(SessionData.getCurrentEmail(), emailTarget);
            SessionData.addFriendToList(emailTarget);
            SessionData.remFriendReqFromList(emailTarget);
        }

        public static void denyFriendReq(string emailTarget)
        {
            Logic_AddRemFriend.removeFriendReq(SessionData.getCurrentEmail(), emailTarget);
            SessionData.remFriendReqFromList(emailTarget);
        }
    }
}
 