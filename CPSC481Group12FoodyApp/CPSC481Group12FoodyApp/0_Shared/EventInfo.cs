using System.Collections.Generic;
namespace CPSC481Group12FoodyApp.Logic
{
    public class EventInfo
    {
        public int id { get; set; }
        public long time { get; set; }
        public int restaurantId { get; set; }
        public string comment { get; set; }
        public List<string> attendees { get; set; }

        public EventInfo()
        {
            attendees = new List<string>();
        }
    }
}
