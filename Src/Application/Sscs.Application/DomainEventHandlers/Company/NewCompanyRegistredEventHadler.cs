using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Sscs.Domain.DomainEvents.Company;

namespace Sscs.Application.DomainEventHandlers.Company
{
    public class NewCompanyRegisteredEventHandler : INotificationHandler<NewCompanyRegisteredEvent>
    {
        private readonly ILogger<NewCompanyRegisteredEventHandler> _logger;

        public NewCompanyRegisteredEventHandler(ILogger<NewCompanyRegisteredEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(NewCompanyRegisteredEvent notification, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Началась обработка события. Поток - {thread}", Thread.CurrentThread.ManagedThreadId);
            return Task.CompletedTask;
        }
    }
}