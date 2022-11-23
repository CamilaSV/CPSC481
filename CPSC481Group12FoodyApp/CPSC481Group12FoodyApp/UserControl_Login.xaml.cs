﻿using System;
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
    /// Interaction logic for UserControl_Login.xaml
    /// </summary>
    public partial class UserControl_Login : Page
    {
        private PageNavigator navigate_helper;

        public UserControl_Login(PageNavigator navigate_helper)
        {
            InitializeComponent();
            this.navigate_helper = navigate_helper;
        }

        private void Login_RegisterText_MouseUp(object sender, MouseButtonEventArgs e)
        {
            navigate_helper.gotoRegister();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string result = Logic_Login.login(Login_EmailTextBox.Text, Login_PasswordBox.Password);

            if (result.Equals("true"))
            {
                UserProfile.currentUserEmail= Login_EmailTextBox.Text;
                navigate_helper.gotoChatList();
            }
            else
            {
                ErrorTextBlock.Text = result;
            }
        }

        private void Login_BackButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            navigate_helper.gotoStart();
        }
    }
}
