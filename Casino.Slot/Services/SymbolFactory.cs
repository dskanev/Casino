﻿using Casino.Common;
using Casino.Slot.Constants;
using Casino.Slot.Models;
using Casino.Slot.Models.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.Slot.Services.Symbols
{
    public class SymbolFactory : ISymbolFactory
    {       
        /// <summary>
        /// Generates a symbol for a line of the slot machine's spin
        /// </summary>
        /// <returns></returns>
        public Symbol GenerateSymbol()
        {            
            var allSymbols = GetAllSymbols();
            return DrawSymbol(allSymbols);
        }

        /// <summary>
        /// Get a list of all symbols and their probability in %
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, double> GetSymbolsProbability()
        {
            var allSymbols = GetAllSymbols();
            var totalRarity = allSymbols
                .Sum(x => x.Rarity);

            var result = allSymbols
                .Select(x => new
                {
                    x.Name,
                    Probability = GetProbability(
                    x.Rarity,
                    allSymbols.Where(rarerSymbol => rarerSymbol.Rarity < x.Rarity)
                            .Sum(rarerSymbol => rarerSymbol.Rarity),
                    totalRarity)
                })
                .ToDictionary(x => x.Name, x => x.Probability);

            return result;
        }

        /// <summary>
        /// Generates a line for the spin of the slot machine
        /// </summary>
        /// <param name="lineSize"></param>
        /// <returns></returns>
        public Line GenerateLine(int lineSize)
        {
            var result = new Line();

            for (int generatedSymbols = 0; generatedSymbols < lineSize; generatedSymbols++)
            {
                result.Symbols.Add(GenerateSymbol());
            }
            return result;
        }

        /// <summary>
        /// Generates a spin of the slot machine
        /// </summary>
        /// <param name="numberOfLines"></param>
        /// <returns></returns>
        public Spin GenerateSpin(int numberOfLines = default)
        {
            var result = new Spin();
            if (numberOfLines == default)
            {
                numberOfLines = SlotMachineConstants._defaultNumberOfLines;
            }

            for (int generatedLine = 0; generatedLine < numberOfLines; generatedLine++)
            {
                result.Lines.Add(GenerateLine(SlotMachineConstants._defaultLineSize));
            }
            return result;
        }

        /// <summary>
        /// Gets all symbols
        /// </summary>
        /// <returns></returns>
        private List<Symbol> GetAllSymbols()
        {
            return new List<Symbol>() {
                new Symbol{ Name = "Stone", Coefficient = 0.2, Rarity = 0.70 },
                new Symbol{ Name  = "Apple", Coefficient = 0.4, Rarity = 0.45 },
                new Symbol{ Name = "Banana", Coefficient = 0.6, Rarity = 0.35 },
                new Symbol{ Name = "Pineapple", Coefficient = 0.8, Rarity = 0.15 },
                new Symbol{ Name = "Wildcard", Coefficient = 0, Rarity = 0.05 },
            };
        }

        /// <summary>
        /// Draws a symbol from a list of symbols
        /// </summary>
        /// <param name="allSymbols"></param>
        /// <returns></returns>
        private Symbol DrawSymbol(List<Symbol> allSymbols)
        {
            Random random = new Random();
            var randomNumberBetweenZeroAndOne = random.NextDouble();

            var totalRarity = allSymbols
                .Sum(x => x.Rarity);

            return allSymbols
                    .OrderBy(symbol => symbol.Rarity)
                    .Where(symbol => randomNumberBetweenZeroAndOne < GetRelativeRarity(
                        symbol.Rarity,
                        allSymbols
                            .Where(rarerSymbol => rarerSymbol.Rarity < symbol.Rarity)
                            .Sum(rarerSymbol => rarerSymbol.Rarity),
                        totalRarity))
                    .FirstOrDefault();
        }        

        /// <summary>
        /// Calculates the symbol's rarity relative to all symbols
        /// represented by a number between 0 and 1
        /// </summary>
        /// <param name="rarity"></param>
        /// <param name="sumOfRarerSymbolsRarity"></param>
        /// <param name="totalRarity"></param>
        /// <returns></returns>
        private double GetRelativeRarity(double rarity, double sumOfRarerSymbolsRarity, double totalRarity)
        {
            return (rarity + sumOfRarerSymbolsRarity) / totalRarity;
        }

        private double GetProbability(double rarity, double sumOfRarerSymbolsRarity, double totalRarity)
        {
            return Math.Round(rarity / totalRarity * 100, 2);
        }
    }
}
