namespace CQRS.Application.Cars.AddNewCar
{
    public sealed record AddNewCarRequest(string Brand, int YearOfProduction);
    //Commented version for purist person :)
    //public sealed class AddNewCarRequest {
    //    public string Brand { get; }
    //    public int YearOfProduction { get; }

    //    public AddNewCarRequest(string brand, int yearOfProduction)
    //    {
    //        Brand = brand;
    //        YearOfProduction = yearOfProduction;
    //    }
    //}
}
