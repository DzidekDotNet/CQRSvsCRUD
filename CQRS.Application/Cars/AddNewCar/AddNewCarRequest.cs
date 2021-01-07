namespace CQRS.Application.Cars.AddNewCar
{
    public sealed record AddNewCarRequest(string Name, int YearOfProduction);
    //Commented version for purist person :)
    //public sealed class AddNewCarRequest {
    //    public string Name { get; }
    //    public int YearOfProduction { get; }

    //    public AddNewCarRequest(string name, int yearOfProduction)
    //    {
    //        Name = name;
    //        YearOfProduction = yearOfProduction;
    //    }
    //}
}
