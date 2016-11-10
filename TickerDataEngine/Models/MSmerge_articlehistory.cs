using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_articlehistory
    {
        public int session_id { get; set; }
        public Nullable<int> phase_id { get; set; }
        public string article_name { get; set; }
        public System.DateTime start_time { get; set; }
        public Nullable<int> duration { get; set; }
        public int inserts { get; set; }
        public int updates { get; set; }
        public int deletes { get; set; }
        public int conflicts { get; set; }
        public int rows_retried { get; set; }
        public decimal percent_complete { get; set; }
        public Nullable<int> estimated_changes { get; set; }
        public decimal relative_cost { get; set; }
    }
}
