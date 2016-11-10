using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_conflict_FoxTick_Alerts
    {
        public int ID { get; set; }
        public int GameID { get; set; }
        public int AlertID { get; set; }
        public System.DateTime AlertTimeStamp { get; set; }
        public string Alert { get; set; }
        public System.Guid rowguid { get; set; }
        public Nullable<System.Guid> origin_datasource_id { get; set; }
    }
}
