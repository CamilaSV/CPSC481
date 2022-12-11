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
    /// Interaction logic for RestaurantCatCardControl.xaml
    /// </summary>
    public partial class RestaurantCatCardControl : UserControl
    {
        public RestaurantCatCardControl()
        {
            InitializeComponent();
        }

        private void star_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.gotoExtendCategoryUnderDev();
        }

        private void ResShowMore_Click(object sender, RoutedEventArgs e)
        {
            SessionData.setCurrentResId(Int32.Parse(RestaurantIdText.Text));
            PageNavigator.gotoExpandRestaurant();
        }
    }
}
