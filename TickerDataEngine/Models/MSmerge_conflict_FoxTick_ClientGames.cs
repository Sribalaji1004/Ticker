using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_conflict_FoxTick_ClientGames
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public int GameID { get; set; }
        public int AltSortOrder { get; set; }
        public System.Guid rowguid { get; set; }
        public Nullable<System.Guid> origin_datasource_id { get; set; }
    }
}
