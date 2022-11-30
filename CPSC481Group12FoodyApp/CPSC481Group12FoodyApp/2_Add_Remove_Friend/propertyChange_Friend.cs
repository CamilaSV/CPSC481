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
    public class propertyChange_Friend
    {
        private string abbreviation;
        private string targetUserName;
        private string targetEmail;

        public string Abbreviation
        {
            get { return abbreviation; }
            set
            {
                if (value != abbreviation)
                {
                    abbreviation = value;
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
                }
            }
        }
    }
}
