using Casino.Slot.Models;
using Casino.Slot.Models.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.Slot.Services.Symbols
{
    public interface ISymbolFactory
    {
        /// <summary>
        /// Generates a symbol for a line of the slot machine's spin
        /// </summary>
        /// <returns></returns>
        Symbol GenerateSymbol();

        /// <summary>
        /// Generates a line for the spin of the slot machine
        /// </summary>
        /// <param name="lineSize"></param>
        /// <returns></returns>
        Line GenerateLine(int lineSize);

        /// <summary>
        /// Generates a spin of the slot machine
        /// </summary>
        /// <param name="numberOfLines"></param>
        /// <returns></returns>
        Spin GenerateSpin(int numberOfLines = default);

        /// <summary>
        /// Get a list of all symbols and their probability in %
        /// </summary>
        /// <returns></returns>
        Dictionary<string, double>  GetSymbolsProbability();
    }
}
