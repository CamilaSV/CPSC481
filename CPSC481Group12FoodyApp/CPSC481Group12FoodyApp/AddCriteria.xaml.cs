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
    /// Interaction logic for AddCriteria.xaml
    /// </summary>
    public partial class AddCriteria : UserControl
    {
        private PageNavigator navigate_helper;

        public AddCriteria(PageNavigator navigate_helper)
        {
            InitializeComponent();
            this.navigate_helper = navigate_helper;
        }

        private void submissionButtion_Click(object sender, RoutedEventArgs e)
        {
            testLabel.Content = criteriaText.Text;
        }
    }
}
