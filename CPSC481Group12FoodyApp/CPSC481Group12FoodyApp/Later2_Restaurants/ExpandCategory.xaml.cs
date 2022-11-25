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
    /// Interaction logic for Template_WithBottom.xaml
    /// </summary>
    public partial class ExpandCategory: Page
    {
        public ExpandCategory()
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

        private void Bottom_CreateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChatInfoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void star1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void send4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void star2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void send2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void heart1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void send3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void forlater1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
