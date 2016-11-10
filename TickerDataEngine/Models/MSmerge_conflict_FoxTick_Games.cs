using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_conflict_FoxTick_Games
    {
        public int ID { get; set; }
        public int SportID { get; set; }
        public long StatsIncID { get; set; }
        public int VisitorsID { get; set; }
        public int HomeID { get; set; }
        public int VisitorsScore { get; set; }
        public int HomeScore { get; set; }
        public byte GameStatusID { get; set; }
        public int StatusID { get; set; }
        public string Clock { get; set; }
        public Nullable<System.DateTime> GameDateTime { get; set; }
        public bool BoxScore { get; set; }
        public string Details { get; set; }
        public Nullable<byte> ScoreAlertID { get; set; }
        public Nullable<int> LastVisitorsScore { get; set; }
        public Nullable<int> LastHomeScore { get; set; }
        public string DetailsPreScore { get; set; }
        public string DetailsPostScore { get; set; }
        public Nullable<int> StatusIDPreScore { get; set; }
        public Nullable<int> TeamID { get; set; }
        public string Header { get; set; }
        public System.DateTime LastUpdated { get; set; }
        public string ScoreDescription { get; set; }
        public Nullable<int> SortOrder { get; set; }
        public bool BlockData { get; set; }
        public Nullable<System.DateTime> ScoreLastUpdated { get; set; }
        public System.Guid rowguid { get; set; }
        public Nullable<System.Guid> origin_datasource_id { get; set; }
    }
}
