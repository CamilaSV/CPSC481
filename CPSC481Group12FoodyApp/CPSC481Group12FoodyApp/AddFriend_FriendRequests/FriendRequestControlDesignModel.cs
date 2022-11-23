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
    public class FriendRequestControlDesignModel : propertyChange, Interface_FriendReqComponent
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
            ComponentFunctions.addComponentToList(this);
            FriendRequestCollection = Logic_Profle.displayUsersFriendRequest();
        }

        public void refreshComponent()
        {
            FriendRequestCollection = Logic_Profle.displayUsersFriendRequest();
        }
    }
}
