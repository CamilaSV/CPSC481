using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CPSC481Group12FoodyApp.Logic
{
    public class VoteInfo
    {
        public int resId { get; set; }
        public List<string> usersVoted { get; set; }

        public VoteInfo()
        {
            usersVoted = new List<string>();
        }
    }
}
