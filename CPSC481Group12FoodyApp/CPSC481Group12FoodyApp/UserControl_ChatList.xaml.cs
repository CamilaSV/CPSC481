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
    public partial class UserControl_ChatList : UserControl
    {
        internal PageNavigator navigate_helper;

        public UserControl_ChatList(PageNavigator navigate_helper)
        {
            InitializeComponent();
            this.navigate_helper= navigate_helper;
        }

        private void List_HomeButton_Click(object sender, RoutedEventArgs e)
        {
            navigate_helper.gotoHomePage();
        }

        private void List_CalButton_Click(object sender, RoutedEventArgs e)
        {
            navigate_helper.gotoCalendar();
        }

        private void List_ChatButton_Click(object sender, RoutedEventArgs e)
        {
            // do nothing, as you are already in this page
        }

        private void List_CreateGroup_Click(object sender, RoutedEventArgs e)
        {
            navigate_helper.gotoCreateGroup();
        }

        private void List_Profile_Click(object sender, RoutedEventArgs e)
        {
            navigate_helper.gotoProfile();
        }

        private void List_Invitation_Click(object sender, RoutedEventArgs e)
        {
            navigate_helper.gotoInvitation();
        }
    }
}
