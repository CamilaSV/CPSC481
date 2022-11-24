using CPSC481Group12FoodyApp.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC481Group12FoodyApp
{
    public class ChatListControlDesignModel : propertyChange_Chat, Interface_ChatListComponent
    {
        public static ChatListControlDesignModel Instance { get; } = new ChatListControlDesignModel();

        private ObservableCollection<propertyChange_Chat> chats;
        public ObservableCollection<propertyChange_Chat> Chats
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
            ComponentFunctions.addComponentToList(this);
            Chats = Logic_CreateLoadChat.displayUsersChatList();
        }

        public void refreshComponent()
        {
            Chats = Logic_CreateLoadChat.displayUsersChatList();
        }
    }
}
