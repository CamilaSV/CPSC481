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
    /// Interaction logic for ChatInfoScreen.xaml
    /// </summary>
    public partial class ChatInfoScreen : Page
    {
        public ChatInfoScreen()
        {
            InitializeComponent();
        }

        private void Criteria_ShowMoreButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Restaurant_ShowMoreButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void SchedulerDateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SchedulerTimeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreateEventButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.gotoOneChat();
        }

        private void MemberShowMore_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
