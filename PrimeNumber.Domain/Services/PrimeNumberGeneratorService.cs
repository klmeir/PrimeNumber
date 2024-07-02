using PrimeNumber.Domain.Dtos;
using PrimeNumber.Domain.Entities;
using PrimeNumber.Domain.Exception;
using PrimeNumber.Domain.Ports;
using System.Text.Json;

namespace PrimeNumber.Domain.Services
{
    [DomainService]
    public class PrimeNumberGeneratorService
    {        
        private readonly IPrimeNumberRequestLogRepository _primeNumberRequestRepository;        

        public PrimeNumberGeneratorService(IPrimeNumberRequestLogRepository primeNumberRequestRepository)
        {
            _primeNumberRequestRepository = primeNumberRequestRepository;
        }        

        public async Task<PrimeNumbersDto> Generate(PrimeNumberRequest request) 
        {
            try
            {
                var log = new PrimeNumberRequestLog { Request = JsonSerializer.Serialize(request), DateRequest = DateTime.UtcNow, User = request.User };

                var primeNumbers = this.GeneratePrimeNumbers(request.InitialNumber, request.PrimeNumbers);

                var response = new PrimeNumbersDto(primeNumbers);

                log.Response = JsonSerializer.Serialize(response);
                log.DateResponse = DateTime.UtcNow;

                await _primeNumberRequestRepository.Save(log);

                return response;
            }
            catch (System.Exception) {
                throw new CoreBusinessException("An error occurred while storing the message in the database.");
            }            
        }

        public List<int> GeneratePrimeNumbers(int start, int count)
        {
            List<int> primeNumbers = new List<int>();

            while (primeNumbers.Count < count)
            {
                if (IsPrime(start))
                {
                    primeNumbers.Add(start);
                }
                start++;
            }

            return primeNumbers;
        }

        public bool IsPrime(int number)
        {
            if (number <= 1)
                return false;
            if (number == 2)
                return true;
            if (number % 2 == 0)
                return false;

            int boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
    }
}
