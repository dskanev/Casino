using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.Slot.Models
{
    public class SpinResult
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public double BetSize { get; set; }
        public double Winnings { get; set; }
    }
}
