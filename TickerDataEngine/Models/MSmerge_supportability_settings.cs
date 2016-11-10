using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_supportability_settings
    {
        public Nullable<System.Guid> pubid { get; set; }
        public Nullable<System.Guid> subid { get; set; }
        public string web_server { get; set; }
        public int support_options { get; set; }
        public int log_severity { get; set; }
        public int log_modules { get; set; }
        public string log_file_path { get; set; }
        public string log_file_name { get; set; }
        public int log_file_size { get; set; }
        public int no_of_log_files { get; set; }
        public int upload_interval { get; set; }
        public int delete_after_upload { get; set; }
        public string custom_script { get; set; }
        public string message_pattern { get; set; }
        public Nullable<System.DateTime> last_log_upload_time { get; set; }
        public byte[] agent_xe { get; set; }
        public byte[] agent_xe_ring_buffer { get; set; }
        public byte[] sql_xe { get; set; }
    }
}
