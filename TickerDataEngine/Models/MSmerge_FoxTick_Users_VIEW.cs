using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_FoxTick_Users_VIEW
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ClientID { get; set; }
        public Nullable<bool> Admin { get; set; }
        public System.Guid rowguid { get; set; }
    }
}
