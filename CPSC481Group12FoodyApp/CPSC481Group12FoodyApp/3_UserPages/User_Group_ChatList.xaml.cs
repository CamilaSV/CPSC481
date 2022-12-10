using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

using CPSC481Group12FoodyApp.Logic;

namespace CPSC481Group12FoodyApp
{
    /// <summary>
    /// Interaction logic for UserControl_Login.xaml
    /// </summary>
    public partial class UserControl_ChatList : UserControl, Interface_Component
    {
        public UserControl_ChatList()
        {
            InitializeComponent();
            ComponentFunctions.addComponentToList(this);
        }

        public void refreshComponent()
        {
            if (GetObservableCollection.displayUsersGroupInviteList().Count > 0)
            {
                List_Invitation.Background = Brushes.LightPink;
            }
            else
            {
                List_Invitation.Background = Brushes.LightSkyBlue;
            }

            ListControl.ItemsSource = GetObservableCollection.displayUsersChatList();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.gotoCreateGroup();
        }

        private void List_Invitation_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.gotoInvitation();
        }

        private void ListControl_Loaded(object sender, RoutedEventArgs e)
        {
            ListControl.ItemsSource = GetObservableCollection.displayUsersChatList();
        }
    }
}
