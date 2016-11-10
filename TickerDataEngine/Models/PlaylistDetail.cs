using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class PlaylistDetail
    {
        public int ID { get; set; }
        public int PlaylistID { get; set; }
        public byte EntryTypeID { get; set; }
        public int EntryID { get; set; }
        public Nullable<int> SortOrder { get; set; }
        public string OnAirName { get; set; }
        public System.Guid rowguid { get; set; }
    }
}
