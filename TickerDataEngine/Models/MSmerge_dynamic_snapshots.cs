using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_dynamic_snapshots
    {
        public int partition_id { get; set; }
        public string dynamic_snapshot_location { get; set; }
        public Nullable<System.DateTime> last_updated { get; set; }
        public Nullable<System.DateTime> last_started { get; set; }
        public virtual MSmerge_partition_groups MSmerge_partition_groups { get; set; }
    }
}
