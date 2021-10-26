using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Infrastructure
{
    public class RestClientBuilder
    {
        public RestClient Client { get; set; }
        public RestRequest Request { get; set; }

        public RestClientBuilder OpenClient(string url, DataFormat dataFormat = DataFormat.Json)
        {
            Client = new RestClient(url);
            Request = new RestRequest("", dataFormat);
            return this;
        }
    }
}
