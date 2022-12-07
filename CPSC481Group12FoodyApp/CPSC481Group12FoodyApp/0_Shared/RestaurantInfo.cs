using System.Collections.Generic;

namespace CPSC481Group12FoodyApp.Logic
{
    public class RestaurantInfo
    {
        public string name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string postal_code { get; set; }
        public List<int> criteriaList { get; set; }

        public RestaurantInfo()
        {
            criteriaList = new List<int>();
        }
    }
}
