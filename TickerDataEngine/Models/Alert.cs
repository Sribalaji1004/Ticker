using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class Alert
    {
        public int ID { get; set; }
        public int GameID { get; set; }
        public int AlertID { get; set; }
        public System.DateTime AlertTimeStamp { get; set; }
        public string Alert1 { get; set; }
        public System.Guid rowguid { get; set; }
    }
}
