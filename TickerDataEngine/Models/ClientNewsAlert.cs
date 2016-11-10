using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class ClientNewsAlert
    {
        public int AlertID { get; set; }
        public string ClientIP { get; set; }
        public int OnAirCount { get; set; }
        public System.Guid rowguid { get; set; }
    }
}
