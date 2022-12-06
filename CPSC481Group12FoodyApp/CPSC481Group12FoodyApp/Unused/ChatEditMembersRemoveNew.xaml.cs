using CPSC481Group12FoodyApp.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CPSC481Group12FoodyApp
{
    /// <summary>
    /// Interaction logic for ChatEditMembersRemoveNew.xaml
    /// </summary>
    public partial class ChatEditMembersRemoveNew : Page, Interface_Component
    {
        private string emailRemove;

        public ChatEditMembersRemoveNew(string email)
        {
            InitializeComponent();
            emailRemove = email;
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            Logic_Group.removeGroupMember(SessionData.getCurrentGroupId(), emailRemove);
            PageNavigator.gotoGroupEditMembers();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.gotoGroupEditMembers();
        }

        public void refreshComponent()
        {
            MemberListControl.ItemsSource = GetObservableCollection.displayGroupMemberList(); ;
            InviteListControl.ItemsSource = GetObservableCollection.displayUsersFriendInviteMoreList();
        }
    }
}
