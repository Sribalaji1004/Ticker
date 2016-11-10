using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_history
    {
        public Nullable<int> session_id { get; set; }
        public int agent_id { get; set; }
        public string comments { get; set; }
        public int error_id { get; set; }
        public byte[] timestamp { get; set; }
        public bool updateable_row { get; set; }
        public System.DateTime time { get; set; }
    }
}
