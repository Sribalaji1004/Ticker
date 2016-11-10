using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_partition_groups
    {
        public int partition_id { get; set; }
        public short publication_number { get; set; }
        public Nullable<long> maxgen_whenadded { get; set; }
        public Nullable<bool> using_partition_groups { get; set; }
        public bool is_partition_active { get; set; }
        public virtual MSmerge_dynamic_snapshots MSmerge_dynamic_snapshots { get; set; }
    }
}
