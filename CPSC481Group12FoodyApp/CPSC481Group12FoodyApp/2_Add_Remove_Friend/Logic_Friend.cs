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
        public static ObservableCollection<propertyChange_Friend> displayUsersFriendRequest()
        {
            ObservableCollection<propertyChange_Friend> friendRequestCollection = new ObservableCollection<propertyChange_Friend>();

            string name;
            propertyChange_Friend requestItem;
            foreach (string email in SessionData.getUserFriendRequests(SessionData.getCurrentUser()))
            {
                name = SessionData.getUserDisplayName(email);
                requestItem = new propertyChange_Friend
                {
                    TargetEmail = email,
                    TargetUserName = name,
                    Abbreviation = name.Substring(0, 1),
                };
                friendRequestCollection.Add(requestItem);
            }

            return friendRequestCollection;
        }

        public static ObservableCollection<propertyChange_Friend> displayUsersFriendList()
        {
            ObservableCollection<propertyChange_Friend> friendListCollection = new ObservableCollection<propertyChange_Friend>();

            string name;
            propertyChange_Friend listItem;
            foreach (string email in SessionData.getUserFriends(SessionData.getCurrentUser()))
            {
                name = SessionData.getUserDisplayName(email);
                listItem = new propertyChange_Friend
                {
                    TargetEmail = email,
                    TargetUserName = name,
                    Abbreviation = name.Substring(0, 1),
                };
                friendListCollection.Add(listItem);
            }

            return friendListCollection;
        }
    }
}
