using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSrepl_errors
    {
        public int id { get; set; }
        public System.DateTime time { get; set; }
        public Nullable<int> error_type_id { get; set; }
        public Nullable<int> source_type_id { get; set; }
        public string source_name { get; set; }
        public string error_code { get; set; }
        public string error_text { get; set; }
        public byte[] xact_seqno { get; set; }
        public Nullable<int> command_id { get; set; }
        public Nullable<int> session_id { get; set; }
    }
}
