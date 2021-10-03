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
    public class BalanceUpdatedConsumer : IConsumer<BalanceUpdatedMessage>
    {
        private readonly IUserHistoryService _userHistoryService;

        public BalanceUpdatedConsumer(IUserHistoryService userHistoryService)
        {
            _userHistoryService = userHistoryService;
        }

        public async Task Consume(ConsumeContext<BalanceUpdatedMessage> context)
            => await this._userHistoryService.AddBalance(
                context.Message.UserId,
                context.Message.AddBalance);
    }
}
