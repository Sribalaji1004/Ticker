using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_generation_partition_mappings
    {
        public short publication_number { get; set; }
        public long generation { get; set; }
        public int partition_id { get; set; }
        public int changecount { get; set; }
    }
}
