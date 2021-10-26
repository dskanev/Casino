using AutoMapper;
using Casino.Common.Extensions;
using Casino.Common.Services;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Portfolio.Data;
using Portfolio.Data.Models;
using Portfolio.Infrastructure;
using Portfolio.Models.Ticker;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Services
{
    public class StockService : DataService<TickerPreviousClose>, IStockService
    {
        private readonly IMapper mapper;
        private readonly IExternalApiService externalApi;

        public StockService(
            PortfolioDbContext db,
            IMapper mapper,
            IExternalApiService externalApi)
        : base(db)
        {
            this.mapper = mapper;
            this.externalApi = externalApi;
        }

        public async Task<AllTickersSnapshotOutput> GetAllTickersSnapshot()
        {
            return await externalApi
                .GetAllTickersSnapshot();
        }

        public async Task<TickerPreviousCloseOutput> PreviousClose(string ticker)
        {
            var dbResult = await this.Data.Set<TickerPreviousClose>()
                .Where(x => x.Ticker == ticker)
                .OrderByDescending(x => x.Timestamp)
                .FirstOrDefaultAsync();

            if (dbResult == default || dbResult.Timestamp.IsOlderThanNumberOfDays(1))
            {
                var previousClose = await externalApi.GetPreviousCloseFromExternalApi(ticker);
                var previousCloseDb = mapper.Map<TickerPreviousClose>(previousClose.Results.FirstOrDefault());
                await this.Data.AddAsync(previousCloseDb);
                await this.Data.SaveChangesAsync();

                return previousClose;
            }

            return new TickerPreviousCloseOutput 
            {
                Results = new List<PreviousCloseResult> { mapper.Map<PreviousCloseResult>(dbResult) }
            };
        }
    }
}
