using Casino.Slot.Models;
using Casino.Slot.Models.Symbols;
using System.Collections.Generic;

namespace Casino.Slot.Services
{
    public interface ISlotMachineService
    {
        Line GetLineOfSymbols(int sizeOfLine);
        Spin GetSpinResult(long betSize);
        Dictionary<string, double> GetSymbolsProbability();
    }
}
