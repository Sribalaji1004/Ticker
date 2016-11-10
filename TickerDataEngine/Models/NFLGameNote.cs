using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class NFLGameNote
    {
        public string Type { get; set; }
        public int GameID { get; set; }
        public int PlayerID { get; set; }
        public string Note { get; set; }
        public System.Guid rowguid { get; set; }
    }
}
