using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_FoxTick_sysdiagrams_VIEW
    {
        public string name { get; set; }
        public int principal_id { get; set; }
        public int diagram_id { get; set; }
        public Nullable<int> version { get; set; }
        public byte[] definition { get; set; }
        public System.Guid rowguid { get; set; }
    }
}
