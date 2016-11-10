using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class Status
    {
        public int ID { get; set; }
        public int SportID { get; set; }
        public string Description { get; set; }
        public System.Guid rowguid { get; set; }
    }
}
