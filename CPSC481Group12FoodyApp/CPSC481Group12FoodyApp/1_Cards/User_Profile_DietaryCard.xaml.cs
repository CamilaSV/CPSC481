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
    /// Interaction logic for DietaryCard.xaml
    /// </summary>
    public partial class DietaryCard : UserControl
    {
        bool criterionIdLoaded = false;

        public DietaryCard()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (criterionIdLoaded)
            {
                Logic_EditProfile.addUserDietaryChecked(CriterionIdText.Text);
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (criterionIdLoaded)
            {
                Logic_EditProfile.addUserDietaryUnchecked(CriterionIdText.Text);
            }
        }

        private void CriterionIdText_Loaded(object sender, RoutedEventArgs e)
        {
            criterionIdLoaded = true;
        }
    }
}
