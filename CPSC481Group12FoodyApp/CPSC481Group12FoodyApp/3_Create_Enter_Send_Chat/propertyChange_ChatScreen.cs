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
    public class propertyChange_ChatScreen : INotifyPropertyChanged
    {
        private string notUser_abbreviation;
        private string notUser_chatSenderEmail;
        private string notUser_chatSenderName;
        private string notUser_chatMsg;
        private string notUser_chatTime;

        private string isUser_abbreviation;
        private string isUser_chatSenderEmail;
        private string isUser_chatSenderName;
        private string isUser_chatMsg;
        private string isUser_chatTime;

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public void OnPropertyChanged([CallerMemberName] String name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string NotUser_abbreviation
        {
            get { return notUser_abbreviation; }
            set
            {
                if (value != notUser_abbreviation)
                {
                    notUser_abbreviation = value;
                    OnPropertyChanged(nameof(NotUser_abbreviation));
                }
            }
        }

        public string NotUser_chatSenderEmail
        {
            get { return notUser_chatSenderEmail; }
            set
            {
                if (value != notUser_chatSenderEmail)
                {
                    notUser_chatSenderEmail = value;
                    OnPropertyChanged(nameof(NotUser_chatSenderEmail));
                }
            }
        }

        public string NotUser_chatSenderName
        {
            get { return notUser_chatSenderName; }
            set
            {
                if (value != notUser_chatSenderName)
                {
                    notUser_chatSenderName = value;
                    OnPropertyChanged(nameof(NotUser_chatSenderName));
                }
            }
        }

        public string NotUser_chatMsg
        {
            get { return notUser_chatMsg; }
            set
            {
                if (value != notUser_chatMsg)
                {
                    notUser_chatMsg = value;
                    OnPropertyChanged(nameof(NotUser_chatMsg));
                }
            }
        }

        public string NotUser_chatTime
        {
            get { return notUser_chatTime; }
            set
            {
                if (value != notUser_chatTime)
                {
                    notUser_chatTime = value;
                    OnPropertyChanged(nameof(NotUser_chatTime));
                }
            }
        }

        public string IsUser_abbreviation
        {
            get { return isUser_abbreviation; }
            set
            {
                if (value != isUser_abbreviation)
                {
                    isUser_abbreviation = value;
                    OnPropertyChanged(nameof(IsUser_abbreviation));
                }
            }
        }

        public string IsUser_chatSenderEmail
        {
            get { return isUser_chatSenderEmail; }
            set
            {
                if (value != isUser_chatSenderEmail)
                {
                    isUser_chatSenderEmail = value;
                    OnPropertyChanged(nameof(IsUser_chatSenderEmail));
                }
            }
        }

        public string IsUser_chatSenderName
        {
            get { return isUser_chatSenderName; }
            set
            {
                if (value != isUser_chatSenderName)
                {
                    isUser_chatSenderName = value;
                    OnPropertyChanged(nameof(IsUser_chatSenderName));
                }
            }
        }

        public string IsUser_chatMsg
        {
            get { return isUser_chatMsg; }
            set
            {
                if (value != isUser_chatMsg)
                {
                    isUser_chatMsg = value;
                    OnPropertyChanged(nameof(IsUser_chatMsg));
                }
            }
        }

        public string IsUser_chatTime
        {
            get { return isUser_chatTime; }
            set
            {
                if (value != isUser_chatTime)
                {
                    isUser_chatTime = value;
                    OnPropertyChanged(nameof(IsUser_chatTime));
                }
            }
        }
    }
}
