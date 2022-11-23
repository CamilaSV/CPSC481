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
    /// Interaction logic for Template_NoBottom.xaml
    /// </summary>
    public partial class ChatScheduler : Page
    {
        internal PageNavigator navigate_helper;

        public ChatScheduler(PageNavigator navigate_helper)
        {
            this.navigate_helper = navigate_helper;
        }

        private void AddTimeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
