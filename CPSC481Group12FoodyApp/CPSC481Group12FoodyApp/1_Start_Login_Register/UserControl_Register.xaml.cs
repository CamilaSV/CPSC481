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
    /// Interaction logic for UserControl_Register.xaml
    /// </summary>
    public partial class UserControl_Register : Page
    {
        public UserControl_Register()
        {
            InitializeComponent();
        }

        private void Register_SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            API_Register.register(this);
        }

        private void Register_LoginText_MouseUp(object sender, MouseButtonEventArgs e)
        {
            PageNavigator.gotoLogin();
        }
        private void Register_BackButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            PageNavigator.gotoStart();
        }
    }
}
