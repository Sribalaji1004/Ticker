using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_genhistory
    {
        public System.Guid guidsrc { get; set; }
        public Nullable<System.Guid> pubid { get; set; }
        public long generation { get; set; }
        public Nullable<int> art_nick { get; set; }
        public byte[] nicknames { get; set; }
        public System.DateTime coldate { get; set; }
        public byte genstatus { get; set; }
        public int changecount { get; set; }
        public int subscriber_number { get; set; }
    }
}
