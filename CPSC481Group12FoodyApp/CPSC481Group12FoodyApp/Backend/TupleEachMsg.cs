using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;

namespace CPSC481Group12FoodyApp.Logic
{
    public class TupleEachMsg
    {
        private Tuple<string, string, DateTime> message;

        public TupleEachMsg(string email, string message, DateTime time)
        {
            this.message = new Tuple<string, string, DateTime>(email, message, time);
        }

        public string getEmail()
        {
            return message.Item1;
        }

        public string getMessage()
        {
            return message.Item2;
        }

        public DateTime getTime()
        {
            return message.Item3;
        }
    }
}
