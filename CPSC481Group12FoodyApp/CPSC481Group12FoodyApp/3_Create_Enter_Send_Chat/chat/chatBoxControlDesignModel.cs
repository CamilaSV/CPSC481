using CPSC481Group12FoodyApp.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC481Group12FoodyApp._3_Create_Enter_Send_Chat.chat
{
    public class ChatBoxControlDesignModel : propertyChange_ChatScreen, Interface_ChatMsgComponent
    {
        public RelayCommand SendCommand { get; set; }
        public ObservableCollection<ChatBoxDesignModel> Messages { get; set; }

        public ChatBoxControlDesignModel()
        {
            ComponentFunctions.addComponentToList(this);
            Messages = Logic_ChatScreen.displayChatModels();

            SendCommand = new RelayCommand(o =>
            {
                Messages.Add(new ChatBoxDesignModel
                {
                    IsUser_abbreviation = "B",
                    IsUser_chatSenderName = "Bob",
                    IsUser_chatTime = "now",
                    IsUser_chatMsg = IsUser_chatMsg,
                });
                IsUser_abbreviation = "";
                IsUser_chatSenderName = "";
                IsUser_chatTime = "";
                IsUser_chatMsg = "";

            });

            Messages.Add(new ChatBoxDesignModel
            {
                IsUser_abbreviation = "B",
                IsUser_chatSenderName = "Bob",
                IsUser_chatTime = "now",
                IsUser_chatMsg = "TESTING",
            });

        }


        public void refreshComponent()
        {
            /*
             * This breaks the code for some reason. 
             * I think it makes a new collection of the same name
             * no way for wpf to reference the current Messages object.
             */
        }
    }
}
