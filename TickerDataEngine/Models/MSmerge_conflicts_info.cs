using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_conflicts_info
    {
        public int tablenick { get; set; }
        public System.Guid rowguid { get; set; }
        public string origin_datasource { get; set; }
        public Nullable<int> conflict_type { get; set; }
        public Nullable<int> reason_code { get; set; }
        public string reason_text { get; set; }
        public Nullable<System.Guid> pubid { get; set; }
        public System.DateTime MSrepl_create_time { get; set; }
        public Nullable<System.Guid> origin_datasource_id { get; set; }
    }
}
