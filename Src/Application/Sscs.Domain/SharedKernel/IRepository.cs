namespace Sscs.Domain.SharedKernel
{
    public interface IRepository<T> where T: IAggregateRoot { }
}