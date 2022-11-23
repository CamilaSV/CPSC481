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
        private PageNavigator navigate_helper;

        public UserControl_Register(PageNavigator navigate_helper)
        {
            InitializeComponent();
            this.navigate_helper = navigate_helper;
        }

        private void Register_SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            string result = Logic_Register.register(Register_EmailTextBox.Text, Register_PasswordBox.Password);

            if (result.Equals("true"))
            {
                UserProfile.currentUserEmail = Register_EmailTextBox.Text;
                navigate_helper.gotoChatList();
            }
            else
            {
                ErrorTextBlock.Text = result;
            }
        }

        private void Register_LoginText_MouseUp(object sender, MouseButtonEventArgs e)
        {
            navigate_helper.gotoLogin();
        }
        private void Register_BackButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            navigate_helper.gotoStart();
        }
    }
}
