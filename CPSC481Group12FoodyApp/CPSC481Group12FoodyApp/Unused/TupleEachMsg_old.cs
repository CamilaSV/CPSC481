using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;

namespace CPSC481Group12FoodyApp.Logic
{
    public class TupleEachMsg_old
    {
        private Tuple<string, string, string> message;

        public TupleEachMsg(string email, string message, string time)
        {
            this.message = new Tuple<string, string, string>(email, message, time);
        }

        public string getEmail()
        {
            return message.Item1;
        }

        public string getMessage()
        {
            return message.Item2;
        }

        public string getTime()
        {
            return message.Item3;
        }
    }
}
