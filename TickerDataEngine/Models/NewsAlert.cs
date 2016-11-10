using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class NewsAlert
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public string OnAirName { get; set; }
        public string Header { get; set; }
        public string Alert { get; set; }
        public Nullable<System.DateTime> AlertDate { get; set; }
        public Nullable<int> PlayCount { get; set; }
        public bool Active { get; set; }
        public string CreatedIP { get; set; }
        public System.Guid rowguid { get; set; }
    }
}
