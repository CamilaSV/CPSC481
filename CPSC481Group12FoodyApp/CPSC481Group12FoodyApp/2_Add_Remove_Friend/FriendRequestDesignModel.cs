using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC481Group12FoodyApp
{
    public class FriendRequestDesignModel : propertyChange
    {
        public static FriendRequestDesignModel Instance { get; } = new FriendRequestDesignModel();
        public FriendRequestDesignModel()
        {
        }
    }
}
