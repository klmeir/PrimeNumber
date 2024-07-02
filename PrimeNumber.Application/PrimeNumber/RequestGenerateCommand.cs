using MediatR;
using PrimeNumber.Domain.Dtos;

namespace PrimeNumber.Application.Persons
{
    public record RequestGenerateCommand(int InitialNumber, int PrimeNumbers, string User) : IRequest<PrimeNumbersDto>;
}
