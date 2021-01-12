using CQRS.Application.Cars.AddNewCar;
using CQRS.Domain.Cars;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Infrastructure.Cars
{
	internal sealed class CarRepository : IAddNewCarRepository
	{
		private object carPersistanceLock = new object();
		private readonly List<Car> cars = new List<Car>();
		public Task<long> Add(NewCar newCar)
		{
			lock (carPersistanceLock)
			{
				if (!cars.Any())
				{
					cars.Add(new Car(1, newCar.Brand, newCar.YearOfProduction));
					return Task.FromResult((long)1);
				}
				else
				{
					long id = cars.Max(x => x.Id) + 1;
					cars.Add(new Car(id, newCar.Brand, newCar.YearOfProduction));
					return Task.FromResult(id);
				}
			}
		}
	}
}
