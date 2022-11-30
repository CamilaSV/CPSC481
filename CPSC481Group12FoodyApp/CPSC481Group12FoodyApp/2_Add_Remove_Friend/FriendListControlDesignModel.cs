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

        public ObservableCollection<propertyChange_Friend> FriendListCollection
        {
            get;
            set;
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
