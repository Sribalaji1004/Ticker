using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_conflict_FoxTick_ClientSports
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public int SportID { get; set; }
        public string AltShortDisplay { get; set; }
        public string AltLongDisplay { get; set; }
        public System.Guid rowguid { get; set; }
        public Nullable<System.Guid> origin_datasource_id { get; set; }
    }
}
