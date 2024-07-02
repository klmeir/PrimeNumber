
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PrimeNumber.Api.ApiHandlers;
using PrimeNumber.Api.Filters;
using PrimeNumber.Api.Middleware;
using PrimeNumber.Infrastructure.DataSource;
using PrimeNumber.Infrastructure.Extensions;
using Serilog;
using System.Reflection;

namespace PrimeNumber.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {            
            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

            try
            {
                var builder = WebApplication.CreateBuilder(args);
                var config = builder.Configuration;

                builder.Host.UseSerilog((context, loggerConfiguration) =>
                {
                    loggerConfiguration.WriteTo.Console();
                    loggerConfiguration.ReadFrom.Configuration(context.Configuration);
                });

                builder.Services.AddValidatorsFromAssemblyContaining<Program>(ServiceLifetime.Singleton);

                builder.Services.AddDbContext<DataContext>(opts =>
                {
                    opts.UseSqlServer(config.GetConnectionString("db"));
                });            

                // Add services to the container.
                builder.Services.AddAuthorization();
                builder.Services.AddDomainServices();

                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();

                builder.Services.AddMediatR(Assembly.Load("PrimeNumber.Application"), typeof(Program).Assembly);                

                var app = builder.Build();

                app.UseSerilogRequestLogging();

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }            

                app.UseAuthorization();

                app.UseMiddleware<AppExceptionHandlerMiddleware>();

                app.MapGroup("/primenumbers/generate").MapTurn().AddEndpointFilterFactory(ValidationFilter.ValidationFilterFactory);

                app.Run();

            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "server terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
