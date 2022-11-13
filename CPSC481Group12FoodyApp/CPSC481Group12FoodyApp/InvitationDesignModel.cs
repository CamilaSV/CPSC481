using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC481Group12FoodyApp
{
    public class InvitationDesignModel : propertyChange
    {
        public static InvitationDesignModel Instance { get; } = new InvitationDesignModel();
        public InvitationDesignModel()
        {
            GroupName = "Foodies";
            UserName = "Jessica";
        }
    }
}
