using CPSC481Group12FoodyApp.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for UserControl_Profile.xaml
    /// </summary>
    public partial class UserControl_Profile : Page, Interface_Component
    {
        public UserControl_Profile()
        {
            InitializeComponent();
            ComponentFunctions.addComponentToList(this);
        }

        private void AddFriend_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.gotoAddFriend();
        }

        private void editBtn(object sender, RoutedEventArgs e)
        {

        }

        public void refreshComponent()
        {
            RequestControl.ItemsSource = GetObservableCollection.displayUsersFriendRequest();
            ListControl.ItemsSource = GetObservableCollection.displayUsersFriendList();
        }
    }
}
