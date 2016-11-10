using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_conflict_FoxTick_Notes
    {
        public int ID { get; set; }
        public int GroupID { get; set; }
        public string Note { get; set; }
        public string NoteColor { get; set; }
        public Nullable<int> TeamID { get; set; }
        public string Header { get; set; }
        public Nullable<int> SortOrder { get; set; }
        public Nullable<bool> Imported { get; set; }
        public System.DateTime LastUpdated { get; set; }
        public Nullable<int> UserID { get; set; }
        public System.Guid rowguid { get; set; }
        public Nullable<System.Guid> origin_datasource_id { get; set; }
    }
}
