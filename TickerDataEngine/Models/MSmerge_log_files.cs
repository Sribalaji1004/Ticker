using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_log_files
    {
        public int id { get; set; }
        public Nullable<System.Guid> pubid { get; set; }
        public Nullable<System.Guid> subid { get; set; }
        public string web_server { get; set; }
        public string file_name { get; set; }
        public System.DateTime upload_time { get; set; }
        public int log_file_type { get; set; }
        public byte[] log_file { get; set; }
    }
}
