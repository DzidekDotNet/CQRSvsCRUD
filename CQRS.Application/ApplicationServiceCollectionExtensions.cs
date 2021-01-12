using CQRS.Application.Cars.AddNewCar;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Application
{
	public static class ApplicationServiceCollectionExtensions
	{
		public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
		{
			serviceCollection
				.AddCars();

			return serviceCollection;
		}
	}
}
