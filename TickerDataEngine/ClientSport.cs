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
    
    public partial class ClientSport
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public int SportID { get; set; }
        public string AltShortDisplay { get; set; }
        public string AltLongDisplay { get; set; }
    
        public virtual Sport Sport { get; set; }
    }
}
