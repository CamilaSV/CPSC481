using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC481Group12FoodyApp
{
    public class FriendListDesignModel : propertyChange_Friend
    {
        public static FriendListDesignModel Instance { get; } = new FriendListDesignModel();
        public FriendListDesignModel()
        {
        }
    }
}
