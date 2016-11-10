using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_FoxTick_ClientNetworks_VIEW
    {
        public int ID { get; set; }
        public int GameID { get; set; }
        public int NetworkID { get; set; }
        public System.Guid rowguid { get; set; }
    }
}
