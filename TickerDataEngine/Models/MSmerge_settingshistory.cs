using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_settingshistory
    {
        public Nullable<System.DateTime> eventtime { get; set; }
        public System.Guid pubid { get; set; }
        public Nullable<System.Guid> artid { get; set; }
        public byte eventtype { get; set; }
        public string propertyname { get; set; }
        public string previousvalue { get; set; }
        public string newvalue { get; set; }
        public string eventtext { get; set; }
    }
}
