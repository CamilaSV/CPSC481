using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC481Group12FoodyApp
{
    public class ChatMsgDesignModel : propertyChange_ChatScreen
    {
        public static ChatMsgDesignModel Instance { get; } = new ChatMsgDesignModel();
        public ChatMsgDesignModel()
        {
        }
    }
}
