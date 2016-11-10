using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_FoxTick_ClientStatuses_VIEW
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public int StatusID { get; set; }
        public string AltDescription { get; set; }
        public System.Guid rowguid { get; set; }
    }
}
