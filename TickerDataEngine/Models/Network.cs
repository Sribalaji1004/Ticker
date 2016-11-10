using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class Network
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public string Display { get; set; }
        public string Description { get; set; }
        public System.Guid rowguid { get; set; }
    }
}
