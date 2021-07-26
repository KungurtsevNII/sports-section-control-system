using System;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.RabbitMqTransport.Configuration;
using MassTransit.RabbitMqTransport.Transport;
using Microsoft.Extensions.Hosting;

namespace Sscs.TestConsumer
{
    class Program
    {
        public static async Task Main()
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(new Uri("rabbitmq://localhost/SscsVirtualHost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                    //h.Heartbeat(TimeSpan.FromSeconds(10));
                });
                
                cfg.ReceiveEndpoint("recieve-endpoint-queue-name", e =>
                {
                    e.Consumer<TestIntegrationEventConsumer>();
                    e.Consumer<TestIntegrationEventConsumerFromThatQueqe>();
                });
                
                cfg.ReceiveEndpoint("another-queue", e =>
                {
                    e.Consumer<TestIntegrationEventConsumerFromAnotherQueqe>();
                });
                
            });

            await busControl.StartAsync();

            Console.ReadLine();

            await busControl.StopAsync();
        }
    }
}