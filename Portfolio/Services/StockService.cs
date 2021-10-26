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

        public StockService(PortfolioDbContext db, IMapper mapper)
        : base(db)
        {
            this.mapper = mapper;
        }

        public async Task<AllTickersSnapshotOutput> GetAllTickersSnapshot()
        {
            var fluentUrlBuilder = new FluentUrlBuilder()
                .BaseUrl(PolygonURLs.BaseUrl)
                .AppendUrlSection(PolygonURLs.AllTcikersSnapshotUrl);

            var clientBuilder = new RestClientBuilder()
                .OpenClientWithUrl(fluentUrlBuilder.GetUrl());

            var response = await clientBuilder
                .Client
                .ExecuteGetAsync(clientBuilder.Request);

            var result = JsonConvert.DeserializeObject<AllTickersSnapshotOutput>(response.Content);

            return result;
        }

        public async Task<TickerPreviousCloseOutput> PreviousClose(string ticker)
        {
            var dbResult = await this.Data.Set<TickerPreviousClose>()
                .Where(x => x.Ticker == ticker)
                .OrderByDescending(x => x.Timestamp)
                .FirstOrDefaultAsync();

            if (dbResult == default)
            {
                return await GetPreviousCloseFromExternalApi(ticker);
            }

            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            var dbDate = dtDateTime.AddMilliseconds(dbResult.Timestamp).ToLocalTime();

            if (dbDate.AddDays(1) < DateTime.Now)
            {
                return await GetPreviousCloseFromExternalApi(ticker);
            }

            return new TickerPreviousCloseOutput 
            {
                Results = new List<PreviousCloseResult> { mapper.Map<PreviousCloseResult>(dbResult) }
            };
        }

        public async Task<TickerPreviousCloseOutput> GetPreviousCloseFromExternalApi(string ticker)
        {
            var fluentUrlBuilder = new FluentUrlBuilder()
                .BaseUrl(PolygonURLs.BaseUrl)
                .AppendUrlSection("aggs/ticker")
                .AppendUrlSection(ticker)
                .AppendUrlSection("prev")
                .AppendQueryParam(RequestConstants.Adjusted, "true");

            var clientBuilder = new RestClientBuilder()
                .OpenClientWithUrl(fluentUrlBuilder.GetUrl());

            var response = await clientBuilder
                .Client
                .ExecuteGetAsync(clientBuilder.Request);

            var previousClose = JsonConvert.DeserializeObject<TickerPreviousCloseOutput>(response.Content);

            var previousCloseDb = mapper.Map<TickerPreviousClose>(previousClose.Results.FirstOrDefault());
            await this.Data.AddAsync(previousCloseDb);
            await this.Data.SaveChangesAsync();

            return previousClose;
        }
    }
}
