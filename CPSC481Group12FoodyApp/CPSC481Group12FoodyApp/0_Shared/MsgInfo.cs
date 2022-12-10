using System.Collections.Generic;
namespace CPSC481Group12FoodyApp.Logic
{
    public class MsgInfo
    {
        public int id { get; set; }
        public string senderEmail { get; set; }
        public string content { get; set; }
        public long time { get; set; }
        public int evId { get; set; }
        public string resName { get; set; }
        public long evTime { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            MsgInfo other = obj as MsgInfo;

            return id == other.id;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }
    }
}
