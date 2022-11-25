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
    /// Interaction logic for UserControl_Login.xaml
    /// </summary>
    public partial class UserControl_Invitations : UserControl, Interface_ChatInvComponent
    {
        public UserControl_Invitations()
        {
            InitializeComponent();
            ComponentFunctions.addComponentToList(this);
        }

        private void List_HomeButton_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.gotoHomePage();
        }

        private void List_CalButton_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.gotoCalendar();
        }

        private void List_ChatButton_Click(object sender, RoutedEventArgs e)
        {
            // do nothing, as you are already in this page
        }

        private void List_CreateGroup_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.gotoCreateGroup();
        }

        private void List_Profile_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.gotoProfile();
        }

        private void BackButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            PageNavigator.gotoChatList();
        }

        public void refreshComponent()
        {
            ListControl.Items.Refresh();
        }
    }
}
