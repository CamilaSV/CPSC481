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
    public class propertyChange_Friend : INotifyPropertyChanged
    {
        private string abbreviation;
        private string targetUserName;
        private string targetEmail;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            { 
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public string Abbreviation
        {
            get { return abbreviation; }
            set
            {
                if (value != abbreviation)
                {
                    abbreviation = value;
                    OnPropertyChanged("Abbreviation");
                }
            }
        }

        public string TargetUserName
        {
            get { return targetUserName; }
            set
            {
                if (value != targetUserName)
                {
                    targetUserName = value;
                    OnPropertyChanged("TargetUserName");
                }
            }
        }

        public string TargetEmail
        {
            get { return targetEmail; }
            set
            {
                if (value != targetEmail)
                {
                    targetEmail = value;
                    OnPropertyChanged("TargetEmail");
                }
            }
        }
    }
}
