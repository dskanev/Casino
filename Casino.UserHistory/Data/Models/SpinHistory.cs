using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.UserHistory.Data.Models
{
    public class SpinHistory
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public double StartingBalance { get; set; }
        public double EndBalance { get; set; }
        public bool Won { get; set; }
        public double BetAmmount { get; set; }
        public double Winnings { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
