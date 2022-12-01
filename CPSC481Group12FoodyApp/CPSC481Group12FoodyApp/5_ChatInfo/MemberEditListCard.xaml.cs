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
    /// Interaction logic for MemberEditListCard.xaml
    /// </summary>
    public partial class MemberEditListCard : UserControl
    {
        public MemberEditListCard()
        {
            InitializeComponent();
        }

        private void Delete_Member_Click(object sender, RoutedEventArgs e)
        {
            Logic_Group.removeGroupMember(SessionData.getCurrentGroupId(), EmailText.Text);
        }

        private void Demote_Member_Click(object sender, RoutedEventArgs e)
        {
            Logic_Group.demoteGroupMember(SessionData.getCurrentGroupId(), EmailText.Text);
        }

        private void Promote_Member_Click(object sender, RoutedEventArgs e)
        {
            Logic_Group.promoteGroupMember(SessionData.getCurrentGroupId(), EmailText.Text);
        }

        private void CheckAdminEmail(object sender, DataTransferEventArgs e)
        {
            if (!string.IsNullOrEmpty(IsAdminText.Text)) {
                if (Boolean.Parse(IsAdminText.Text))
                {
                    changeVisibility();
                }
            }
        }

        private void CheckAdminTrue(object sender, DataTransferEventArgs e)
        {
            if (!string.IsNullOrEmpty(EmailText.Text))
            {
                changeVisibility();
            }
        }

        private void changeVisibility()
        {
            if (SessionData.getGroupAdmins(SessionData.getCurrentGroupId()).Contains(SessionData.getCurrentUser()))
            {
                if (Boolean.Parse(IsAdminText.Text))
                {
                    AdminText.Visibility = Visibility.Visible;

                    if (!EmailText.Text.Equals(SessionData.getCurrentUser()))
                    {
                        DemoteButton.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    if (!EmailText.Text.Equals(SessionData.getCurrentUser()))
                    {
                        PromoteButton.Visibility = Visibility.Visible;
                        AdminButton.Visibility = Visibility.Visible;
                    }
                }
            }
            else
            {
                if (Boolean.Parse(IsAdminText.Text))
                {
                    AdminText.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
