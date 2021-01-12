using CQRS.Api.Cars;
using CQRS.Application.Cars.AddNewCar;
using CQRS.Application.Common.Commands;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using Xunit;
using Xunit.Categories;

namespace CQRS.Api.UnitTests.Cars
{
	[UnitTest]
	public class CarsControllerTests
	{
		protected readonly Mock<ICommandDispatcher> commandDispatcherMock = new Mock<ICommandDispatcher>();
		protected readonly CarsController testee;
		public CarsControllerTests()
		{
			commandDispatcherMock
				.Setup(x => x.Send<long>(It.IsAny<ICommand<long>>()))
				.ReturnsAsync(123);

			testee = new CarsController(commandDispatcherMock.Object);
		}
	}

	public class AddNewTests : CarsControllerTests
	{
		private readonly AddNewCarRequest requestOK;
		public AddNewTests()
		{
			requestOK = new AddNewCarRequest("BMW", 2020);
		}

		[Fact]
		public async void AddNew_WhenEverythinkIsOk_ShouldReturn201Created()
		{
			var result = await testee.AddNew(requestOK);

			(result as ObjectResult)!.StatusCode.Should().Be((int)HttpStatusCode.Created);
		}

		[Fact]
		public async void AddNew_WhenEverythinkIsOk_ShouldReturnNewCarId()
		{
			var result = await testee.AddNew(requestOK);

			var value = ((ObjectResult)result).Value;
			value.Should().BeOfType<long>();
			value.Should().Be(123);
		}

		[Theory]
		[InlineData("", 2020)]
		[InlineData("BMW", 3000)]
		public async void AddNew_WhenIncorrectRequest_ShouldReturn422UnprocessableEntity(string brandName, int yearOfProduction)
		{
			AddNewCarRequest requestIncorrect = new AddNewCarRequest(brandName, yearOfProduction);

			var result = await testee.AddNew(requestIncorrect);

			(result as ObjectResult)!.StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
		}
	}
}
