using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class ClientAlert
    {
        public int ClientID { get; set; }
        public int GameID { get; set; }
        public string ClientIP { get; set; }
        public System.Guid rowguid { get; set; }
    }
}
