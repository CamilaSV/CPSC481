using CPSC481Group12FoodyApp.Logic;
using System;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for GroupChatMessagesCard.xaml
    /// </summary>
    public partial class GroupChatMessagesCard
    {
        public GroupChatMessagesCard()
        {
            InitializeComponent();
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            Logic_Group.acceptGroupEvent(SessionData.getCurrentGroupId(), Int32.Parse(EventIdText.Text));
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            Logic_Group.denyGroupEvent(SessionData.getCurrentGroupId(), Int32.Parse(EventIdText.Text));
        }

        private void setVisibilities()
        {
            if (bool.Parse(IsSenderText.Text))
            {
                SenderGrid.Visibility = Visibility.Visible;
            }
            else if (bool.Parse(IsJoinText.Text))
            {
                UserJoinedGrid.Visibility = Visibility.Visible;
            }
            else if (bool.Parse(IsEventText.Text))
            {
                var status = Int32.Parse(IsEventConfirmedText.Text);

                if (status == -1)
                {
                    YesButton.Visibility = Visibility.Visible;
                    NoButton.Visibility = Visibility.Visible;
                    ConfirmText.Visibility = Visibility.Hidden;
                }
                else if (status == 0)
                {
                    YesButton.Visibility = Visibility.Hidden;
                    NoButton.Visibility = Visibility.Hidden;
                    ConfirmText.Foreground = Brushes.Red;
                    ConfirmText.Text = "⨉";
                    ConfirmText.Visibility = Visibility.Visible;
                }
                else
                {
                    YesButton.Visibility = Visibility.Hidden;
                    NoButton.Visibility = Visibility.Hidden;
                    ConfirmText.Foreground = Brushes.Green;
                    ConfirmText.Text = "✓";
                    ConfirmText.Visibility = Visibility.Visible;
                }

                EventGrid.Visibility = Visibility.Visible;
            }
            else
            {
                ReceiverGrid.Visibility = Visibility.Visible;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            setVisibilities();
        }
    }
}
