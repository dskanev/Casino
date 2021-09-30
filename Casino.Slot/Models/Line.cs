using Casino.Slot.Models.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.Slot.Models
{
    public class Line
    {
        public List<Symbol> Symbols { get; set; } = new List<Symbol>();
    }
}
