using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_conflict_FoxTick_NFLGameNotes
    {
        public string Type { get; set; }
        public int GameID { get; set; }
        public int PlayerID { get; set; }
        public string Note { get; set; }
        public System.Guid rowguid { get; set; }
        public Nullable<System.Guid> origin_datasource_id { get; set; }
    }
}
