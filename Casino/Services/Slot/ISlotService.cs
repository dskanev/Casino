using Casino.ViewModels.SlotMachine;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.Services.Slot
{
    public interface ISlotService
    {
        [Get("/Slot/SpinTheSlot/{betSize}")]
        Task<Spin> SpinTheSlot(double betSize);

        [Get("/Slot/GetSymbolsProbability")]
        Task<Dictionary<string, long>> GetSymbolsProbability();
    }
}
