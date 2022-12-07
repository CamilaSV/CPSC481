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
    /// Interaction logic for ExpandRestaurantOld.xaml
    /// </summary>
    public partial class ExpandRestaurantOld : UserControl
    {
        private int restaurantId;

        public ExpandRestaurantOld(int id)
        {
            restaurantId = id;
            InitializeComponent();
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

        private void Trash_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
