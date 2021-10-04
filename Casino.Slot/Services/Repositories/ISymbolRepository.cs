using Casino.Common.Services;
using Casino.Slot.Models.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.Slot.Services
{
    public interface ISymbolRepository : IDataService<Symbol>
    {
        /// <summary>
        /// Gets all symbols from the database.
        /// </summary>
        /// <returns></returns>
        List<Symbol> GetAllSymbols();
    }
}
