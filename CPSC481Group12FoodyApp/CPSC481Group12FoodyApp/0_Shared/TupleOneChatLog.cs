using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;

namespace CPSC481Group12FoodyApp.Logic
{
    public class TupleOneChatLog
    {
        private Tuple<string, string, List<TupleEachMsg>> eachRoomChats;

        public TupleOneChatLog(string email, string chatName, List<TupleEachMsg> chatLog)
        {
            eachRoomChats = new Tuple<string, string, List<TupleEachMsg>>(email, chatName, chatLog);
        }

        public string getEmail()
        {
            return eachRoomChats.Item1;
        }

        public string getRoomName()
        {
            return eachRoomChats.Item2;
        }

        public string getOneMessageSender(int index)
        {
            return eachRoomChats.Item3.ElementAt(index).getEmail();
        }

        public string getOneMessageMessage(int index)
        {
            return eachRoomChats.Item3.ElementAt(index).getMessage();
        }

        public string getOneMessageTime(int index)
        {
            return eachRoomChats.Item3.ElementAt(index).getTime();
        }

        public void Add(TupleEachMsg item)
        {
            eachRoomChats.Item3.Add(item);
        }
    }
}
