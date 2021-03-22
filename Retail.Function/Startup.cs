using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Retail.Function.DependencyResolution;

[assembly: FunctionsStartup(typeof(Retail.Function.Startup))]
namespace Retail.Function
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddUseCases();
            builder.Services.AddDataAccess();
            builder.Services.AddRepositories();
            builder.Services.AddProblemDetails();
        }
    }
}
