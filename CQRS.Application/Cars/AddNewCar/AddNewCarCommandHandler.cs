using CQRS.Application.Common.Commands;
using System.Threading.Tasks;

namespace CQRS.Application.Cars.AddNewCar
{
    public sealed class AddNewCarCommandHandler : ICommandHandler<AddNewCarCommand, long>
    {
        private readonly IAddNewCarRepository addNewCarRepository;

        public AddNewCarCommandHandler(IAddNewCarRepository addNewCarRepository)
        {
            this.addNewCarRepository = addNewCarRepository;
        }

        public async Task<long> Handle(AddNewCarCommand command)
        {
            long id = await addNewCarRepository.Add(new Domain.Cars.NewCar(command.Brand, command.YearOfProduction));
            //Unit of work
            //Repository
            return id;
        }
    }
}
