using Casino.Common.Controllers;
using Casino.UserHistory.Data.Models;
using Casino.UserHistory.Models;
using Casino.UserHistory.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.UserHistory.Controllers
{
    public class HistoryController : ApiController
    {
        private readonly IUserHistoryService userHistoryService;

        public HistoryController(IUserHistoryService userHistoryService)
            => this.userHistoryService = userHistoryService;

        [Authorize]
        [HttpGet]
        [Route(Id)]
        public async Task<List<SpinHistory>> MealsTracked(string userId)
        {
            var result = await this.userHistoryService.GetSpinHistory(userId);
            return result;
        }

        [Authorize]
        [HttpPost]
        public async Task SaveSpinHistoryRecord(HistoryRecordInputModel model)
        {
            await this.userHistoryService.SaveSpinHistoryRecord(model);
        }
    }
}
