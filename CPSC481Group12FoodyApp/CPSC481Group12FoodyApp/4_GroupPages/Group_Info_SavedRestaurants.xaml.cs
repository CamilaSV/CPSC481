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
    /// Interaction logic for ChatEditRestaurant.xaml
    /// </summary>
    public partial class ChatEditRestaurant : Page, Interface_Component
    {
        private int restaurantId_Remove;

        public ChatEditRestaurant()
        {
            InitializeComponent();
            ComponentFunctions.addComponentToList(this);
        }

        private void TopBar_Loaded(object sender, RoutedEventArgs e)
        {
            ComponentFunctions.setLabel(TopBar);
        }

        private void changeConfirmVisibility()
        {
            TopBar.IsHitTestVisible = false;
            ListControl.IsHitTestVisible = false;

            ConfirmRectangle.Visibility = Visibility.Visible;
            ConfirmGrid.Visibility = Visibility.Visible;
            ConfirmText.Visibility = Visibility.Visible;
            YesDelButton.Visibility = Visibility.Visible;
            NoDelButton.Visibility = Visibility.Visible;
        }

        private void exitConfirmVisibility()
        {
            ConfirmRectangle.Visibility = Visibility.Hidden;
            ConfirmGrid.Visibility = Visibility.Hidden;
            ConfirmText.Visibility = Visibility.Hidden;
            YesDelButton.Visibility = Visibility.Hidden;
            NoDelButton.Visibility = Visibility.Hidden;

            TopBar.IsHitTestVisible = true;
            ListControl.IsHitTestVisible = true;
        }

        public void loadRemove(int restaurantId)
        {
            restaurantId_Remove = restaurantId;
            changeConfirmVisibility();
        }

        private void exitRemove()
        {
            exitConfirmVisibility();
        }

        public void refreshComponent()
        {
            ListControl.ItemsSource = GetObservableCollection.displayGroupRestaurantList();
        }

        private void YesDelButton_Click(object sender, RoutedEventArgs e)
        {
            Logic_Group.removeGroupRestaurant(restaurantId_Remove);
            exitRemove();
        }

        private void NoDelButton_Click(object sender, RoutedEventArgs e)
        {
            exitRemove();
        }

        private void Suggest_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.gotoSuggestRestaurant();
        }
    }
}
