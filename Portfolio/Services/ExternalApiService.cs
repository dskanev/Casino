using Casino.Common.Extensions;
using Newtonsoft.Json;
using Portfolio.Infrastructure;
using Portfolio.Models.Ticker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Services
{
    public class ExternalApiService : IExternalApiService
    {

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

            return JsonConvert.DeserializeObject<TickerPreviousCloseOutput>(response.Content);
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
    }
}
