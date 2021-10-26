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
                .AppendUrlSection(PolygonURLs.AllTcikersSnapshotUrl)
                .AppendQueryParam(UrlQueryParams.ApiKeyParam, PolygonURLs.ApiKey);

            return null;
        }

        public async Task<TickerPreviousCloseOutput> PreviousClose(string ticker)
        {
            var fluentUrlBuilder = new FluentUrlBuilder()
                .BaseUrl(PolygonURLs.BaseUrl)
                .AppendUrlSection("aggs/ticker")
                .AppendUrlSection(ticker)
                .AppendUrlSection("prev")
                .AppendQueryParam(UrlQueryParams.Adjusted, "true")
                .AppendQueryParam(UrlQueryParams.ApiKeyParam, PolygonURLs.ApiKey);

            var clientBuilder = new RestClientBuilder()
                .OpenClient(fluentUrlBuilder.GetUrl());

            var response = await clientBuilder
                .Client
                .ExecuteGetAsync(clientBuilder.Request);

            var serialized = JsonConvert.DeserializeObject<TickerPreviousCloseOutput>(response.Content);

            return serialized;
        }
    }
}
