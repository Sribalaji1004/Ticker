using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_conflict_FoxTick_ClientTeams
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public int TeamID { get; set; }
        public string AltAbbreviation { get; set; }
        public string AltCityName { get; set; }
        public string AltNickName { get; set; }
        public string AltPrimaryColor { get; set; }
        public string AltSecondaryColor { get; set; }
        public Nullable<int> AltRanking { get; set; }
        public System.Guid rowguid { get; set; }
        public Nullable<System.Guid> origin_datasource_id { get; set; }
    }
}
