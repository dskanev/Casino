using Casino.Common.Controllers;
using Casino.Common.Services.Identity;
using Casino.Slot.Models;
using Casino.Slot.Models.Symbols;
using Casino.Slot.Services;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ICurrentUserService _currentUserService;

        public SlotController(ISlotMachineService slotMachineService,
            ICurrentUserService currentUserService)
        {
            _slotMachineService = slotMachineService;
            _currentUserService = currentUserService;
        }
        
        [HttpGet]
        [Route(nameof(GetLine))]
        public Line GetLine(int sizeOfLine)
        {
            return _slotMachineService.GetLineOfSymbols(sizeOfLine);
        }

        [Authorize]
        [HttpGet]
        [Route("SpinTheSlot/{betSize}")]
        public async Task<ActionResult<Spin>> SpinTheSlot(long betSize)
        {
            var userId = _currentUserService.UserId;
            var result = await _slotMachineService.SpinTheSlot(userId, betSize);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result.Data);
        }

        [Authorize]
        [HttpGet]
        [Route(nameof(GetSymbolsProbability))]
        public Dictionary<string, double> GetSymbolsProbability()
        {
            return _slotMachineService.GetSymbolsProbability();
        }
    }
}
