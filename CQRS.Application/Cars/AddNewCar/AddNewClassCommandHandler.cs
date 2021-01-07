using CQRS.Application.Common.Commands;
using System;
using System.Threading.Tasks;

namespace CQRS.Application.Cars.AddNewCar
{
    public sealed class AddNewClassCommandHandler : ICommandHandler<AddNewClassCommand, long>
    {
        public Task<long> Handle(AddNewClassCommand command)
        {
            //Unit of work
            //Repository
            return Task.FromResult((long)DateTime.Now.Second);
        }
    }
}
