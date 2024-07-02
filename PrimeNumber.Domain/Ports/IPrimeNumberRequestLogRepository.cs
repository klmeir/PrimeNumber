using PrimeNumber.Domain.Entities;

namespace PrimeNumber.Domain.Ports
{
    public interface IPrimeNumberRequestLogRepository
    {
        Task<PrimeNumberRequestLog> Save(PrimeNumberRequestLog primeNumberRequestLog);
    }
}
