using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class EntryType
    {
        public byte ID { get; set; }
        public string Abbreviation { get; set; }
        public string Description { get; set; }
        public System.Guid rowguid { get; set; }
    }
}
