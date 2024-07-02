using PrimeNumber.Domain.Entities;
using PrimeNumber.Domain.Ports;
using PrimeNumber.Infrastructure.Ports;

namespace PrimeNumber.Infrastructure.Adapters
{
    [Repository]
    public class PrimeNumberRequestLogRepository : IPrimeNumberRequestLogRepository
    {
        readonly IRepository<PrimeNumberRequestLog> _dataSource;
        public PrimeNumberRequestLogRepository(IRepository<PrimeNumberRequestLog> dataSource) => _dataSource = dataSource
        ?? throw new ArgumentNullException(nameof(dataSource));

        public async Task<PrimeNumberRequestLog> Save(PrimeNumberRequestLog primeNumberRequest)
        {            
            return await _dataSource.AddAsync(primeNumberRequest);
        }
    }
}
