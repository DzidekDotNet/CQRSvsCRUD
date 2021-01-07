using CQRS.Application.Common.Commands;

namespace CQRS.Application.Cars.AddNewCar
{
    public sealed record AddNewClassCommand(string Name, int YearOfProduction) : ICommand<long>;
    //Commented version for purist person :)
    //public sealed class AddNewClassCommand : ICommand<long>
    //{
    //    public string Name { get; }
    //    public int YearOfProduction { get; }

    //    public AddNewClassCommand(string name, int yearOfProduction)
    //    {
    //        Name = name;
    //        YearOfProduction = yearOfProduction;
    //    }
    //}
}