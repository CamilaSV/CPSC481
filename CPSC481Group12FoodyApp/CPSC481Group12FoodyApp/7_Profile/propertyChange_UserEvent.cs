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
    public class propertyChange_UserEvent
    {
        public string groupId { get; set; }
        public string groupName { get; set; }
        public string EventId { get; set; }
        public string EventTime { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantCriterion { get; set; }
    }
}
