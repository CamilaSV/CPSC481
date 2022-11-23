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

            if (SessionData.getCurrentFriendReq().Any())
            {
                string name;
                foreach (string line in SessionData.getCurrentFriendReq())
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

        public static ObservableCollection<propertyChange> displayUsersChatList()
        {
            ObservableCollection<propertyChange> chatListCollection = new ObservableCollection<propertyChange>();

            if (SessionData.getCurrentChatList().Any())
            {
                foreach (Tuple<string, string, TupleEachMsg> lastmsg in SessionData.getCurrentChatList())
                {
                    propertyChange requestItem = new propertyChange
                    {
                        ChatId = lastmsg.Item1,
                        ChatName = lastmsg.Item2,
                        ChatLastSender = lastmsg.Item3.getEmail(),
                        ChatLastMsg = lastmsg.Item3.getMessage(),
                        ChatLastTime = lastmsg.Item3.getTime(),
                    };
                    chatListCollection.Add(requestItem);
                }
            }

            return chatListCollection;
        }
    }
}
