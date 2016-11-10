using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_FoxTick_ManagementGames_VIEW
    {
        public int GameID { get; set; }
        public Nullable<byte> GameStatusID { get; set; }
        public Nullable<int> StatusID { get; set; }
        public string Clock { get; set; }
        public string Details { get; set; }
        public Nullable<int> HomeScore { get; set; }
        public Nullable<int> VisitorsScore { get; set; }
        public System.Guid rowguid { get; set; }
    }
}
