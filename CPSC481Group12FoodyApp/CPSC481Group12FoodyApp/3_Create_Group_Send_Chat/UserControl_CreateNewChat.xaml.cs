using CPSC481Group12FoodyApp.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
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
using System.Xml.Linq;

namespace CPSC481Group12FoodyApp
{
    /// <summary>
    /// Interaction logic for UserControl_CreateNewChat.xaml
    /// </summary>
    public partial class UserControl_CreateNewChat : Page, Interface_Component
    {
        public UserControl_CreateNewChat()
        {
            InitializeComponent();
            ComponentFunctions.addComponentToList(this);
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
            Logic_Group.createGroup(this);
        }

        public void refreshComponent()
        {
            ListControl.ItemsSource = GetObservableCollection.displayUsersFriendInviteList();
        }

        private void GroupNameText_GotFocus(object sender, RoutedEventArgs e)
        {
            GroupNameText.Text = string.Empty;
        }

        private void GroupNameText_LostFocus(object sender, RoutedEventArgs e)
        {
            if (GroupNameText.Text.Equals(string.Empty))
            {
                GroupNameText.Text = "Enter a group name";
            }
        }
    }
}
