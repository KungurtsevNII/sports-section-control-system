using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Sscs.Application.IntegrationEvents;
using Sscs.Domain.DomainEvents.Company;

namespace Sscs.Application.DomainEventHandlers.CompanyEventHandlers
{
    public class NewCompanyRegisteredEventHandler : INotificationHandler<NewCompanyRegisteredEvent>
    {
        private readonly ILogger<NewCompanyRegisteredEventHandler> _logger;
        private readonly IPublishEndpoint _publishEndpoint;

        public NewCompanyRegisteredEventHandler(ILogger<NewCompanyRegisteredEventHandler> logger, IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        public Task Handle(NewCompanyRegisteredEvent notification, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Началась обработка события. Поток - {thread}", Thread.CurrentThread.ManagedThreadId);
            _publishEndpoint.Publish(new TestIntegrationEvent(notification.CompanyId), cancellationToken);
            return Task.CompletedTask;
        }
    }
}