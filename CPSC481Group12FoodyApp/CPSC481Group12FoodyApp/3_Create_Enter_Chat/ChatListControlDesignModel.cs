using CPSC481Group12FoodyApp.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC481Group12FoodyApp
{
    public class ChatListControlDesignModel : propertyChange, Interface_ChatListComponent
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
            ComponentFunctions.addComponentToList(this);
            Chats = Logic_Profle.displayUsersChatList();
        }

        public void refreshComponent()
        {
            Chats = Logic_Profle.displayUsersChatList();
        }
    }
}
