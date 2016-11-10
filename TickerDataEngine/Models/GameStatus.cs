using System;
using System.Collections.Generic;

namespace FOXTickerDataEngine.Models
{
    public class GameStatus
    {
        public byte ID { get; set; }
        public string Description { get; set; }
        public System.Guid rowguid { get; set; }
    }
}
