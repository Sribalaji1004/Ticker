using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class Sport
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string ShortDisplay { get; set; }
        public string LongDisplay { get; set; }
        public string StatsIncName { get; set; }
        public Nullable<int> KeepResultsInDays { get; set; }
        public string SportType { get; set; }
        public string DisplayField { get; set; }
        public string GameFrequency { get; set; }
        public System.Guid rowguid { get; set; }
    }
}
