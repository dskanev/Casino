using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models.Ticker
{
    public class AllTickersSnapshotOutput
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("tickers")]
        public List<Ticker> Tickers { get; set; }
    }

    public class Day
    {
        [JsonProperty("c")]
        public double ClosePrice { get; set; }

        [JsonProperty("h")]
        public double HighestPrice { get; set; }

        [JsonProperty("l")]
        public double LowestPrice { get; set; }

        [JsonProperty("o")]
        public double OpenPrice { get; set; }

        [JsonProperty("v")]
        public int TradingVolume { get; set; }

        [JsonProperty("vw")]
        public double VolumeWeightedAveragePrice { get; set; }
    }

    public class LastQuote
    {
        [JsonProperty("P")]
        public double AskPrice { get; set; }

        [JsonProperty("S")]
        public int AskSize { get; set; }

        [JsonProperty("p")]
        public double BidPrice { get; set; }

        [JsonProperty("s")]
        public int BidSize { get; set; }

        [JsonProperty("t")]
        public long Timestamp { get; set; }
    }

    public class LastTrade
    {
        [JsonProperty("c")]
        public List<int> Conditions { get; set; }

        [JsonProperty("i")]
        public string Id { get; set; }

        [JsonProperty("p")]
        public double Price { get; set; }

        [JsonProperty("s")]
        public int Size { get; set; }

        [JsonProperty("t")]
        public long Timestamp { get; set; }

        [JsonProperty("x")]
        public int ExchangeId { get; set; }
    }

    public class Min
    {
        [JsonProperty("av")]
        public int AccumulatedVolume { get; set; }

        [JsonProperty("c")]
        public double ClosePrice { get; set; }

        [JsonProperty("h")]
        public double HighestPrice { get; set; }

        [JsonProperty("l")]
        public double LowestPrice { get; set; }

        [JsonProperty("o")]
        public double OpenPrice { get; set; }

        [JsonProperty("v")]
        public int TradingVolume { get; set; }

        [JsonProperty("vw")]
        public double VolumeWeightedAveragePrice { get; set; }
    }

    public class PrevDay
    {
        [JsonProperty("c")]
        public double ClosePrice { get; set; }

        [JsonProperty("h")]
        public int HighestPrice { get; set; }

        [JsonProperty("l")]
        public double LowestPrice { get; set; }

        [JsonProperty("o")]
        public double OpenPrice { get; set; }

        [JsonProperty("v")]
        public int TradingVolume { get; set; }

        [JsonProperty("vw")]
        public double VolumeWeightedAveragePrice { get; set; }
    }

    public class Ticker
    {
        [JsonProperty("day")]
        public Day Day { get; set; }

        [JsonProperty("lastQuote")]
        public LastQuote LastQuote { get; set; }

        [JsonProperty("lastTrade")]
        public LastTrade LastTrade { get; set; }

        [JsonProperty("min")]
        public Min Min { get; set; }

        [JsonProperty("prevDay")]
        public PrevDay PrevDay { get; set; }

        [JsonProperty("ticker")]
        public string TickerName { get; set; }

        [JsonProperty("todaysChange")]
        public double TodaysChange { get; set; }

        [JsonProperty("todaysChangePerc")]
        public double TodaysChangePerc { get; set; }

        [JsonProperty("updated")]
        public long Updated { get; set; }
    }
}
