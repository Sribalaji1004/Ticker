using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class sysmergeextendedarticlesview
    {
        public string name { get; set; }
        public Nullable<byte> type { get; set; }
        public int objid { get; set; }
        public Nullable<int> sync_objid { get; set; }
        public Nullable<byte> view_type { get; set; }
        public System.Guid artid { get; set; }
        public string description { get; set; }
        public Nullable<byte> pre_creation_command { get; set; }
        public System.Guid pubid { get; set; }
        public Nullable<int> nickname { get; set; }
        public Nullable<int> column_tracking { get; set; }
        public Nullable<byte> status { get; set; }
        public string conflict_table { get; set; }
        public string creation_script { get; set; }
        public string conflict_script { get; set; }
        public string article_resolver { get; set; }
        public string ins_conflict_proc { get; set; }
        public string insert_proc { get; set; }
        public string update_proc { get; set; }
        public string select_proc { get; set; }
        public byte[] schema_option { get; set; }
        public string destination_object { get; set; }
        public string resolver_clsid { get; set; }
        public string subset_filterclause { get; set; }
        public Nullable<int> missing_col_count { get; set; }
        public byte[] missing_cols { get; set; }
        public byte[] columns { get; set; }
        public string resolver_info { get; set; }
        public string view_sel_proc { get; set; }
        public Nullable<long> gen_cur { get; set; }
        public byte[] excluded_cols { get; set; }
        public Nullable<int> excluded_col_count { get; set; }
        public Nullable<int> vertical_partition { get; set; }
        public Nullable<int> identity_support { get; set; }
        public string destination_owner { get; set; }
        public Nullable<int> before_image_objid { get; set; }
        public Nullable<int> before_view_objid { get; set; }
        public Nullable<int> verify_resolver_signature { get; set; }
        public int allow_interactive_resolver { get; set; }
        public int fast_multicol_updateproc { get; set; }
        public int check_permissions { get; set; }
        public Nullable<int> maxversion_at_cleanup { get; set; }
        public int processing_order { get; set; }
        public int published_in_tran_pub { get; set; }
        public int upload_options { get; set; }
        public int lightweight { get; set; }
        public string delete_proc { get; set; }
        public Nullable<int> before_upd_view_objid { get; set; }
        public Nullable<int> delete_tracking { get; set; }
        public int compensate_for_errors { get; set; }
        public Nullable<long> pub_range { get; set; }
        public Nullable<long> range { get; set; }
        public Nullable<int> threshold { get; set; }
        public string metadata_select_proc { get; set; }
        public int stream_blob_columns { get; set; }
        public int preserve_rowguidcol { get; set; }
    }
}
