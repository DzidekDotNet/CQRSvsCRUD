using CQRS.Api.Cars;
using CQRS_vs_CRUD;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Categories;

namespace CQRS.Api.IntegrationTests.Cars
{
    [IntegrationTest]
    public class CarsControllerTests : CarTestBase
    {
        public CarsControllerTests(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async void AddNewCar_ShouldAddNewCar()
        {
            IEnumerable<CarRowDTO> carsOnBegining = await GetCars();
            carsOnBegining.Count().Should().Be(0);

            await AddCar("BMW", 2000);

            IEnumerable<CarRowDTO> carsAfterNewCarAddedBmw = await GetCars();
            carsAfterNewCarAddedBmw.Count().Should().Be(1);
            carsAfterNewCarAddedBmw.ElementAt(0).Brand.Should().Be("BMW");
            carsAfterNewCarAddedBmw.ElementAt(0).YearOfProduction.Should().Be(2000);

            CarDTO car = await GetCar(carsAfterNewCarAddedBmw.ElementAt(0).Id);
            car.Brand.Should().Be("BMW");
            car.YearOfProduction.Should().Be(2000);

            await AddCar("Audi", 2009);

            IEnumerable<CarRowDTO> carsAfterNewCarAddedAudi = await GetCars();
            carsAfterNewCarAddedAudi.Count().Should().Be(2);
        }
    }
}
