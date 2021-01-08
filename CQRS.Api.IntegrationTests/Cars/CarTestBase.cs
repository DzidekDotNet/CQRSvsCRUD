using CQRS.Api.Cars;
using CQRS.Application.Cars.AddNewCar;
using CQRS_vs_CRUD;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CQRS.Api.IntegrationTests.Cars
{
    public abstract class CarTestBase : TestBase
    {
        private const string ApiUrl = "api/CQRS/Cars";
        protected CarTestBase(WebApplicationFactory<Startup> factory) : base(factory, services => { })
        {
        }

        protected async Task AddCar(string brandName, int yearOfProduction)
        {
            AddNewCarRequest addNewCarRequest = new AddNewCarRequest(brandName, yearOfProduction);
            string json = JsonSerializer.Serialize(addNewCarRequest);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponseMessage = await client.PostAsync(ApiUrl, content);
            httpResponseMessage.EnsureSuccessStatusCode();
        }

        protected async Task<IEnumerable<CarRowDTO>> GetCars()
        {
            var httpResponseMessage = await client.GetAsync(ApiUrl);
            httpResponseMessage.EnsureSuccessStatusCode();
            var textResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<CarRowDTO>>(textResponse);
        }

        protected async Task<CarDTO> GetCar(long carId)
        {
            var httpResponseMessage = await client.GetAsync($"{ApiUrl}/{carId}");
            httpResponseMessage.EnsureSuccessStatusCode();
            var textResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<CarDTO>(textResponse);
        }
    }
}
