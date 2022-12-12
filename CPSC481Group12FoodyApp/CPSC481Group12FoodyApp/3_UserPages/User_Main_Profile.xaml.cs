using CPSC481Group12FoodyApp.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
            UserBioText.IsReadOnly = false;
            UserBioText.Focus();
            Save.Visibility = Visibility.Visible;
            Edit.Visibility = Visibility.Hidden;
        }

        private void saveBtn(object sender, RoutedEventArgs e)
        {
            string newBio = UserBioText.Text;
            if (newBio.Length > 50)
            {
                UserBioText.Text = "Please limit your bio to 50 characters or less.";
            }
            else
            {
                UserBioText.IsReadOnly = true;
                Logic_EditProfile.editUserBio(SessionData.getCurrentUser(), UserBioText.Text);
            }

            Edit.Visibility = Visibility.Visible;
            Save.Visibility = Visibility.Hidden;
        }

        public void refreshComponent()
        {
            AbbreviationText.Text = SessionData.getUserDisplayName(SessionData.getCurrentUser()).Substring(0, 1);
            UserNameText.Text = SessionData.getUserDisplayName(SessionData.getCurrentUser());
            UserBioText.Text = SessionData.getUserBio(SessionData.getCurrentUser());
            RequestControl.ItemsSource = GetObservableCollection.displayUsersFriendRequest();
            ListControl.ItemsSource = GetObservableCollection.displayUsersFriendList();
        }

        private void CriteriaControl_Loaded(object sender, RoutedEventArgs e)
        {
            CriteriaControl.ItemsSource = GetObservableCollection.displayUserDietaryList();
            CriteriaControl.IsHitTestVisible = false;
        }
    }
}
