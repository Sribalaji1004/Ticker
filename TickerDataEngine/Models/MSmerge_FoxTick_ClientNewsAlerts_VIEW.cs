using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_FoxTick_ClientNewsAlerts_VIEW
    {
        public int AlertID { get; set; }
        public string ClientIP { get; set; }
        public int OnAirCount { get; set; }
        public System.Guid rowguid { get; set; }
    }
}
