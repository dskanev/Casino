using Portfolio.Models.Ticker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Services
{
    public interface IStockService
    {
        TickerPreviousCloseOutput PreviousClose(string ticker);
    }
}
