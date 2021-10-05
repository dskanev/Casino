using Casino.Common.Messages;
using Casino.UserHistory.Models;
using Casino.UserHistory.Services;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.UserHistory.Messages
{
    public class SlotMachineWasSpunConsumer : IConsumer<SlotMachineWasSpunMessage>
    {
        private readonly IUserHistoryService _userHistoryService;

        public SlotMachineWasSpunConsumer(IUserHistoryService userHistoryService)
        {
            _userHistoryService = userHistoryService;
        }

        public async Task Consume(ConsumeContext<SlotMachineWasSpunMessage> context)
        {
            await this._userHistoryService.SaveSpinHistoryRecord(new HistoryRecordInputModel
            {
                UserId = context.Message.UserId,
                Won = context.Message.Won,
                Winnings = context.Message.Winnings,
                BetAmount = context.Message.BetAmmount,
                Timestamp = context.Message.Timestamp
            });

            await this._userHistoryService
                .AddBalance(context.Message.UserId,
                context.Message.Winnings - context.Message.BetAmmount);
        }
    }
}
