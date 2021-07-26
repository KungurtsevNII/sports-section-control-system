using System;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Sscs.Extensions.MassTransit
{
    public static class BusDependencies
    {
        public static IServiceCollection AddRabbitMqBus(this IServiceCollection services)
        {
            
            
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, configurator) =>
                    configurator.Host(new Uri("rabbitmq://localhost/SscsVirtualHost"), h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                        //h.Heartbeat(TimeSpan.FromSeconds(10));
                    }));
            });

            services.AddMassTransitHostedService();

            return services;
        }
    }
}