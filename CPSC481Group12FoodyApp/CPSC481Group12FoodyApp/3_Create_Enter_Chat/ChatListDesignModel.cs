using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC481Group12FoodyApp
{
    public class ChatListDesignModel : propertyChange_Chat
    {
        public static ChatListDesignModel Instance { get; } = new ChatListDesignModel();
        public ChatListDesignModel()
        {
        }
    }
}
