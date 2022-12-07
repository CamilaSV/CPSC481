using System.Collections.Generic;
using System.Windows.Documents;

namespace CPSC481Group12FoodyApp.Logic
{
    public class CategoryInfo
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<int> restaurantList { get; set; }

        public CategoryInfo() 
        { 
            restaurantList = new List<int>();
        }
    }
}
