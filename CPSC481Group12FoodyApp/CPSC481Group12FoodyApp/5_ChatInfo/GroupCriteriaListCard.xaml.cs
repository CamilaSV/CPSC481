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
    /// Interaction logic for GroupCriteriaListCard.xaml
    /// </summary>
    public partial class GroupCriteriaListCard : UserControl
    {
        private int groupCriteria = 0;
        private Boolean userUpdated;
        private Boolean idUpdated;

        public GroupCriteriaListCard()
        {
            InitializeComponent();
            userUpdated = false;
            idUpdated = false;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Logic_Group.removeGroupCriteria(TargetEmailTextBlock.Text);
            selectModeOn();
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            Logic_Group.addGroupCriteria(groupCriteria, TargetEmailTextBlock.Text);
            deleteModeOn();
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var list = SessionData.getAllPresetCriteria();

            for (int i = 0; i < list.Count; i++)
            {
                CriteriaSelectBox.Items.Add(list[i].criteria);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            groupCriteria = CriteriaSelectBox.SelectedIndex;
        }

        private void CheckUserName(object sender, DataTransferEventArgs e)
        {
            userUpdated = true;

            changeVisibility();
        }

        private void CheckCritId(object sender, DataTransferEventArgs e)
        {
            idUpdated = true;

            changeVisibility();
        }

        private void changeVisibility()
        {
            if (userUpdated && idUpdated)
            {
                if (UserNameBlock.Text.Equals("Me"))
                {
                    System.Diagnostics.Debug.WriteLine("ID is: " + CriterionIdTextBlock.Text);
                    if (CriterionIdTextBlock.Text.Equals("none"))
                    {
                        selectModeOn();
                    }
                    else
                    {
                        deleteModeOn();
                    }
                }
            }
        }

        private void selectModeOn()
        {
            CriterionTextBlock.Visibility = Visibility.Hidden;
            DeleteButton.Visibility = Visibility.Hidden;
            CriteriaSelectBox.Visibility = Visibility.Visible;
            SelectButton.Visibility = Visibility.Visible;
        }

        private void deleteModeOn()
        {
            CriteriaSelectBox.Visibility = Visibility.Hidden;
            SelectButton.Visibility = Visibility.Hidden;
            CriterionTextBlock.Visibility = Visibility.Visible;
            DeleteButton.Visibility = Visibility.Visible;
        }
    }
}
