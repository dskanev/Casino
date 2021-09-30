using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.Slot.Models.Symbols
{
    public class Symbol
    {
        public string Name { get; set; }
        public double Coefficient { get; set; }
        public double Rarity { get; set; }
    }
}
