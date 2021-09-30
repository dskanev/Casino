using Casino.Slot.Models.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.Slot.Models
{
    public class Spin
    {
        public List<Line> Lines { get; set; } = new List<Line>();
        public bool IsWinning => Winnings != default;
        public double Winnings { get; set; }
    }
}
