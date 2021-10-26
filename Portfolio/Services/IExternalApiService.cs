using Portfolio.Models.Ticker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Services
{
    public interface IExternalApiService
    {
        Task<AllTickersSnapshotOutput> GetAllTickersSnapshot();
        Task<TickerPreviousCloseOutput> GetPreviousCloseFromExternalApi(string ticker);
    }
}
