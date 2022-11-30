﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CPSC481Group12FoodyApp
{
    public class propertyChange_ChatInvite
    {
        private string groupName;
        private string senderName;
        private string groupId;
        private string senderEmail;

        public string GroupName
        {
            get { return groupName; }
            set
            {
                if (value != groupName)
                {
                    groupName = value;
                }
            }
        }

        public string SenderName
        {
            get { return senderName; }
            set
            {
                if (value != senderName)
                {
                    senderName = value;
                }
            }
        }

        public string GroupId
        {
            get { return groupId; }
            set
            {
                if (value != groupId)
                {
                    groupId = value;
                }
            }
        }

        public string SenderEmail
        {
            get { return senderEmail; }
            set
            {
                if (value != senderEmail)
                {
                    senderEmail = value;
                }
            }
        }
    }
}
