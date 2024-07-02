using FluentValidation;
using PrimeNumber.Application.Persons;

namespace PrimeNumber.Api.ApiHandlers
{
    public class RequestGenerateValidator : AbstractValidator<RequestGenerateCommand>
    {        

        public RequestGenerateValidator()
        {            
            RuleFor(x => x.InitialNumber).NotEmpty();
            RuleFor(x => x.PrimeNumbers).NotEmpty();
            RuleFor(x => x.User).NotEmpty();
        }
    }
}
