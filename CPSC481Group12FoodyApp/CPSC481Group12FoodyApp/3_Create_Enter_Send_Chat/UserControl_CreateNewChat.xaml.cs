using CPSC481Group12FoodyApp.Logic;
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

namespace CPSC481Group12FoodyApp
{
    /// <summary>
    /// Interaction logic for UserControl_CreateNewChat.xaml
    /// </summary>
    public partial class UserControl_CreateNewChat : Page, Interface_FriendListComponent
    {
        public UserControl_CreateNewChat()
        {
            InitializeComponent();
        }

        private void Bottom_ChatButton_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.gotoChatList();
        }

        private void Bottom_CalButton_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.gotoCalendar();
        }

        private void Bottom_HomeButton_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.gotoHomePage();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.gotoChatList();
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.gotoProfile();
        }

        private void CreateGroupButton_Click(object sender, RoutedEventArgs e)
        {
            API_CreateLoadChat.createChat(this);
        }

        public void refreshComponent()
        {
            throw new NotImplementedException();
        }
    }
}
