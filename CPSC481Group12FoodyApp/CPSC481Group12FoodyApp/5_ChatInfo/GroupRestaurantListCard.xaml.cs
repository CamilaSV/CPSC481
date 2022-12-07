using CPSC481Group12FoodyApp.Logic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for GroupRestaurantListCard.xaml
    /// </summary>
    public partial class GroupRestaurantListCard : UserControl
    {
        public GroupRestaurantListCard()
        {
            InitializeComponent();
        }

        private void vote_Restaurant_Click(object sender, RoutedEventArgs e)
        {
            
        }

        
        private void removeRestaurantButton(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Card is clickable");
        }
    }
}
