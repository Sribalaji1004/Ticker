using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_sessions
    {
        public Nullable<System.Guid> subid { get; set; }
        public int session_id { get; set; }
        public int agent_id { get; set; }
        public Nullable<System.DateTime> start_time { get; set; }
        public Nullable<System.DateTime> end_time { get; set; }
        public Nullable<int> duration { get; set; }
        public int delivery_time { get; set; }
        public int upload_time { get; set; }
        public int download_time { get; set; }
        public int schema_change_time { get; set; }
        public int prepare_snapshot_time { get; set; }
        public decimal delivery_rate { get; set; }
        public int time_remaining { get; set; }
        public decimal percent_complete { get; set; }
        public Nullable<int> upload_inserts { get; set; }
        public Nullable<int> upload_updates { get; set; }
        public Nullable<int> upload_deletes { get; set; }
        public Nullable<int> upload_conflicts { get; set; }
        public Nullable<int> upload_rows_retried { get; set; }
        public Nullable<int> download_inserts { get; set; }
        public Nullable<int> download_updates { get; set; }
        public Nullable<int> download_deletes { get; set; }
        public Nullable<int> download_conflicts { get; set; }
        public Nullable<int> download_rows_retried { get; set; }
        public Nullable<int> schema_changes { get; set; }
        public Nullable<int> bulk_inserts { get; set; }
        public Nullable<int> metadata_rows_cleanedup { get; set; }
        public int runstatus { get; set; }
        public Nullable<int> estimated_upload_changes { get; set; }
        public Nullable<int> estimated_download_changes { get; set; }
        public Nullable<int> connection_type { get; set; }
        public byte[] timestamp { get; set; }
        public Nullable<int> current_phase_id { get; set; }
        public Nullable<short> spid { get; set; }
        public Nullable<System.DateTime> spid_login_time { get; set; }
    }
}
