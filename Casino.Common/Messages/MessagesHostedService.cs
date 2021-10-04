using Casino.Common.Data.Models;
using Hangfire;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Casino.Common.Messages
{
    public class MessagesHostedService : IHostedService
    {
        private readonly IRecurringJobManager _recurringJob;
        private readonly DbContext _data;
        private readonly IBus _publisher;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            this._recurringJob.AddOrUpdate(
                nameof(MessagesHostedService),
                () => this.ProcessPendingMessages(),
                "*/20 */5 * * * *");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void ProcessPendingMessages()
        {
            var messages = this._data
                .Set<Message>()
                .Where(x => !x.IsPublished)
                .ToList();

            foreach(var message in messages)
            {
                this._publisher
                    .Publish(message.Data, message.Type);

                message
                    .MarkAsPublished();

                this._data
                    .SaveChanges();
            }
        }
    }
}
