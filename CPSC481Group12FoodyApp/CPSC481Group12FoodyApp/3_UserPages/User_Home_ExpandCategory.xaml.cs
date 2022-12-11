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
    /// Interaction logic for Template_WithBottom.xaml
    /// </summary>
    public partial class ExpandCategory: Page
    {
        public ExpandCategory()
        {
            InitializeComponent();
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            enableUnderDev();
        }

        private void Bottom_CreateButton_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.gotoUserAddRestaurant();
        }

        private void Category_Loaded(object sender, RoutedEventArgs e)
        {
            Category.Text = SessionData.getUserCategoryName(SessionData.getCurrentUser(), SessionData.getCurrentCatId());
        }

        private void ListControl_Loaded(object sender, RoutedEventArgs e)
        {
            ListControl.ItemsSource = GetObservableCollection.displayUserCategoryRestaurantList(SessionData.getCurrentCatId());
        }

        public void enableUnderDev()
        {
            UnderDevRec.Visibility = Visibility.Visible;
            UnderDevGrid.Visibility = Visibility.Visible;

            TopBar.IsHitTestVisible = false;
            BottomBar.IsHitTestVisible = false;
            Filter.IsHitTestVisible = false;
            Bottom_CreateButton.IsHitTestVisible = false;
            ListControl.IsHitTestVisible = false;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            TopBar.IsHitTestVisible = true;
            BottomBar.IsHitTestVisible = true;
            Filter.IsHitTestVisible = true;
            Bottom_CreateButton.IsHitTestVisible = true;
            ListControl.IsHitTestVisible = true;

            UnderDevRec.Visibility = Visibility.Hidden;
            UnderDevGrid.Visibility = Visibility.Hidden;
        }
    }
}
