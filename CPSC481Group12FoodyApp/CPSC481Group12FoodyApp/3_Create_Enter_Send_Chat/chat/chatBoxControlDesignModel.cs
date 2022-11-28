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

            /*SendCommand = new RelayCommand(o =>
            {
                Messages.Add(new ChatBoxDesignModel
                {
                    IsUser_chatMsg = IsUser_chatMsg,
                });
                IsUser_chatMsg = "";
            });*/
            Messages.Add(new ChatBoxDesignModel
            {
                IsUser_chatMsg = "TESTING TESTING TESTING "
            });
        }


        public void refreshComponent()
        {
            Messages = Logic_ChatScreen.displayChatModels();
            Messages.Add(new ChatBoxDesignModel
            {
                IsUser_chatMsg = "TESTING TESTING TESTING "
            });
        }
    }
}
