using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class GameStat
    {
        public int ID { get; set; }
        public int GameID { get; set; }
        public int PlayerID { get; set; }
        public string StatName { get; set; }
        public string StatValue { get; set; }
        public System.DateTime LastUpdated { get; set; }
        public System.Guid rowguid { get; set; }
    }
}
