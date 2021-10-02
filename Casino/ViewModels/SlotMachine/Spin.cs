using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.ViewModels.SlotMachine
{
    public class Spin
    {
        public List<Line> Lines { get; set; } = new List<Line>();
        public bool IsWinning => Winnings != default;
        public double Winnings { get; set; }
    }
}
