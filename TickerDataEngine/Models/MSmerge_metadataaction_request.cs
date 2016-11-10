using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_metadataaction_request
    {
        public int tablenick { get; set; }
        public System.Guid rowguid { get; set; }
        public byte action { get; set; }
        public Nullable<long> generation { get; set; }
        public Nullable<int> changed { get; set; }
    }
}
