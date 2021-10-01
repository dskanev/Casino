using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.ViewModels.SlotMachine
{
    public class SymbolProbabilityOutputModel
    {
        public List<SymbolProbability> Symbols { get; set; }
    }

    public class SymbolProbability
    {
        public string Name { get; set; }
        public double Probability { get; set; }
    }
}
