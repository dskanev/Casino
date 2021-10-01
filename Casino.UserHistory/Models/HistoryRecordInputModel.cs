using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.UserHistory.Models
{
    public class HistoryRecordInputModel
    {
        public string UserId { get; set; }
        public bool Won { get; set; }
        public double Winnings { get; set; }
        public double BetAmount { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
