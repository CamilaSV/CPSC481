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
    /// Interaction logic for MemberCardControl.xaml
    /// </summary>
    public partial class MemberCardControl : UserControl
    {
        public MemberCardControl()
        {
            InitializeComponent();
            if (Boolean.Parse(IsAdminText.Text))
            {
                AdminText.Visibility = Visibility.Visible;

                if (EmailText.Text.Equals(SessionData.getCurrentUser()))
                {
                    AdminButton.Visibility = Visibility.Visible;
                }
            }
        }

        private void Delete_Member_Click(object sender, RoutedEventArgs e)
        {
            Logic_Group.removeGroupMember(SessionData.getCurrentGroupId(), EmailText.Text);
        }
    }
}
