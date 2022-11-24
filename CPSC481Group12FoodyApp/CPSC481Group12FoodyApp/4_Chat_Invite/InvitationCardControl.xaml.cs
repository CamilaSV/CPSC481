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
    /// Interaction logic for InvitationCardControl.xaml
    /// </summary>
    public partial class InvitationCardControl : UserControl
    {
        internal PageNavigator navigator_helper;
        public InvitationCardControl()
        {
            InitializeComponent();
            this.navigator_helper = navigator_helper;
        }

        private void addBtn(object sender, RoutedEventArgs e)
        {
            API_ChatInvites.acceptChatInvite(ChatIdTextBlock.Text);
        }

        private void minusBtn(object sender, RoutedEventArgs e)
        {
            API_ChatInvites.removeOneChatInvite(SenderEmailTextBlock.Text, ChatIdTextBlock.Text);
        }
    }
}
