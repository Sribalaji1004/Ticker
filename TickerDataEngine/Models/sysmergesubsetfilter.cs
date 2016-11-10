using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class sysmergesubsetfilter
    {
        public string filtername { get; set; }
        public int join_filterid { get; set; }
        public System.Guid pubid { get; set; }
        public System.Guid artid { get; set; }
        public int art_nickname { get; set; }
        public string join_articlename { get; set; }
        public int join_nickname { get; set; }
        public int join_unique_key { get; set; }
        public string expand_proc { get; set; }
        public string join_filterclause { get; set; }
        public byte filter_type { get; set; }
    }
}
