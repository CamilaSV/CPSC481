using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CPSC481Group12FoodyApp
{
    public class propertyChange : INotifyPropertyChanged
    {

        private string abbreviation;
        private string groupName;
        private string lastActive;
        

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public void OnPropertyChanged([CallerMemberName] String name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string Abbreviation
        {
            get { return abbreviation; }
            set
            {
                if (value != abbreviation)
                {
                    abbreviation = value;
                    OnPropertyChanged(nameof(Abbreviation));
                }
            }
        }
        public string GroupName
        {
            get { return groupName; }
            set
            {
                if (value != groupName)
                {
                    groupName = value;
                    OnPropertyChanged(nameof(GroupName));
                }
            }
        }
        public string LastActive
        {
            get { return lastActive; }
            set
            {
                if (value != lastActive)
                {
                    lastActive = value;
                    OnPropertyChanged(nameof(LastActive));
                }
            }
        }

        
    }
}
