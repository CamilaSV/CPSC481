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
        public static ObservableCollection<propertyChange> displayUsersFriendRequest(ObservableCollection<propertyChange> friendRequestCollection)
        {
            if (String.IsNullOrEmpty(UserProfile.currentUserEmail))
            {
                propertyChange requestItem = new propertyChange();
                friendRequestCollection.Add(requestItem);
            }
            else
            {
                List<string> lines = new List<string>();
                // ReadAllLines closes file after reading.
                lines = File.ReadAllLines(PathFinder.getAccFriendReq(UserProfile.currentUserEmail)).ToList();

                if (String.IsNullOrEmpty(lines[0]))
                {
                    propertyChange requestItem = new propertyChange();
                    friendRequestCollection.Add(requestItem);
                }
                else
                {
                    foreach (string line in lines)
                    {
                        string[] currentUserName = line.Split('@');
                        string nameAbbreviation = currentUserName[0].Substring(0, 1);
                        propertyChange requestItem = new propertyChange
                        {
                            TargetUserName = currentUserName[0],
                            Abbreviation = nameAbbreviation
                        };
                        friendRequestCollection.Add(requestItem);
                    }
                }
            }

            return friendRequestCollection;
        }
    }
}
