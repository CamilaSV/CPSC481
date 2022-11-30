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
    public class FriendRequestControlDesignModel
    {
        public ObservableCollection<propertyChange_Friend> FriendRequestCollection
        {
            get;
            set;
        }
    }
}
