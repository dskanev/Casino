using Casino.Common.Controllers;
using Casino.Common.Extensions;
using Casino.Common.Models;
using Casino.Common.Services.Identity;
using Casino.UserHistory.Data.Models;
using Casino.UserHistory.Models;
using Casino.UserHistory.Models.UserDetails;
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
        private readonly ICurrentUserService currentUserService;

        public HistoryController(IUserHistoryService userHistoryService,
            ICurrentUserService currentUserService)
        {
            this.userHistoryService = userHistoryService;
            this.currentUserService = currentUserService;
        }

        [Authorize]
        [HttpGet]
        [Route("GetSpinHistory")]
        public async Task<List<SpinHistory>> GetSpinHistory(string userId, int limit)
        {
            userId.IsNullOrEmpty().OnTrue(() => userId = currentUserService.UserId);
            var result = await this.userHistoryService.GetSpinHistory(userId, limit);
            return result;
        }

        [Authorize]
        [HttpGet]
        [Route("GetBiggestWin/{userId}")]
        public async Task<SpinHistory> GetBiggestWin(string userId)
        {
            var result = await this.userHistoryService.GetBiggestWin(userId);
            return result;
        }

        [Authorize]
        [HttpPost]
        [Route(nameof(SaveSpinHistoryRecord))]
        public async Task SaveSpinHistoryRecord(HistoryRecordInputModel model)
        {
            await this.userHistoryService.SaveSpinHistoryRecord(model);
        }

        [Authorize]
        [HttpGet]
        [Route("GetBalance/{userId}")]
        public async Task<ActionResult<UserOutputModel>> GetBalance(string userId)
        {
            var result = await this.userHistoryService.GetBalance(userId);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result.Data);
        }

        [Authorize]
        [HttpPost]
        [Route("UpdateBalance/{userId}/{newBalance}")]
        public async Task<ActionResult<UserOutputModel>> UpdateBalance(string userId, double newBalance)
        {
            var result = await this.userHistoryService.UpdateBalance(userId, newBalance);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result.Data);
        }

        [Authorize]
        [HttpPost]
        [Route("UserDetails")]
        public async Task<ActionResult<UserDetailsInputModel>> UserDetails(UserDetailsInputModel details)
        {
            details.UserId = currentUserService.UserId;
            var result = await this.userHistoryService.SaveUserDetails(details);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result.Data);
        }

        [Authorize]
        [HttpGet]
        [Route("UserDetails")]
        public async Task<ActionResult<UserDetails>> UserDetails(QueryInputModel query)
        {
            var userId = currentUserService.UserId;
            var result = await this.userHistoryService.GetUserDetails(userId);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result.Data);
        }
    }
}
