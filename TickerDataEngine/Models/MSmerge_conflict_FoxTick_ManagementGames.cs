using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_conflict_FoxTick_ManagementGames
    {
        public int GameID { get; set; }
        public Nullable<byte> GameStatusID { get; set; }
        public Nullable<int> StatusID { get; set; }
        public string Clock { get; set; }
        public string Details { get; set; }
        public Nullable<int> HomeScore { get; set; }
        public Nullable<int> VisitorsScore { get; set; }
        public System.Guid rowguid { get; set; }
        public Nullable<System.Guid> origin_datasource_id { get; set; }
    }
}
