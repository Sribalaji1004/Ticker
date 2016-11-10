using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class vwNCAA_TeamTranslate
    {
        public int SRC_ID { get; set; }
        public string SRC_ABB { get; set; }
        public string SRC_NICKNAME { get; set; }
        public string SRC_PRIMARYCOLOR { get; set; }
        public int CPY_ID { get; set; }
        public string CPY_ABB { get; set; }
        public string CPY_NICKNAME { get; set; }
        public string CPY_PRIMARYCOLOR { get; set; }
    }
}
