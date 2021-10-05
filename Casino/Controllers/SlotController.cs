using AutoMapper;
using Casino.Common.Infrastructure;
using Casino.Common.Services.Identity;
using Casino.Services.Identity;
using Casino.Services.Slot;
using Casino.Services.UserHistory;
using Casino.ViewModels.SlotMachine;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.Controllers
{
    public class SlotController : Controller
    {
        private readonly IIdentityService _identityService;
        private readonly ISlotService _slotService;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserHistoryService _userHistoryService;

        public SlotController(
            IIdentityService identityService,
            ISlotService slotService,
            ICurrentUserService currentUserService,
            IMapper mapper,
            IUserHistoryService userHistory)
        {
            _identityService = identityService;
            _slotService = slotService;
            _currentUserService = currentUserService;
            _mapper = mapper;
            _userHistoryService = userHistory;
        }

        [Authorize]        
        public IActionResult SymbolList()
        {
            var symbols = _slotService
                .GetSymbolsProbability()
                .GetAwaiter()
                .GetResult()
                .Select(x => new SymbolProbability
                {
                    Name = x.Key,
                    Probability = x.Value
                })
                .ToList();

            return View(new SymbolProbabilityOutputModel { Symbols = symbols });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SpinTheSlot(double betSize, double? balanceUpdate = null)
        {
            var userId = _currentUserService.UserId;

            var userBalance = balanceUpdate != null ?
                (await _userHistoryService.UpdateBalance(userId, balanceUpdate.Value)).Balance :
                (await _userHistoryService.GetBalance(userId)).Balance;
                

            if (userBalance < betSize)
            {
                return View(new SpinResultOutputModel { ErrorMessage = $"Insufficient Balance! Current Balance: {userBalance.RoundUpToOneSymbol()}" });
            }

            var spinResult = await _slotService.SpinTheSlot(betSize);
            var newBalance = userBalance + spinResult.Winnings - betSize;

            return View(new SpinResultOutputModel {
                SpinResult = spinResult,
                NewBalance = newBalance
            });
        }

        [Authorize]
        public IActionResult SlotMachine()
        {
            return View();
        }
    }
}
