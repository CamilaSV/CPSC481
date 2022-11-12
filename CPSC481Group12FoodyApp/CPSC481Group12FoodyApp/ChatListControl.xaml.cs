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
    /// Interaction logic for ChatListControl.xaml
    /// </summary>
    public partial class ChatListControl : UserControl
    {

        //public readonly List<ChatListGroupFields> ChatListGroup;
        //private List<ChatListGroupFields> ChatListGroup = new List<ChatListGroupFields>();
        //public IList<ChatListVM> ChatListGroup { get; set; }
        //public ObservableCollection<ChatListVM> ChatListGroup { get; set; }

        //public ObservableCollection<ChatListVM> ChatListGroup { get; set; }
        private ObservableCollection<ChatListVM> _ChatListGroup;
        public ObservableCollection<ChatListVM> ChatListGroup
        {
            get { return _ChatListGroup; }
            set
            {
                _ChatListGroup = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ChatListGroup"));
            }
        }

        public ChatListControl()
        {

            InitializeComponent();
            //this.DataContext = this;
            ChatListGroup = new ObservableCollection<ChatListVM>
            {
                //new ChatListVM() { Abbreviation = "G", GroupName = "Girls", LastActive = "Last Active: 8h" }
                new ChatListVM
                {
                    Abbreviation = "G",
                    GroupName = "Girls",
                    LastActive = "Last Active: 7h"
                },
                new ChatListVM
                {
                    Abbreviation = "Bssss",
                    GroupName = "Boys",
                    LastActive = "Last Active: 2h"
                },
                new ChatListVM
                {
                    Abbreviation = "a",
                    GroupName = "Boys",
                    LastActive = "Last Active: 2h"
                },
                new ChatListVM
                {
                    Abbreviation = "e",
                    GroupName = "Boys",
                    LastActive = "Last Active: 2h"
                },

        };
            this.DataContext = ChatListGroup;

        }

            public event PropertyChangedEventHandler PropertyChanged = delegate { };


        /*ChatListGroup = new ObservableCollection<ChatListVM>
        {
            //new ChatListVM() { Abbreviation = "G", GroupName = "Girls", LastActive = "Last Active: 8h" }
            new ChatListVM
            {
                Abbreviation = "G",
                GroupName = "Girls",
                LastActive = "Last Active: 7h"
            },
            new ChatListVM
            {
                Abbreviation = "B",
                GroupName = "Boys",
                LastActive = "Last Active: 2h"
            },
            new ChatListVM
            {
                Abbreviation = "a",
                GroupName = "Boys",
                LastActive = "Last Active: 2h"
            },
            new ChatListVM
            {
                Abbreviation = "e",
                GroupName = "Boys",
                LastActive = "Last Active: 2h"
            },

    };
        this.DataContext = ChatListGroup;
        /*ChatListGroup = new List<ChatListVM>();
        {
            new ChatListVM
            {
                Abbreviation = "G",
                GroupName = "Girls",
                LastActive = "Last Active: 7h"
            };

            new ChatListVM
            {
                Abbreviation = "B",
                GroupName = "Boys",
                LastActive = "Last Active: 2h"
            };
        };*/

    }

        
    
}
