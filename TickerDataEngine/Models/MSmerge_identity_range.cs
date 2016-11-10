using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_identity_range
    {
        public System.Guid subid { get; set; }
        public System.Guid artid { get; set; }
        public Nullable<decimal> range_begin { get; set; }
        public Nullable<decimal> range_end { get; set; }
        public Nullable<decimal> next_range_begin { get; set; }
        public Nullable<decimal> next_range_end { get; set; }
        public bool is_pub_range { get; set; }
        public Nullable<decimal> max_used { get; set; }
    }
}
