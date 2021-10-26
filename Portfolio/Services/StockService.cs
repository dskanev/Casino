using Casino.Common.Extensions;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        private string _apiKey { get; } = "OjHEzQV9oBrMAVO3Cml02vAiC1vBrS6O";
        private string _baseUrl { get; } = "https://api.polygon.io/v2";
        private string _apiKeyQueryParam { get; } = "apiKey";
        private string _adjustedQueryParam { get; } = "adjusted";
        public TickerPreviousCloseOutput PreviousClose(string ticker)
        {
            var fluentUrlBuilder = new FluentUrlBuilder()
                .BaseUrl(_baseUrl)
                .AppendUrlSection("aggs")
                .AppendUrlSection("ticker")
                .AppendUrlSection(ticker)
                .AppendUrlSection("prev")
                .AppendQueryParam(_adjustedQueryParam, "true")
                .AppendQueryParam(_apiKeyQueryParam, _apiKey);

            var client = new RestClient(fluentUrlBuilder.GetUrl());
            var request = new RestRequest("", DataFormat.Json);
            var response = client.Get(request);
            var serialized = JsonConvert.DeserializeObject<TickerPreviousCloseOutput>(response.Content);

            return serialized;
        }
    }
}
