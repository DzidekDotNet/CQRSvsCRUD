using CQRS.Domain.Cars;
using System.Threading.Tasks;

namespace CQRS.Application.Cars.AddNewCar
{
    public interface IAddNewCarRepository
    {
        Task<long> Add(NewCar newCar);
    }
}
