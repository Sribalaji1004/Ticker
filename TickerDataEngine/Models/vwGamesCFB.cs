using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class vwGamesCFB
    {
        public int ID { get; set; }
        public string Matchup { get; set; }
        public int VisitorsID { get; set; }
        public int HomeID { get; set; }
        public Nullable<int> VisitorsRanking { get; set; }
        public Nullable<int> HomeRanking { get; set; }
        public string VisitorsAbbreviation { get; set; }
        public string HomeAbbreviation { get; set; }
        public string VisitorsCityName { get; set; }
        public string HomeCityName { get; set; }
        public string VisitorsNickName { get; set; }
        public string HomeNickName { get; set; }
        public string VisitorsCity { get; set; }
        public string HomeCity { get; set; }
        public int VisitorsScore { get; set; }
        public int HomeScore { get; set; }
        public string Clock { get; set; }
        public Nullable<int> GameStatusID { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> GameDateTime { get; set; }
        public System.DateTime LastUpdated { get; set; }
        public string Details { get; set; }
        public int VisitorWins { get; set; }
        public int VisitorLoss { get; set; }
        public int VisitorTie { get; set; }
        public int HomeWins { get; set; }
        public int HomeLoss { get; set; }
        public int HomeTie { get; set; }
    }
}
