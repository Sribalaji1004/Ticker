using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class ImporterLog
    {
        public long ID { get; set; }
        public int ImporterID { get; set; }
        public string EntryType { get; set; }
        public string Entry { get; set; }
        public System.DateTime EntryDate { get; set; }
        public System.Guid rowguid { get; set; }
    }
}
