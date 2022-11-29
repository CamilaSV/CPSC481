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
    /// Interaction logic for InvitationCardControl.xaml
    /// </summary>
    public partial class InvitationCardControl : UserControl
    {
        public InvitationCardControl()
        {
            InitializeComponent();
        }

        private void addBtn(object sender, RoutedEventArgs e)
        {
            Logic_ChatInvites.acceptGroupInvite(Int32.Parse(ChatIdTextBlock.Text));
        }

        private void minusBtn(object sender, RoutedEventArgs e)
        {
            Logic_ChatInvites.removeOneGroupInvite(SessionData.getCurrentUser(), Int32.Parse(ChatIdTextBlock.Text), SenderEmailTextBlock.Text);
        }
    }
}
