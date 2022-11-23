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
        private string userName;
        private string targetUserName;
        private string targetEmail;
        private string chatId;
        private string chatName;
        private string chatLastSender;
        private string chatLastMsg;
        private DateTime chatLastTime;


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

        public string UserName
        {
            get { return userName; }
            set
            {
                if (value != userName)
                {
                    userName = value;
                    OnPropertyChanged(nameof(UserName));
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

        public string ChatId
        {
            get { return chatId; }
            set
            {
                if (value != chatId)
                {
                    chatId = value;
                    OnPropertyChanged(nameof(ChatId));
                }
            }
        }

        public string ChatName
        {
            get { return chatName; }
            set
            {
                if (value != chatName)
                {
                    chatName = value;
                    OnPropertyChanged(nameof(ChatName));
                }
            }
        }

        public string ChatLastSender
        {
            get { return chatLastSender; }
            set
            {
                if (value != chatLastSender)
                {
                    chatLastSender = value;
                    OnPropertyChanged(nameof(ChatLastSender));
                }
            }
        }

        public string ChatLastMsg
        {
            get { return chatLastMsg; }
            set
            {
                if (value != chatLastMsg)
                {
                    chatLastMsg = value;
                    OnPropertyChanged(nameof(ChatLastMsg));
                }
            }
        }

        public DateTime ChatLastTime
        {
            get { return chatLastTime; }
            set
            {
                if (value != chatLastTime)
                {
                    chatLastTime = value;
                    OnPropertyChanged(nameof(ChatLastTime));
                }
            }
        }
    }
}
