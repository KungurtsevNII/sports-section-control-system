using System.Threading.Tasks;
using EasyNetQ;
using IEventBus = Sscs.Application.Common.Interfaces.IEventBus;

namespace Sscs.Infrastructure.Bus
{
    public class EventBus : IEventBus
    {
        private readonly IBus _bus;

        public EventBus(IBus bus)
        {
            _bus = bus;
        }

        public Task PublishEvent<T>(T integrationEvent) => _bus.PubSub.PublishAsync(integrationEvent);
    }
}