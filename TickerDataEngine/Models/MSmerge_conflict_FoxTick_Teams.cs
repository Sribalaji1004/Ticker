using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_conflict_FoxTick_Teams
    {
        public int ID { get; set; }
        public int StatsIncID { get; set; }
        public int SportID { get; set; }
        public string Abbreviation { get; set; }
        public string CityName { get; set; }
        public string NickName { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public Nullable<int> Ranking { get; set; }
        public Nullable<int> Wins { get; set; }
        public Nullable<int> Loss { get; set; }
        public Nullable<int> Tie { get; set; }
        public System.Guid rowguid { get; set; }
        public Nullable<System.Guid> origin_datasource_id { get; set; }
    }
}
