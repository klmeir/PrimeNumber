using PrimeNumber.Domain.Entities;

namespace PrimeNumber.Infrastructure.Ports
{
    public interface IRepository<T> where T : DomainEntity
    {
        Task<T> AddAsync(T entity);
    }
}
