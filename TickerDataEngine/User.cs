//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ticker.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Inactive = false;
            this.auth_admin_log = new HashSet<auth_admin_log>();
        }
    
        public int UserID { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ClientID { get; set; }
        public Nullable<bool> Admin { get; set; }
        public Nullable<bool> Inactive { get; set; }
        public int SecurityLevelID { get; set; }
    
        public virtual ICollection<auth_admin_log> auth_admin_log { get; set; }
    }
}
