using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class sysmergepartitioninfo
    {
        public System.Guid artid { get; set; }
        public System.Guid pubid { get; set; }
        public Nullable<int> partition_view_id { get; set; }
        public Nullable<int> repl_view_id { get; set; }
        public string partition_deleted_view_rule { get; set; }
        public string partition_inserted_view_rule { get; set; }
        public string membership_eval_proc_name { get; set; }
        public string column_list { get; set; }
        public string column_list_blob { get; set; }
        public string expand_proc { get; set; }
        public Nullable<int> logical_record_parent_nickname { get; set; }
        public Nullable<int> logical_record_view { get; set; }
        public string logical_record_deleted_view_rule { get; set; }
        public Nullable<bool> logical_record_level_conflict_detection { get; set; }
        public Nullable<bool> logical_record_level_conflict_resolution { get; set; }
        public Nullable<byte> partition_options { get; set; }
    }
}
