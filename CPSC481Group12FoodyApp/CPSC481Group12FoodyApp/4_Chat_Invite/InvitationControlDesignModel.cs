using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC481Group12FoodyApp
{
    public class InvitationControlDesignModel : propertyChange_ChatInvite
    {
        public static InvitationControlDesignModel Instance { get; } = new InvitationControlDesignModel();

        private ObservableCollection<propertyChange_ChatInvite> chats;
        public ObservableCollection<propertyChange_ChatInvite> Chats
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

        public InvitationControlDesignModel()
        {
            this.Chats = new ObservableCollection<propertyChange_ChatInvite>
            {
                new propertyChange_ChatInvite
                {
                     GroupName = "Foodies",
                     UserName = "Jessica",
                },

                new propertyChange_ChatInvite
                {
                    GroupName = "Trio",
                     UserName = "Bob",
                },
            };
        }
    }
}
