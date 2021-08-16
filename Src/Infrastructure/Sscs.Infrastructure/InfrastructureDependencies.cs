using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sscs.Application.Common.Interfaces;
using Sscs.Infrastructure.Bus;

namespace Sscs.Infrastructure
{
    public static class InfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterEasyNetQ(configuration.GetConnectionString("RabbitMQ"));
            services.AddScoped<IEventBus, EventBus>();
            return services;
        }
    }
}