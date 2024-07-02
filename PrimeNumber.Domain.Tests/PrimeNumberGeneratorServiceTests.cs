using NSubstitute;
using NSubstitute.ExceptionExtensions;
using PrimeNumber.Domain.Entities;
using PrimeNumber.Domain.Exception;
using PrimeNumber.Domain.Ports;
using PrimeNumber.Domain.Services;

namespace PrimeNumber.Domain.Tests
{
    public class PrimeNumberGeneratorServiceTests
    {
        readonly IPrimeNumberRequestLogRepository _repository = default!;
        readonly PrimeNumberGeneratorService _service = default!;

        public PrimeNumberGeneratorServiceTests()
        {
            _repository = Substitute.For<IPrimeNumberRequestLogRepository>();
            _service = new PrimeNumberGeneratorService(_repository);
        }

        [Fact]
        public async Task Generate_Returns_Correct_PrimeNumbersDto()
        {
            // Arrange
            var request = new PrimeNumberRequest
            {
                InitialNumber = 0,
                PrimeNumbers = 5,
                User = "test-user"
            };

            // Act
            var result = await _service.Generate(request);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.PrimeNumbers);
            Assert.Equal(request.PrimeNumbers, result.PrimeNumbers.Count);
        }

        [Theory]
        [InlineData(0, 5, new[] { 2, 3, 5, 7, 11 })]
        [InlineData(10, 3, new[] { 11, 13, 17 })]
        [InlineData(20, 5, new[] { 23, 29, 31, 37, 41 })]
        public void GeneratePrimeNumbers_Returns_Correct_Prime_Numbers(int start, int count, int[] expectedPrimes)
        {
            // Act
            var result = _service.GeneratePrimeNumbers(start, count);

            // Assert
            Assert.Equal(expectedPrimes, result);
        }

        [Theory]
        [InlineData(0, false)]
        [InlineData(1, false)]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(4, false)]
        [InlineData(5, true)]
        [InlineData(6, false)]
        [InlineData(7, true)]
        [InlineData(8, false)]
        [InlineData(9, false)]
        [InlineData(10, false)]
        public void IsPrime_Returns_Correctly(int number, bool expectedResult)
        {
            // Act
            var result = _service.IsPrime(number);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}