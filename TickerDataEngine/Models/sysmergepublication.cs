using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class sysmergepublication
    {
        public string publisher { get; set; }
        public string publisher_db { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Nullable<int> retention { get; set; }
        public Nullable<byte> publication_type { get; set; }
        public System.Guid pubid { get; set; }
        public Nullable<System.Guid> designmasterid { get; set; }
        public Nullable<System.Guid> parentid { get; set; }
        public Nullable<byte> sync_mode { get; set; }
        public Nullable<int> allow_push { get; set; }
        public Nullable<int> allow_pull { get; set; }
        public Nullable<int> allow_anonymous { get; set; }
        public Nullable<int> centralized_conflicts { get; set; }
        public Nullable<byte> status { get; set; }
        public Nullable<byte> snapshot_ready { get; set; }
        public bool enabled_for_internet { get; set; }
        public bool dynamic_filters { get; set; }
        public bool snapshot_in_defaultfolder { get; set; }
        public string alt_snapshot_folder { get; set; }
        public string pre_snapshot_script { get; set; }
        public string post_snapshot_script { get; set; }
        public bool compress_snapshot { get; set; }
        public string ftp_address { get; set; }
        public int ftp_port { get; set; }
        public string ftp_subdirectory { get; set; }
        public string ftp_login { get; set; }
        public string ftp_password { get; set; }
        public Nullable<int> conflict_retention { get; set; }
        public Nullable<int> keep_before_values { get; set; }
        public Nullable<bool> allow_subscription_copy { get; set; }
        public Nullable<bool> allow_synctoalternate { get; set; }
        public string validate_subscriber_info { get; set; }
        public string ad_guidname { get; set; }
        public int backward_comp_level { get; set; }
        public int max_concurrent_merge { get; set; }
        public int max_concurrent_dynamic_snapshots { get; set; }
        public Nullable<short> use_partition_groups { get; set; }
        public string dynamic_filters_function_list { get; set; }
        public string partition_id_eval_proc { get; set; }
        public short publication_number { get; set; }
        public int replicate_ddl { get; set; }
        public bool allow_subscriber_initiated_snapshot { get; set; }
        public string distributor { get; set; }
        public byte[] snapshot_jobid { get; set; }
        public Nullable<bool> allow_web_synchronization { get; set; }
        public string web_synchronization_url { get; set; }
        public Nullable<bool> allow_partition_realignment { get; set; }
        public byte retention_period_unit { get; set; }
        public Nullable<int> decentralized_conflicts { get; set; }
        public Nullable<int> generation_leveling_threshold { get; set; }
        public bool automatic_reinitialization_policy { get; set; }
    }
}
