using MediatR;
using PrimeNumber.Domain.Dtos;
using PrimeNumber.Domain.Services;

namespace PrimeNumber.Application.Persons
{
    public class RequestGenerateCommandHandler : IRequestHandler<RequestGenerateCommand, PrimeNumbersDto>
    {
        private readonly PrimeNumberGeneratorService _service;

        public RequestGenerateCommandHandler(PrimeNumberGeneratorService service) =>
            _service = service ?? throw new ArgumentNullException(nameof(service));


        public async Task<PrimeNumbersDto> Handle(RequestGenerateCommand request, CancellationToken cancellationToken)
        {            
            return await _service.Generate(new Domain.Entities.PrimeNumberRequest { InitialNumber = request.InitialNumber, PrimeNumbers = request.PrimeNumbers, User = request.User });
        }
    }
}
