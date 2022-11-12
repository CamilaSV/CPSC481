using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CPSC481Group12FoodyApp
{
    public class ChatListVM : INotifyPropertyChanged
    {
        private string abbreviation;
        private string groupName;
        private string lastActive;


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /*private void NotifyPropertyChanged([CallerMemberName] String propName = "")
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        /*private ChatListVM() 
        {
            Abbreviation = "G";
            GroupName = "Girls";
            LastActive = "Last Active: 7h";
        }    */

        public static ChatListVM createNewChat()
        {
            return new ChatListVM();
        }

        public string Abbreviation
        {
            get { return this.abbreviation; }
            set
            {
                if (value != this.abbreviation)
                {
                    this.abbreviation = value;
                    OnPropertyChanged(nameof(Abbreviation));
                }
            }
        }
        public string GroupName
        {
            get { return this.groupName; }
            set
            {
                if (value != this.groupName )

                    this.groupName = value;
                OnPropertyChanged(nameof(GroupName));
            }
        }

        public string LastActive
        {
            get { return this.lastActive; }
            set
            {
                if (value != this.lastActive)
                {
                    this.lastActive = value;
                    OnPropertyChanged(nameof(LastActive));
                }
            }
        }

        

    }
}
