using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_errorlineage
    {
        public int tablenick { get; set; }
        public System.Guid rowguid { get; set; }
        public byte[] lineage { get; set; }
    }
}
