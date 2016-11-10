using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class User
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
