using CPSC481Group12FoodyApp.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC481Group12FoodyApp
{
    public class ChatMsgControlDesignModel : propertyChange_ChatScreen, Interface_ChatMsgComponent
    {
        public static ChatMsgControlDesignModel Instance { get; } = new ChatMsgControlDesignModel();

        private ObservableCollection<propertyChange_ChatScreen> messages;
        public ObservableCollection<propertyChange_ChatScreen> Messages
        {
            get { return messages; }
            set
            {
                if (value != messages)
                {
                    messages = value;
                    OnPropertyChanged(nameof(Messages));
                }
            }
        }

        public ChatMsgControlDesignModel()
        {
            ComponentFunctions.addComponentToList(this);
        }

        public void refreshComponent()
        {
        }
    }
}
