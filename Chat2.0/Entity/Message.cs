using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat2._0.Entity
{
    class Message
    {
        public long IdMessage { get; set; }
        public long SenderID { get; set; }
        public long TopicID { get; set; }
        public System.DateTime Time { get; set; }
        public string Massage { get; set; }
        public string SenderName { get; set; }
    }
}
