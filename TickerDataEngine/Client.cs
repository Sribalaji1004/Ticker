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
    
    public partial class Client
    {
        public Client()
        {
            this.BreakingNews = new HashSet<BreakingNew>();
            this.ClientsTo = new HashSet<Client>();
            this.Clients = new HashSet<Client>();
        }
    
        public byte ID { get; set; }
        public string Abbreviation { get; set; }
        public string Description { get; set; }
        public Nullable<bool> LockClient { get; set; }
        public string SponsorSync { get; set; }
        public bool DataHiveEnabled { get; set; }
    
        public virtual ICollection<BreakingNew> BreakingNews { get; set; }
        public virtual ICollection<Client> ClientsTo { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}