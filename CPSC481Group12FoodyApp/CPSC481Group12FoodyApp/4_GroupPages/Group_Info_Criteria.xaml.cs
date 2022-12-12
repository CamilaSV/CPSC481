using CPSC481Group12FoodyApp.Logic;
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
        List<propertyChange_GroupCriteria> groupCritOrig;
        List<propertyChange_GroupCriteria> groupCritNew;
        public ChatEditCriteria()
        {
            groupCritOrig = GetObservableCollection.displayGroupCriteriaList();
            InitializeComponent();
            ComponentFunctions.addComponentToList(this);
        }

        private void TopBar_Loaded(object sender, RoutedEventArgs e)
        {
            ComponentFunctions.setLabel(TopBar);
        }

        public void refreshComponent()
        {
            groupCritNew = GetObservableCollection.displayGroupCriteriaList();

            for (var i = 0; i < groupCritOrig.Count; i++)
            {
                if ((groupCritOrig[i].CriterionId == groupCritNew[i].CriterionId) &&
                    (groupCritOrig[i].TargetEmail == groupCritNew[i].TargetEmail))
                {
                    continue;
                }

                groupCritOrig = groupCritNew;
                ListControl.ItemsSource = groupCritNew;
                break;
            }
        }

        private void ListControl_Loaded(object sender, RoutedEventArgs e)
        {
            ListControl.ItemsSource = groupCritOrig;
        }
    }
}
