using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC481Group12FoodyApp.ChatScreens
{
    public class ChatListControlDesignModel : propertyChange
    {
        public static ChatListControlDesignModel Instance { get; } = new ChatListControlDesignModel();

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

        public ChatListControlDesignModel()
        {
            Chats = new ObservableCollection<propertyChange>
            {
                new propertyChange
                {
                    Abbreviation = "G",
                    GroupName = "Girls",
                    LastActive = "Last Active: 1h"
                },

                new propertyChange
                {
                    Abbreviation = "B",
                    GroupName = "BBBBBBB",
                    LastActive = "Last Active: 2h"
                },
                new propertyChange
                {
                    Abbreviation = "S",
                    GroupName = "Sad Groups",
                    LastActive = "Last Active: 3h"
                },
                new propertyChange
                {
                    Abbreviation = "Z",
                    GroupName = "Za",
                    LastActive = "Last Active: 4h"
                },
            };
        }
    }
}
