﻿using CPSC481Group12FoodyApp.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ChatScreen.xaml
    /// </summary>
    public partial class ChatScreen : UserControl, Interface_ChatMsgComponent
    {
        internal PageNavigator navigate_helper;

        public ChatScreen(PageNavigator navigate_helper)
        {
            InitializeComponent();
            this.navigate_helper= navigate_helper;
            ComponentFunctions.addComponentToList(this);
        }

        private void BackButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            navigate_helper.gotoChatList();
        }

        private void ChatInfoButton_Click(object sender, RoutedEventArgs e)
        {
            navigate_helper.gotoChatInfo();
        }

        public void refreshComponent()
        {
            ListControl.Items.Refresh();
        }
    }
}
