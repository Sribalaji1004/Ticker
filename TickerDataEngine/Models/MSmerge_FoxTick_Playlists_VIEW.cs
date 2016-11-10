using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_FoxTick_Playlists_VIEW
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
        public Nullable<bool> Locked { get; set; }
        public Nullable<bool> Staged { get; set; }
        public System.Guid rowguid { get; set; }
    }
}
