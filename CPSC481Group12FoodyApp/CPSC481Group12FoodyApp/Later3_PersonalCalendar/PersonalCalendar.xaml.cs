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
    /// Interaction logic for PersonalCalendar.xaml
    /// </summary>
    public partial class PersonalCalendar : Page
    {
        public PersonalCalendar()
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

        private void ChatInfoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteEventButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveRestaurantButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveRestraurant_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
