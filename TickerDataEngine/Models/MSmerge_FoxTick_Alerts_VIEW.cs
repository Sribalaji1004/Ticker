using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_FoxTick_Alerts_VIEW
    {
        public int ID { get; set; }
        public int GameID { get; set; }
        public int AlertID { get; set; }
        public System.DateTime AlertTimeStamp { get; set; }
        public string Alert { get; set; }
        public System.Guid rowguid { get; set; }
    }
}
