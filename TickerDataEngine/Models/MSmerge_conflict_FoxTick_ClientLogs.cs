using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_conflict_FoxTick_ClientLogs
    {
        public long ID { get; set; }
        public int ClientID { get; set; }
        public string Client { get; set; }
        public string EntryType { get; set; }
        public string Entry { get; set; }
        public string Temperature { get; set; }
        public System.DateTime EntryDate { get; set; }
        public System.Guid rowguid { get; set; }
        public Nullable<System.Guid> origin_datasource_id { get; set; }
    }
}
