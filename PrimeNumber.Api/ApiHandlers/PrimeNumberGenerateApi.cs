using MediatR;
using PrimeNumber.Api.Filters;
using PrimeNumber.Application.Persons;
using PrimeNumber.Domain.Dtos;

namespace PrimeNumber.Api.ApiHandlers
{
    public static class PrimeNumberGenerateApi
    {
        public static RouteGroupBuilder MapTurn(this IEndpointRouteBuilder routeHandler)
        {
            routeHandler.MapPost("/", async (IMediator mediator, [Validate] RequestGenerateCommand person) =>
            {
                return Results.Ok(await mediator.Send(person));
            })
            .Produces(StatusCodes.Status200OK, typeof(PrimeNumbersDto))
            .Produces(StatusCodes.Status400BadRequest);

            return (RouteGroupBuilder)routeHandler;
        }
    }
}
