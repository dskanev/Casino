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
        /// <summary>
        /// Contains the logic related to calculating the winnings of the spin.
        /// </summary>
        /// <param name="betSize">The bet amount for the spin</param>
        /// <returns></returns>
        Spin GetSpinResult(long betSize);
        /// <summary>
        /// Calculates and outputs the relative probability of all symbols in %.
        /// </summary>
        /// <returns></returns>
        Dictionary<string, double> GetSymbolsProbability();
        /// <summary>
        /// Contains the logic related to spinning the slot and linking
        /// the result to the user through sending a message via the message broker.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="betSize"></param>
        /// <returns></returns>
        Task<Result<Spin>> SpinTheSlot (string userId, long betSize);
    }
}
