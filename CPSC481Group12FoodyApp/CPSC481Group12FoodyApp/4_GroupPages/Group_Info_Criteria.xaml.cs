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
    /// Interaction logic for ChatEditCriteria.xaml
    /// </summary>
    public partial class ChatEditCriteria : Page, Interface_Component
    {
        List<propertyChange_GroupCriteria> listOrig;
        List<propertyChange_GroupCriteria> listNew;
        public ChatEditCriteria()
        {
            listOrig = GetObservableCollection.displayGroupCriteriaList();
            InitializeComponent();
            ComponentFunctions.addComponentToList(this);
        }

        private void TopBar_Loaded(object sender, RoutedEventArgs e)
        {
            ComponentFunctions.setLabel(TopBar);
        }

        public void refreshComponent()
        {
            listNew = GetObservableCollection.displayGroupCriteriaList();

            for (var i = 0; i < listOrig.Count; i++)
            {
                if ((listOrig[i].CriterionId == listNew[i].CriterionId) &&
                    (listOrig[i].TargetEmail == listNew[i].TargetEmail))
                {
                    continue;
                }

                listOrig = listNew;
                ListControl.ItemsSource = listNew;
                break;
            }
        }

        private void ListControl_Loaded(object sender, RoutedEventArgs e)
        {
            ListControl.ItemsSource = listOrig;
        }
    }
}
