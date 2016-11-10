using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class sysmergeschemaarticle
    {
        public string name { get; set; }
        public Nullable<byte> type { get; set; }
        public int objid { get; set; }
        public System.Guid artid { get; set; }
        public string description { get; set; }
        public Nullable<byte> pre_creation_command { get; set; }
        public System.Guid pubid { get; set; }
        public Nullable<byte> status { get; set; }
        public string creation_script { get; set; }
        public byte[] schema_option { get; set; }
        public string destination_object { get; set; }
        public string destination_owner { get; set; }
        public int processing_order { get; set; }
    }
}
