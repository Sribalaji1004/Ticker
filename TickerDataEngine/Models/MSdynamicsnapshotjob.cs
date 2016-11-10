using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSdynamicsnapshotjob
    {
        public int id { get; set; }
        public string name { get; set; }
        public System.Guid pubid { get; set; }
        public System.Guid job_id { get; set; }
        public int agent_id { get; set; }
        public string dynamic_filter_login { get; set; }
        public string dynamic_filter_hostname { get; set; }
        public string dynamic_snapshot_location { get; set; }
        public int partition_id { get; set; }
        public bool computed_dynsnap_location { get; set; }
    }
}
