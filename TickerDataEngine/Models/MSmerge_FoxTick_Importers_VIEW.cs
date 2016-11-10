using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class MSmerge_FoxTick_Importers_VIEW
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string RunDay { get; set; }
        public int RunHour { get; set; }
        public int RunMinute { get; set; }
        public bool Force { get; set; }
        public System.DateTime LastRun { get; set; }
        public string LastFileDate { get; set; }
        public bool LastSuccess { get; set; }
        public string LastMessage { get; set; }
        public System.Guid rowguid { get; set; }
    }
}
