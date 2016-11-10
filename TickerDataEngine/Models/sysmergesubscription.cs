using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class sysmergesubscription
    {
        public string subscriber_server { get; set; }
        public string db_name { get; set; }
        public Nullable<System.Guid> pubid { get; set; }
        public int datasource_type { get; set; }
        public System.Guid subid { get; set; }
        public byte[] replnickname { get; set; }
        public System.Guid replicastate { get; set; }
        public byte status { get; set; }
        public int subscriber_type { get; set; }
        public int subscription_type { get; set; }
        public byte sync_type { get; set; }
        public string description { get; set; }
        public Nullable<float> priority { get; set; }
        public Nullable<long> recgen { get; set; }
        public Nullable<System.Guid> recguid { get; set; }
        public Nullable<long> sentgen { get; set; }
        public Nullable<System.Guid> sentguid { get; set; }
        public Nullable<int> schemaversion { get; set; }
        public Nullable<System.Guid> schemaguid { get; set; }
        public Nullable<System.DateTime> last_validated { get; set; }
        public Nullable<System.DateTime> attempted_validate { get; set; }
        public Nullable<System.DateTime> last_sync_date { get; set; }
        public Nullable<int> last_sync_status { get; set; }
        public string last_sync_summary { get; set; }
        public System.DateTime metadatacleanuptime { get; set; }
        public Nullable<int> partition_id { get; set; }
        public bool cleanedup_unsent_changes { get; set; }
        public int replica_version { get; set; }
        public int supportability_mode { get; set; }
        public string application_name { get; set; }
        public int subscriber_number { get; set; }
        public Nullable<System.DateTime> last_makegeneration_datetime { get; set; }
    }
}
