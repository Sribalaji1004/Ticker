using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_FoxTick_Groups_VIEW
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string OnAirName { get; set; }
        public string CreatedName { get; set; }
        public string Type { get; set; }
        public Nullable<int> TeamID { get; set; }
        public string Header { get; set; }
        public int GroupAnimationTypeID { get; set; }
        public Nullable<bool> Editable { get; set; }
        public System.DateTime LastUpdated { get; set; }
        public System.Guid rowguid { get; set; }
    }
}
