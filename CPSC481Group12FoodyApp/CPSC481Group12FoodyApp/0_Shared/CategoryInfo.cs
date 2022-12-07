using System.Collections.Generic;
using System.Windows.Documents;

namespace CPSC481Group12FoodyApp.Logic
{
    public class CategoryInfo
    {
        public int id { get; set; }
        public string name { get; set; }
        public Dictionary<int, string> restaurantList { get; set; }

        public CategoryInfo() 
        { 
            restaurantList = new Dictionary<int, string>(); // restaurantId is Key, Notes is Value
        }
    }
}
