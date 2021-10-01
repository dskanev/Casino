using AutoMapper;
using Casino.Common.Services.Identity;
using Casino.Services.Identity;
using Casino.Services.Slot;
using Casino.Services.UserHistory;
using Casino.ViewModels;
using Casino.ViewModels.Homepage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.Controllers
{
    public class HomeController : Controller
    {
        private readonly IIdentityService _identityService;
        private readonly ISlotService _slotService;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserHistoryService _userHistoryService;

        public HomeController(
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
        public IActionResult Index()
        {
            if (_currentUserService.UserId != null)
            {
                return RedirectToAction(nameof(HomeController.Homepage), "Home");
            }

            return View();
        }

        [Authorize]
        public async Task<IActionResult> Homepage()
        {
            var userId = _currentUserService.UserId;
            var model = new HomepageViewModel { };

            try
            {
                model.PastSpins = await this._userHistoryService.GetSpinHistory(userId);
            }
            catch { }            

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier
            });
    }
}
