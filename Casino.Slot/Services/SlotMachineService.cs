﻿using Casino.Common;
using Casino.Slot.Models;
using Casino.Slot.Models.Symbols;
using Casino.Slot.Services.Symbols;
using System.Collections.Generic;
using System.Linq;

namespace Casino.Slot.Services
{
    public class SlotMachineService : ISlotMachineService
    {
        private readonly ISymbolFactory _symbolFactory;
        public SlotMachineService(
            ISymbolFactory symbolFactory)
        {
            _symbolFactory = symbolFactory;
        }

        public Line GetLineOfSymbols(int sizeOfLine)
        {
            return _symbolFactory.GenerateLine(sizeOfLine);
        }

        public Spin GetSpinResult(long betSize)
        {
            var spin = _symbolFactory
                .GenerateSpin();        
            
            return CalculateWinnings(spin, betSize);
        }

        private Spin CalculateWinnings(Spin spin, long betSize)
        {
            spin.Lines
                .ForEach(x => spin.Winnings += EvaluateLine(x) * betSize);

            return spin;
        }

        private double EvaluateLine(Line line)
        {
            if (IsWinningLine(line))
            {
                return line
                    .Symbols
                    .Select(x => x.Coefficient)
                    .Sum();
            }
            else
            {
                return default;
            }
        }

        private bool IsWinningLine(Line line)
        {
            return line
                .Symbols
                .Where(x => x.Name != "Wildcard")
                .Select(x => x.Name)
                .Distinct()
                .Count() == NumericConstants.One;
        }

        public Dictionary<string, double> GetSymbolsProbability()
        {
            return _symbolFactory
                .GetSymbolsProbability();
        }
    }
}