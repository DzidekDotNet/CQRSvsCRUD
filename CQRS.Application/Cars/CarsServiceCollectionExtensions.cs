using CQRS.Application.Common.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Application.Cars.AddNewCar
{
    internal static class CarsServiceCollectionExtensions
    {
        internal static IServiceCollection AddCars(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<ICommandHandler<AddNewCarCommand, long>, AddNewCarCommandHandler>();

            return serviceCollection;
        }
    }
}
