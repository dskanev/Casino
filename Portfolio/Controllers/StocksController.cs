using Casino.Common.Controllers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portfolio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Controllers
{
    public class StocksController : ApiController
    {
        private readonly IStockService _stockService;
        public StocksController(
            IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        [Route(nameof(PreviousClose))]
        public async Task<IActionResult> PreviousClose(string ticker)
        {
            var result = await _stockService.PreviousClose(ticker);
            return Ok(result);
        }

        [HttpGet]
        [Route(nameof(AllTickersSnapshot))]
        public async Task<IActionResult> AllTickersSnapshot()
        {
            var result = await _stockService.GetAllTickersSnapshot();
            return Ok();
        }
    }
}
