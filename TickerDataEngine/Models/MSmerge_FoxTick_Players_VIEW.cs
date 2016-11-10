using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_FoxTick_Players_VIEW
    {
        public int ID { get; set; }
        public int StatsIncID { get; set; }
        public int TeamID { get; set; }
        public int StatsIncTeamID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public System.Guid rowguid { get; set; }
    }
}
