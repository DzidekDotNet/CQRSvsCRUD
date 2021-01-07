using CQRS.Application;
using CQRS.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Api
{
    public static class CQRSApiExtensions
    {
        public static IServiceCollection AddCQRSApi(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddApplication()
                .AddInfrastructure();

            return serviceCollection;
        }
    }
}
