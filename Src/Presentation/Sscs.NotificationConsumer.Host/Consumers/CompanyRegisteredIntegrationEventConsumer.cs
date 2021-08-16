using System;
using System.Threading;
using System.Threading.Tasks;
using EasyNetQ.AutoSubscribe;
using Sscs.Application.IntegrationEvents;

namespace Sscs.NotificationConsumer.Host.Consumers
{
    public class CompanyRegisteredIntegrationEventConsumer : IConsumeAsync<CompanyRegisteredIntegrationEvent>
    {
        public Task ConsumeAsync(CompanyRegisteredIntegrationEvent message,
            CancellationToken cancellationToken = new CancellationToken())
        {
            Console.WriteLine($"ID company - {message.CompanyId}");
            throw new Exception("Пошел в жопу");
            return Task.CompletedTask;
        }
    }
}