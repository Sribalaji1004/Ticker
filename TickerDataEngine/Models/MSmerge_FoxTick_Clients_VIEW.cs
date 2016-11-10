using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_FoxTick_Clients_VIEW
    {
        public byte ID { get; set; }
        public string Abbreviation { get; set; }
        public string Description { get; set; }
        public Nullable<bool> LockClient { get; set; }
        public string SponsorSync { get; set; }
        public System.Guid rowguid { get; set; }
    }
}
