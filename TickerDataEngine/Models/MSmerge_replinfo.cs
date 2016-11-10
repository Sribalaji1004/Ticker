using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_replinfo
    {
        public System.Guid repid { get; set; }
        public bool use_interactive_resolver { get; set; }
        public int validation_level { get; set; }
        public long resync_gen { get; set; }
        public string login_name { get; set; }
        public string hostname { get; set; }
        public byte[] merge_jobid { get; set; }
        public int sync_info { get; set; }
    }
}
