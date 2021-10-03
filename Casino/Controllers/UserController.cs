using AutoMapper;
using Casino.Common.Services.Identity;
using Casino.Services.Identity;
using Casino.Services.Slot;
using Casino.Services.UserHistory;
using Casino.ViewModels.UserHistory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.Controllers
{
    public class UserController : Controller
    {
        private readonly IIdentityService _identityService;
        private readonly ISlotService _slotService;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserHistoryService _userHistoryService;

        public UserController(
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
        public async Task<IActionResult> UserHistory()
        {
            var userId = _currentUserService.UserId;
            var model = new UserHistoryViewModel { };

            try
            {
                model.PastSpins = await this._userHistoryService.GetSpinHistory(userId, 10);
                model.BiggestWin = await this._userHistoryService.GetBiggestWin(userId);
                model.Balance = (await this._userHistoryService.GetBalance(userId)).Balance;
            }
            catch { }

            return View(model);
        }
    }
}
