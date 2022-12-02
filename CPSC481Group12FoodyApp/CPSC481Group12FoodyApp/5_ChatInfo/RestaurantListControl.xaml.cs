﻿using CPSC481Group12FoodyApp.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for RestaurantListControl.xaml
    /// </summary>
    public partial class RestaurantListControl : UserControl, Interface_Component
    {
        public RestaurantListControl()
        {
            InitializeComponent();
            ComponentFunctions.addComponentToList(this);
        }

        public void refreshComponent()
        {
            //ListControl.ItemsSource = GetObservableCollection.displayGroupMemberList();
        }
    }
}