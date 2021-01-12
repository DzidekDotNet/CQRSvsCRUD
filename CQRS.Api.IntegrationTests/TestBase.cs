using CQRS_vs_CRUD;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using Xunit;

namespace CQRS.Api.IntegrationTests
{
	public abstract class TestBase : IClassFixture<WebApplicationFactory<Startup>>
	{
		protected readonly HttpClient client;
		protected TestBase(WebApplicationFactory<Startup> factory, Action<IServiceCollection> servicesConfiguration)
		{
			client = factory.WithWebHostBuilder(builder =>
			{
				builder.ConfigureTestServices(servicesConfiguration);
			}).CreateClient();
		}
	}
}
