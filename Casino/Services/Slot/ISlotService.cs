using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.Services.Slot
{
    public interface ISlotService
    {
        [Get("/Slot/GetSpinResult/{betSize}")]
        Task<int> GetSpinResult(long betSize);

        [Get("/Slot/GetSymbolsProbability")]
        Task<Dictionary<string, long>> GetSymbolsProbability();
    }
}
