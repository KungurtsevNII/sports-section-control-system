using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Sscs.Application.Common.Interfaces;
using Sscs.Application.IntegrationEvents;
using Sscs.Domain.DomainEvents.Company;

namespace Sscs.Application.DomainEventHandlers.CompanyEventHandlers
{
    public class CompanyRegisteredEventHandler : INotificationHandler<NewCompanyRegisteredEvent>
    {
        private readonly ILogger<CompanyRegisteredEventHandler> _logger;
        private readonly IEventBus _eventBus;

        public CompanyRegisteredEventHandler(ILogger<CompanyRegisteredEventHandler> logger, IEventBus eventBus)
        {
            _logger = logger;
            _eventBus = eventBus;
        }

        public async Task Handle(NewCompanyRegisteredEvent notification, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Началась обработка события. Поток - {thread}", Thread.CurrentThread.ManagedThreadId);
            await _eventBus.PublishEvent(new CompanyRegisteredIntegrationEvent
            {
                CompanyId = notification.CompanyId,
            });
        }
    }
}