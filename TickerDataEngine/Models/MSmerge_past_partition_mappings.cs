using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_past_partition_mappings
    {
        public short publication_number { get; set; }
        public int tablenick { get; set; }
        public System.Guid rowguid { get; set; }
        public int partition_id { get; set; }
        public Nullable<long> generation { get; set; }
        public byte reason { get; set; }
    }
}
