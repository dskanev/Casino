using Casino.Common.Services;
using Casino.Slot.Models;
using Casino.Slot.Models.Symbols;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Casino.Slot.Services
{
    public interface ISlotMachineService
    {
        Line GetLineOfSymbols(int sizeOfLine);
        Spin GetSpinResult(long betSize);
        Dictionary<string, double> GetSymbolsProbability();
        Task<Result<Spin>> SpinTheSlot (string userId, long betSize);
    }
}
