using System.Threading.Tasks;

namespace Sscs.Application.Common.Interfaces
{
    public interface IEventBus
    {
        Task PublishEvent<T>(T integrationEvent);
    }
}