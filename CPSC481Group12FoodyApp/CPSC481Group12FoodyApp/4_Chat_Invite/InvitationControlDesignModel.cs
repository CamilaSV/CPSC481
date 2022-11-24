using CPSC481Group12FoodyApp.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC481Group12FoodyApp
{
    public class InvitationControlDesignModel : propertyChange_ChatInvite, Interface_ChatInvComponent
    {
        public static InvitationControlDesignModel Instance { get; } = new InvitationControlDesignModel();

        private ObservableCollection<propertyChange_ChatInvite> invites;
        public ObservableCollection<propertyChange_ChatInvite> Invites
        {
            get { return invites; }
            set
            {
                if (value != invites)
                {
                    invites = value;
                    OnPropertyChanged(nameof(Invites));
                }
            }
        }

        public InvitationControlDesignModel()
        {
            ComponentFunctions.addComponentToList(this);
            Invites = Logic_ChatInvites.displayUsersGroupInviteList();
        }

        public void refreshComponent()
        {
            Invites = Logic_ChatInvites.displayUsersGroupInviteList();
        }
    }
}
