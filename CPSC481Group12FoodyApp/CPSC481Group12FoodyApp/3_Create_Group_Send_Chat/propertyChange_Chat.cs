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
    public class propertyChange_Chat
    {
        public string Abbreviation { get; set; }
        public string ChatId { get; set; }
        public string ChatName { get; set; }
        public string ChatLastSender { get; set; }
        public string ChatLastMsg { get; set; }
        public string ChatLastTime { get; set; }
    }
}
