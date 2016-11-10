using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class sysmergeschemachange
    {
        public System.Guid pubid { get; set; }
        public Nullable<System.Guid> artid { get; set; }
        public int schemaversion { get; set; }
        public System.Guid schemaguid { get; set; }
        public int schematype { get; set; }
        public string schematext { get; set; }
        public byte schemastatus { get; set; }
        public int schemasubtype { get; set; }
    }
}
