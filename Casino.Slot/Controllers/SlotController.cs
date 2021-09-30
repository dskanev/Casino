using Casino.Common.Controllers;
using Casino.Slot.Models;
using Casino.Slot.Models.Symbols;
using Casino.Slot.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.Slot.Controllers
{
    public class SlotController : ApiController
    {
        private readonly ISlotMachineService _slotMachineService;

        public SlotController(ISlotMachineService slotMachineService)
        {
            _slotMachineService = slotMachineService;
        }

        [HttpGet]
        [Route(nameof(GetLine))]
        public Line GetLine(int sizeOfLine)
        {
            return _slotMachineService.GetLineOfSymbols(sizeOfLine);
        }

        [HttpGet]
        [Route(nameof(GetSpinResult))]
        public Spin GetSpinResult(long betSize)
        {
            return _slotMachineService.GetSpinResult(betSize);
        }

        [HttpGet]
        [Route(nameof(GetSymbolsProbability))]
        public Dictionary<string, double> GetSymbolsProbability()
        {
            return _slotMachineService.GetSymbolsProbability();
        }
    }
}
