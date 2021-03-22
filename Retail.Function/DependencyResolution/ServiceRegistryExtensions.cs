using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Retail.Application.Data;
using Retail.Application.Data.Repositories;
using Retail.Common.Models.Settings;
using Retail.Infrastructure.Data.EF;
using Retail.Infrastructure.Data.EF.Repositories;
using System;
using Microsoft.EntityFrameworkCore;
using Hellang.Middleware.ProblemDetails;
using Retail.Common.Entities;
using Retail.Function.Exceptions;
using Retail.Application.UseCases.UpdateDeliveryOrder;
using Retail.Application.UseCases.CreateOrder;

namespace Retail.Function.DependencyResolution
{
    public static class ServiceRegistryExtensions
    {
        public static void AddProblemDetails(this IServiceCollection services)
        {
            services.AddProblemDetails(x =>
            {
                x.Map<BusinessRuleValidationException>(ex => new BusinessRuleValidationExceptionProblemDetails(ex));
            });
        }

        public static void AddDataAccess(this IServiceCollection services)
        {
            // Options
            services.AddOptions<ConnectionStrings>().Configure<IConfiguration>((settings, configuration) => { configuration.GetSection("ConnectionStrings").Bind(settings); });
            services.AddTransient(provider => provider.GetService<IOptionsMonitor<ConnectionStrings>>().CurrentValue);

            services.AddDbContext<RetailDataContext>((provider, optionsBuilder) => 
            {
                string connectionString = Environment.GetEnvironmentVariable("ConnectionStrings:RetailConnectionString");

                optionsBuilder.UseSqlServer(connectionString, b =>
                {
                    b.MigrationsAssembly("Retail.Infrastructure");
                    b.EnableRetryOnFailure();
                });
            });
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<RetailDataContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
        }

        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<ICreateOrderUseCase, CreateOrderUseCase>();
            services.AddTransient<IUpdateDeliveryOrderUseCase, UpdateDeliveryOrderUseCase>();
        }
        
    }
}
