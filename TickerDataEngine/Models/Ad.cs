using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class Ad
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public System.DateTime LastUpdated { get; set; }
        public System.Guid rowguid { get; set; }
    }
}
