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
        [Route("GetSpinHistory/{userId}")]
        public async Task<List<SpinHistory>> GetSpinHistory(string userId)
        {
            var result = await this.userHistoryService.GetSpinHistory(userId);
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
        [Route("AddBalance/{userId}/{balance}")]
        public async Task<ActionResult<UserOutputModel>> AddBalance(string userId, double balance)
        {
            var result = await this.userHistoryService.AddBalance(userId, balance);

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
    }
}
