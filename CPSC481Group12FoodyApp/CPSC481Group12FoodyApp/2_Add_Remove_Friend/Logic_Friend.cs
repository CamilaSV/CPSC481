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
            foreach (string line in SessionData.getCurrentUserFriendReq())
            {
                name = DBSetter.getFirstLineFromFile(PathFinder.getAccName(line));
                propertyChange_Friend requestItem = new propertyChange_Friend
                {
                    TargetEmail = line,
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
            foreach (string line in SessionData.getCurrentUserFriends())
            {
                name = DBSetter.getFirstLineFromFile(PathFinder.getAccName(line));
                propertyChange_Friend listItem = new propertyChange_Friend
                {
                    TargetEmail = line,
                    TargetUserName = name,
                    Abbreviation = name.Substring(0, 1),
                };
                friendListCollection.Add(listItem);
            }

            return friendListCollection;
        }
    }
}
