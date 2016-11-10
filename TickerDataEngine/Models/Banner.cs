using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class Banner
    {
        public int ID { get; set; }
        public Nullable<int> ClientID { get; set; }
        public string Banner1 { get; set; }
        public Nullable<int> SortOrder { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
        public System.Guid rowguid { get; set; }
    }
}
