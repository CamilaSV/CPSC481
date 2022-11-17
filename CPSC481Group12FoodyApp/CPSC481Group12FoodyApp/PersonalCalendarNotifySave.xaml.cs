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
    /// Interaction logic for PersonalCalendarNotifySave.xaml
    /// </summary>
    public partial class PersonalCalendarNotifySave : Page
    {
        private PageNavigator navigate_helper;

        public PersonalCalendarNotifySave(PageNavigator navigate_helper)
        {
            InitializeComponent();
            this.navigate_helper = navigate_helper;
        }

        private void Bottom_HomeButton_Click(object sender, RoutedEventArgs e)
        {
            navigate_helper.gotoHomePage();
        }

        private void Bottom_CalButton_Click(object sender, RoutedEventArgs e)
        {
            navigate_helper.gotoCalendar();
        }

        private void Bottom_ChatButton_Click(object sender, RoutedEventArgs e)
        {
            navigate_helper.gotoChatList();
        }

        private void Bottom_CreateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
