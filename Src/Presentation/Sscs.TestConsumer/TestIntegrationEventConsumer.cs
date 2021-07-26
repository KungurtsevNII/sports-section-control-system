using System;
using System.Threading.Tasks;
using MassTransit;
using Sscs.Application.IntegrationEvents;

namespace Sscs.TestConsumer
{
    public class TestIntegrationEventConsumer : IConsumer<TestIntegrationEvent>
    {
        public Task Consume(ConsumeContext<TestIntegrationEvent> context)
        {
            Console.WriteLine($"Guid company - {context.Message.CompanyId}");
            return Task.CompletedTask;
        }
    }
    
    public class TestIntegrationEventConsumerFromThatQueqe : IConsumer<TestIntegrationEvent>
    {
        public Task Consume(ConsumeContext<TestIntegrationEvent> context)
        {
            Console.WriteLine($"Guid company from another consumer - {context.Message.CompanyId}");
            return Task.CompletedTask;
        }
    }
    
    public class TestIntegrationEventConsumerFromAnotherQueqe : IConsumer<TestIntegrationEvent>
    {
        public Task Consume(ConsumeContext<TestIntegrationEvent> context)
        {
            Console.WriteLine($"Guid company from another consumer - {context.Message.CompanyId}");
            return Task.CompletedTask;
        }
    }
}