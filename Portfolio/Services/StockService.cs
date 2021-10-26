using Casino.Common.Extensions;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Portfolio.Infrastructure;
using Portfolio.Models.Ticker;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Services
{
    public class StockService : IStockService
    {
        public Task<AllTickersSnapshotOutput> GetAllTickersSnapshot()
        {
            var fluentUrlBuilder = new FluentUrlBuilder()
                .BaseUrl(PolygonURLs.BaseUrl)
                .AppendUrlSection(PolygonURLs.AllTcikersSnapshotUrl);

            return null;
        }

        public async Task<TickerPreviousCloseOutput> PreviousClose(string ticker)
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

            var serialized = JsonConvert.DeserializeObject<TickerPreviousCloseOutput>(response.Content);

            return serialized;
        }
    }
}
