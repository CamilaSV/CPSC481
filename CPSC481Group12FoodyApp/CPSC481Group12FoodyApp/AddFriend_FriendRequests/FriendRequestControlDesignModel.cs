using CPSC481Group12FoodyApp.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC481Group12FoodyApp
{
    public class FriendRequestControlDesignModel : propertyChange
    {
        public static FriendRequestControlDesignModel Instance { get; } = new FriendRequestControlDesignModel();

        private ObservableCollection<propertyChange> friendRequestCollection;
        public ObservableCollection<propertyChange> FriendRequestCollection
        {
            get { return friendRequestCollection; }
            set
            {
                if (value != friendRequestCollection)
                {
                    friendRequestCollection = value;
                    OnPropertyChanged(nameof(FriendRequestCollection));
                }
            }
        }

        public FriendRequestControlDesignModel()
        {
            /*
            friendRequestCollection = new ObservableCollection<propertyChange>();
            propertyChange requestItem = new propertyChange
            {
                TargetUserName = "test",
                Abbreviation = "T",
            };
            friendRequestCollection.Add(requestItem);
            */

            
            friendRequestCollection = new ObservableCollection<propertyChange>();
            string currentUserEmail = Logic_Login.getCurrentUserEmail();

            List<string> lines = new List<string>();
            // ReadAllLines closes file after reading.
            lines = File.ReadAllLines(PathFinder.getAccFriendReq(currentUserEmail)).ToList();

            if (String.IsNullOrEmpty(currentUserEmail))
            {
                propertyChange requestItem = new propertyChange();
                friendRequestCollection.Add(requestItem);
            }
            else if (String.IsNullOrEmpty(lines[0]))
            {
                propertyChange requestItem = new propertyChange();
                friendRequestCollection.Add(requestItem);
            }
            else
            {
            //foreach (string line in lines)
            //{
                //string[] currentUserName = line.Split('@');
                //string nameAbbreviation = currentUserName[0].Substring(0, 1);
                propertyChange requestItem = new propertyChange
                {
                    //TargetUserName = currentUserName[0],
                    TargetUserName = "test",
                    Abbreviation = "T",
                };
                friendRequestCollection.Add(requestItem);
            }

        
        

            // for testing purposes.

            /*
            FriendRequestCollection = new ObservableCollection<propertyChange>
            {
                new propertyChange
                {
                    Abbreviation = "G",
                    TargetUserName = "Girls",
                },
                new propertyChange
                {
                    Abbreviation = "F",
                    TargetUserName = "Fred",
                },
            };
            */

        }
    }
}
