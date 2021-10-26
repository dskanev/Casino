using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Portfolio.Models.Ticker
{
    public class TickerPreviousCloseOutput
    {
        public string Ticker { get; set; }
        public string Status { get; set; }
        public int ResultsCount { get; set; }
        public List<PreviousCloseResult> Results { get; set; }
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        public bool Adjusted { get; set; }
        public int QueryCount { get; set; }
    }

    public class PreviousCloseResult
    {
        [JsonPropertyName("Ticker")]
        [JsonProperty("T")]
        public string Ticker { get; set; }

        [JsonPropertyName("Close")]
        [JsonProperty("c")]
        public double Close { get; set; }

        [JsonPropertyName("Highest")]
        [JsonProperty("h")]
        public double Highest { get; set; }

        [JsonPropertyName("Lowest")]
        [JsonProperty("l")]
        public double Lowest { get; set; }

        [JsonPropertyName("Open")]
        [JsonProperty("o")]
        public double Open { get; set; }        

        [JsonPropertyName("Volume")]
        [JsonProperty("v")]
        public double Volume { get; set; }

        [JsonPropertyName("VolumeWeightedAveragePrice")]
        [JsonProperty("vw")]
        public double VolumeWeightedAveragePrice { get; set; }

        [JsonPropertyName("Timestamp")]
        [JsonProperty("t")]
        public long Timestamp { get; set; }
    }
}
