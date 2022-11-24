using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class Logic_FriendRequest
    {
        public static ObservableCollection<propertyChange_Friend> displayUsersFriendRequest()
        {
            ObservableCollection<propertyChange_Friend> friendRequestCollection = new ObservableCollection<propertyChange_Friend>();

            string name;
            foreach (string line in SessionData.getCurrentFriendReq())
            {
                name = SharedFunctions.getFirstLineFromFile(PathFinder.getAccName(line));
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
    }
}
