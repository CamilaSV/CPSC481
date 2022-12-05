using CPSC481Group12FoodyApp.Logic;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for MainStylesDictionary.xaml
    /// </summary>
    public partial class MainStylesDictionary
    {
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.goBack();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.gotoHomePage();
        }

        private void CalendarButton_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.gotoCalendar();
        }

        private void ChatlistButton_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.gotoChatList();
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.gotoProfile();
        }

        private void ChatInfoButton_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.gotoChatInfo();
        }
    }
}
