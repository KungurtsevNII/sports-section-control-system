using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Sscs.NotificationConsumer.Host
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IBus _bus;
        private readonly IConfiguration _configuration;

        public Worker(ILogger<Worker> logger, IBus bus, IConfiguration configuration)
        {
            _logger = logger;
            _bus = bus;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var subscriptionIdPrefix = _configuration.GetValue<string>("RabbitMQSubscriptionIdPrefix");
            var subscriber = new AutoSubscriber(_bus, subscriptionIdPrefix)
            {
                GenerateSubscriptionId = c => AppDomain.CurrentDomain.FriendlyName + " " + c.ConcreteType.Name
            };

            await subscriber.SubscribeAsync(new []{ Assembly.GetExecutingAssembly() }, stoppingToken);
        }
    }
}