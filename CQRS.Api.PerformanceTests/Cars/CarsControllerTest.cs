using CQRS.Application.Cars.AddNewCar;
using FluentAssertions;
using NBomber.Contracts;
using NBomber.CSharp;
using NBomber.Plugins.Http.CSharp;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using Xunit.Categories;

namespace CQRS.Api.PerformanceTests.Cars
{
    [IntegrationTest]
    public class CarsControllerTest
    {
        private const string ApiUrl = "api/CQRS/Cars";
        private string endpoint = $"https://localhost:5001/{ApiUrl}";

        [Fact]
        public void AddNew()
        {
            //Arrange
            AddNewCarRequest addNewCarRequest = new AddNewCarRequest("BMW", 1999);
            string json = JsonSerializer.Serialize(addNewCarRequest);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var step = HttpStep.Create("addNew", ctx =>
                Task.FromResult(Http.CreateRequest("POST", endpoint)
                    .WithBody(content)
                    ));

            var scenario = ScenarioBuilder.CreateScenario("Add", step)
                .WithoutWarmUp()
                .WithLoadSimulations(Simulation.KeepConstant(2, TimeSpan.FromSeconds(30)));

            //Act
            NodeStats nodeStats = NBomberRunner.RegisterScenarios(scenario).Run();

            //Assert
            nodeStats.OkCount.Should().Be(nodeStats.RequestCount);
            StepStats stepStats = nodeStats.ScenarioStats[0].StepStats[0];
            stepStats.RPS.Should().BeGreaterOrEqualTo(1500);
        }
    }
}
