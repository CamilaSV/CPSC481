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

        public string TargetUserName
        {
            get { return targetUserName; }
            set
            {
                if (value != targetUserName)
                {
                    targetUserName = value;
                    OnPropertyChanged(nameof(TargetUserName));
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
                    OnPropertyChanged(nameof(TargetEmail));
                }
            }
        }
    }
}
