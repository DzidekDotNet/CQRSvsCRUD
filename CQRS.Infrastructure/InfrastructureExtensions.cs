using CQRS.Application.Common.Commands;
using CQRS.Infrastructure.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Infrastructure
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<ICommandDispatcher, CommandDispatcher>();

            return serviceCollection;
        }
    }
}
