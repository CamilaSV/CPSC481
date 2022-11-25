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
    /// Interaction logic for ExpandRestaraunt.xaml
    /// </summary>
    public partial class ExpandRestaraunt: UserControl
    {
        public ExpandRestaraunt()
        {
            InitializeComponent();
        }

        private void Bottom_HomeButton_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.gotoHomePage();
        }

        private void Bottom_CalButton_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.gotoCalendar();
        }

        private void Bottom_ChatButton_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.gotoChatList();
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Bottom_TrashButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
