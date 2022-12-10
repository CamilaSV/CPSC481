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
    /// Interaction logic for ChatEditMembers.xaml
    /// </summary>
    public partial class ChatEditMembers : Page, Interface_Component
    {
        private string emailRemove;

        public ChatEditMembers()
        {
            InitializeComponent();
            ComponentFunctions.addComponentToList(this);
        }

        private void TopBar_Loaded(object sender, RoutedEventArgs e)
        {
            ComponentFunctions.setLabel(TopBar);
        }

        public void loadRemove(string email)
        {
            emailRemove = email;

            setRemoveVisibilities();
        }

        private void setRemoveVisibilities()
        {
            TopBar.IsHitTestVisible = false;
            MemberListScroll.IsHitTestVisible = false;
            InviteListScroll.IsHitTestVisible = false;

            ConfirmRectangle.Visibility = Visibility.Visible;
            ConfirmGrid.Visibility = Visibility.Visible;
        }

        private void exitRemove()
        {
            TopBar.IsHitTestVisible = true;
            MemberListScroll.IsHitTestVisible = true;
            InviteListScroll.IsHitTestVisible = true;

            ConfirmRectangle.Visibility = Visibility.Hidden;
            ConfirmGrid.Visibility = Visibility.Hidden;
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            Logic_Group.removeGroupMember(SessionData.getCurrentGroupId(), emailRemove);
            exitRemove();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            exitRemove();
        }

        public void refreshComponent()
        {
            MemberListControl.ItemsSource = null;
            InviteListControl.ItemsSource = null;
            MemberListControl.ItemsSource = GetObservableCollection.displayGroupMemberList(); ;
            InviteListControl.ItemsSource = GetObservableCollection.displayUsersFriendInviteMoreList();
        }

        private void InviteButton_Click(object sender, RoutedEventArgs e)
        {
            Logic_Group.sendInvites(SessionData.getCurrentGroupId());
        }
    }
}
