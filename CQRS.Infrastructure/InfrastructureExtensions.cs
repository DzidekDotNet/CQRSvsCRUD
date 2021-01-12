using CQRS.Application.Cars.AddNewCar;
using CQRS.Application.Common.Commands;
using CQRS.Infrastructure.Cars;
using CQRS.Infrastructure.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Infrastructure
{
	public static class InfrastructureExtensions
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
		{
			serviceCollection
				.AddTransient<ICommandDispatcher, CommandDispatcher>()
				.AddSingleton<IAddNewCarRepository, CarRepository>();

			return serviceCollection;
		}
	}
}
