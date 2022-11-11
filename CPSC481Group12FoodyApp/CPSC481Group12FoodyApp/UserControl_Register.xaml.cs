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
    /// Interaction logic for UserControl_Register.xaml
    /// </summary>
    public partial class UserControl_Register : UserControl
    {
        private PageNavigator navigate_helper;

        public UserControl_Register(PageNavigator navigate_helper)
        {
            InitializeComponent();
            this.navigate_helper = navigate_helper;
        }

        private void Register_SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            navigate_helper.gotoChatList();
        }

        private void Register_BackButton_Click(object sender, RoutedEventArgs e)
        {
            navigate_helper.gotoStart();
        }

        private void Register_LoginText_MouseUp(object sender, MouseButtonEventArgs e)
        {
            navigate_helper.gotoLogin();
        }
    }
}
