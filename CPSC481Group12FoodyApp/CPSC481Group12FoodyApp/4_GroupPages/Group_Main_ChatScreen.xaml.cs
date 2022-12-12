using CPSC481Group12FoodyApp.Logic;
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
    public partial class ChatScreen : UserControl, Interface_Component
    {
        List<propertyChange_ChatScreen> oldOnes;
        List<propertyChange_ChatScreen> newOnes;

        public ChatScreen()
        {
            oldOnes = new List<propertyChange_ChatScreen>();
            InitializeComponent();
            ComponentFunctions.addComponentToList(this);
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            Logic_Chat.sendMsg(SessionData.getCurrentUser(), SessionData.getCurrentGroupId(), MsgTextBox.Text);
            MsgTextBox.Text = string.Empty;
        }

        public void refreshComponent()
        {
            newOnes = GetObservableCollection.displayChatModels();
            if (!oldOnes.SequenceEqual(newOnes))
            {
                oldOnes = newOnes;
                ListControl.ItemsSource = newOnes;
                ChatScroll.ScrollToBottom();
            }
        }

        private void TopBar_Loaded(object sender, RoutedEventArgs e)
        {
            ComponentFunctions.setLabel(TopBar);
        }

        private void ListControl_Loaded(object sender, RoutedEventArgs e)
        {
            ListControl.ItemsSource = GetObservableCollection.displayChatModels();
            ChatScroll.ScrollToBottom();
        }
    }
}
