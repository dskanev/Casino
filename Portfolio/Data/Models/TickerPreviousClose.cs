using Casino.Common.Data.Models;
using Portfolio.Models.Ticker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Data.Models
{
    public class TickerPreviousClose : DatabaseModel
    {
        public string Ticker { get; set; }
        public double Close { get; set; }
        public double Highest { get; set; }
        public double Lowest { get; set; }
        public double Open { get; set; }
        public double Volume { get; set; }
        public double VolumeWeightedAveragePrice { get; set; }
        public long Timestamp { get; set; }
    }
}
