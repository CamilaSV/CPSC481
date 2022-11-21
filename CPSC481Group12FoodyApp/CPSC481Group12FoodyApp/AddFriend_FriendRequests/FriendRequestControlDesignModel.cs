using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC481Group12FoodyApp
{
    public class FriendRequestControlDesignModel : propertyChange
    {
        public static FriendRequestControlDesignModel Instance { get; } = new FriendRequestControlDesignModel();

        private ObservableCollection<propertyChange> chats;
        public ObservableCollection<propertyChange> Chats
        {
            get { return chats; }
            set
            {
                if (value != chats)
                {
                    chats = value;
                    OnPropertyChanged(nameof(Chats));
                }
            }
        }

        public FriendRequestControlDesignModel()
        {
            Chats = new ObservableCollection<propertyChange>
            {
                new propertyChange
                {
                    Abbreviation = "G",
                    TargetUserName = "Girls",
                },

                new propertyChange
                {
                    Abbreviation = "B",
                    TargetUserName = "BBBBBBB",
                },
                new propertyChange
                {
                    Abbreviation = "S",
                    TargetUserName = "Sad Groups",
                },
                new propertyChange
                {
                    Abbreviation = "Z",
                    TargetUserName = "Za",
                },
            };
        }
    }
}
