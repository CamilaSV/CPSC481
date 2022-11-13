using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC481Group12FoodyApp
{
    public class InvitationControlDesignModel : propertyChange
    {
        public static InvitationControlDesignModel Instance { get; } = new InvitationControlDesignModel();

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

        public InvitationControlDesignModel()
        {
            this.Chats = new ObservableCollection<propertyChange>
            {
                new propertyChange
                {
                     GroupName = "Foodies",
                     UserName = "  Jessica",
                },

                new propertyChange
                {
                    GroupName = "Trio",
                     UserName = "  Bob",
                },
            };
        }
    }
}
