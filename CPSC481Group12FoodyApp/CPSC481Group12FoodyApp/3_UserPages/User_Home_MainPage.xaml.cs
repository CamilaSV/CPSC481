﻿using CPSC481Group12FoodyApp.Logic;
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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private bool leftLoaded = false;
        private bool rightLoaded = false;

        public HomePage()
        {
            InitializeComponent();
        }

        private void Bottom_CreateButton_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.gotoAddCategory();
        }

        private void LeftListControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (rightLoaded)
            {
                updateLists();
            }
        }

        private void RightListControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (leftLoaded)
            {
                updateLists();
            }
        }

        private void updateLists()
        {
            var allLists = GetObservableCollection.displayUserCategoryList();

            LeftListControl.ItemsSource = allLists.Item1;
            RightListControl.ItemsSource = allLists.Item2;
        }
    }
}
