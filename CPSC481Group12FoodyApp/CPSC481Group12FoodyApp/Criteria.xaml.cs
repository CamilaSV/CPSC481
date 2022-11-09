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
    /// Interaction logic for Criteria.xaml
    /// </summary>
    public partial class Criteria : UserControl
    {
        private PageNavigator navigator_helper;
        public Criteria(PageNavigator navigator_helper)
        {
            InitializeComponent();
            this.navigator_helper = navigator_helper;
        }

        private void addCriteriaBtn_Click(object sender, RoutedEventArgs e)
        {
            navigator_helper.gotoCriteria();
        }
    }
}
