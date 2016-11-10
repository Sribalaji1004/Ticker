using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_FoxTick_Banners_VIEW
    {
        public int ID { get; set; }
        public Nullable<int> ClientID { get; set; }
        public string Banner { get; set; }
        public Nullable<int> SortOrder { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
        public System.Guid rowguid { get; set; }
    }
}
