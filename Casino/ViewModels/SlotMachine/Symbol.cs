using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.ViewModels.SlotMachine
{
    public class Symbol
    {
        public string Name { get; set; }
        public double Coefficient { get; set; }
        public double Rarity { get; set; }
        public string ImageURL { get; set; }
    }
}
