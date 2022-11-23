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
    /// Interaction logic for UserControl_AddFriends.xaml
    /// </summary>
    public partial class UserControl_AddFriends : UserControl
    {
        internal PageNavigator navigate_helper;

        public UserControl_AddFriends(PageNavigator navigate_helper)
        {
            InitializeComponent();
            this.navigate_helper= navigate_helper;
        }

        private void AddFriendSubmissionButton_Click(object sender, RoutedEventArgs e)
        {
            Logic_AddRemFriend.addFriend(UserProfile.currentUserEmail, AddFriendTextBox.Text);
            navigate_helper.gotoProfile();
        }

    }
}
