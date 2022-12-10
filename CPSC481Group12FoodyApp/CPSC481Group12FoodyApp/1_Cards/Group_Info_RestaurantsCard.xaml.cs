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
using System.Windows.Threading;

namespace CPSC481Group12FoodyApp
{
    /// <summary>
    /// Interaction logic for GroupRestaurantListCard.xaml
    /// </summary>
    public partial class GroupRestaurantListCard : UserControl
    {
        bool isCardLoaded = false;
        bool isCriteriaLoaded = false;

        public GroupRestaurantListCard()
        {
            InitializeComponent();
        }

        private void Grid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //Debug.WriteLine("Card is clickable");

            //if (string.IsNullOrEmpty(showMoreTxt.Text))
            //{
                if (e.ClickCount == 1)
                {
                    this.Height = critList.ActualHeight + 180/2;
                    this.showMoreTxt.Text = "Click to minimize.";
                }
                else
                {
                    this.Height = 180;
                    this.showMoreTxt.Text = "Click to show more...";
                }
            //}
        }

        private void Trash_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.gotoGroupResturantDeleteConfirm(RestaurantIdText.Text);
        }

        private void voteButton_Click(object sender, RoutedEventArgs e)

        {

            Logic_Group.addUserVote(Int32.Parse(RestaurantIdText.Text));

        }
    }
}
