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
    /// Interaction logic for ChatEditRestaurantRemoveNew.xaml
    /// </summary>
    public partial class ChatEditRestaurantRemoveNew : Page
    {
        private int idRemove;

        public ChatEditRestaurantRemoveNew(int idRemove)
        {
            InitializeComponent();
            this.idRemove = idRemove;
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
