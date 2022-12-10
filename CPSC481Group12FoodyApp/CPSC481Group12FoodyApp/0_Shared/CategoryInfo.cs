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

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            CategoryInfo other = obj as CategoryInfo;

            return id == other.id;
        }
    }
}
