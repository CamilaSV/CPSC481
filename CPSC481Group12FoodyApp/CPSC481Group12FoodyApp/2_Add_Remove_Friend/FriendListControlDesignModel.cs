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
    public class FriendListControlDesignModel : propertyChange_Friend, Interface_FriendListComponent
    {
        public static FriendListControlDesignModel Instance { get; } = new FriendListControlDesignModel();

        private ObservableCollection<propertyChange_Friend> friendListCollection;
        public ObservableCollection<propertyChange_Friend> FriendListCollection
        {
            get { return friendListCollection; }
            set
            {
                if (value != friendListCollection)
                {
                    friendListCollection = value;
                    OnPropertyChanged(nameof(FriendListCollection));
                }
            }
        }

        public FriendListControlDesignModel()
        {
            ComponentFunctions.addComponentToList(this);
        }

        public void refreshComponent()
        {
            FriendListCollection = Logic_Friend.displayUsersFriendList();
        }
    }
}
