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
    /// Interaction logic for FriendRequestCardView.xaml
    /// </summary>
    public partial class FriendRequestCardControl : UserControl
    {
        public FriendRequestCardControl()
        {
            InitializeComponent();
        }

        private void Decline_Button_Click(object sender, RoutedEventArgs e)
        {
            Logic_Friend.denyFriendReq(EmailText.Text);
            
        }

        private void Accept_Button_Click(object sender, RoutedEventArgs e)
        {
            Logic_Friend.acceptFriendReq(EmailText.Text);
        }
    }
}
