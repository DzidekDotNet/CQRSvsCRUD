using CQRS.Application.Common.Commands;

namespace CQRS.Application.Cars.AddNewCar
{
    public sealed record AddNewClassCommand(string Brand, int YearOfProduction) : ICommand<long>;
    //Commented version for purist person :)
    //public sealed class AddNewClassCommand : ICommand<long>
    //{
    //    public string Brand { get; }
    //    public int YearOfProduction { get; }

    //    public AddNewClassCommand(string brand, int yearOfProduction)
    //    {
    //        Brand = brand;
    //        YearOfProduction = yearOfProduction;
    //    }
    //}
}