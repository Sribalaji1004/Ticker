using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_FoxTick_ClientGames_VIEW
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public int GameID { get; set; }
        public int AltSortOrder { get; set; }
        public System.Guid rowguid { get; set; }
    }
}
