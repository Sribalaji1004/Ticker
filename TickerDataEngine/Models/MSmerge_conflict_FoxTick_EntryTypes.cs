using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_conflict_FoxTick_EntryTypes
    {
        public byte ID { get; set; }
        public string Abbreviation { get; set; }
        public string Description { get; set; }
        public System.Guid rowguid { get; set; }
        public Nullable<System.Guid> origin_datasource_id { get; set; }
    }
}
