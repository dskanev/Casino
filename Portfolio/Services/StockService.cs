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
        public TickerPreviousCloseOutput PreviousClose(string ticker)
        {
            var client = new RestClient($"https://api.polygon.io/v2/aggs/ticker/" + ticker + "/prev?adjusted=true&apiKey=" + _apiKey);
            var request = new RestRequest("", DataFormat.Json);
            var response = client.Get(request);
            var serialized = JsonConvert.DeserializeObject<TickerPreviousCloseOutput>(response.Content);

            return serialized;
        }
    }
}
