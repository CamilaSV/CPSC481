using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class Logic_Profle
    {
        public static ObservableCollection<propertyChange> displayUsersFriendRequest()
        {
            ObservableCollection<propertyChange> friendRequestCollection = new ObservableCollection<propertyChange>();

            if (UserProfile.getCurrentFriendReq().Any())
            {
                string name;
                foreach (string line in UserProfile.getCurrentFriendReq())
                {
                    name = SharedFunctions.getFirstLineFromFile(PathFinder.getAccName(line));
                    propertyChange requestItem = new propertyChange
                    {
                        TargetEmail = line,
                        TargetUserName = name,
                        Abbreviation = name.Substring(0, 1),
                    };
                    friendRequestCollection.Add(requestItem);
                }
            }

            return friendRequestCollection;
        }
    }
}
