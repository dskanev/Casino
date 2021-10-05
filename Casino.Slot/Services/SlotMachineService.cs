using Casino.Common;
using Casino.Common.Data.Models;
using Casino.Common.Messages;
using Casino.Common.Services;
using Casino.Slot.Models;
using Casino.Slot.Models.Symbols;
using Casino.Slot.Services.Repositories;
using Casino.Slot.Services.Symbols;
using MassTransit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.Slot.Services
{
    public class SlotMachineService : ISlotMachineService
    {
        private readonly ISymbolGenerationService _symbolGenerationService;
        private readonly ISpinResultRepository _spinResultRepository;
        private readonly IBus _publisher;

        public SlotMachineService(
            ISymbolGenerationService symbolGenerationService,
            ISpinResultRepository spinResultRepository,
            IBus publisher)
        {
            _symbolGenerationService = symbolGenerationService;
            _spinResultRepository = spinResultRepository;
            _publisher = publisher;
        }

        public Line GetLineOfSymbols(int sizeOfLine)
        {
            return _symbolGenerationService.GenerateLine(sizeOfLine);
        }

        public Spin GetSpinResult(long betSize)
        {
            var spin = _symbolGenerationService
                .GenerateSpin();        
            
            return CalculateWinnings(spin, betSize);
        }

        public async Task<Result<Spin>> SpinTheSlot(string userId, long betSize)
        {
            if (betSize < 0)
            {
                return Result<Spin>.Failure(new List<string> { "Cannot bet a negative amount." });
            }
            
            var spin = _symbolGenerationService
                .GenerateSpin();

            var spinResult = CalculateWinnings(spin, betSize);

            var spinResultDb = new SpinResult
            {
                UserId = userId,
                BetSize = betSize,
                Winnings = spinResult.Winnings
            };

            var slotMachineSpunMessageData = new SlotMachineWasSpunMessage
            {
                UserId = userId,
                Won = spin.IsWinning,
                Winnings = spin.Winnings,
                BetAmmount = betSize,
                Timestamp = System.DateTime.Now
            };

            var slotSpunMessage = new Message(slotMachineSpunMessageData);

            await this._spinResultRepository
                .Save(spinResultDb,slotSpunMessage);

            await this._publisher
                .Publish(slotMachineSpunMessageData);

            await this._spinResultRepository
                .MarkMessageAsPublished(slotSpunMessage.Id);

            return spinResult;
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
            return _symbolGenerationService
                .GetSymbolsProbability();
        }
    }
}
