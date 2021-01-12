using CQRS.Application.Cars.AddNewCar;
using CQRS.Application.Common.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CQRS.Api.Cars
{
	/// <summary>
	/// CQRS Cars API
	/// </summary>
	[Route("api/CQRS/Cars")]
	[ApiController]
	public sealed class CarsController : ControllerBase
	{
		private readonly ICommandDispatcher commandDispatcher;

		public CarsController(ICommandDispatcher commandDispatcher)
		{
			this.commandDispatcher = commandDispatcher;
		}

		/// <summary>
		/// Add new car
		/// </summary>
		/// <param name="newCar">New car object</param>
		/// <returns>Returns:
		///  - the URL to the API where you can download data about the new car
		///  - id of new car
		/// </returns>
		/// <response code="201">Returned if the car was created</response>
		/// <response code="422">Returned when the validation failed</response>
		[HttpPost]
		[ProducesResponseType(typeof(long), (int)HttpStatusCode.Created)]
		public async Task<IActionResult> AddNew([FromBody] AddNewCarRequest newCar)
		{
			long newCarId = await commandDispatcher.Send(new AddNewCarCommand(newCar.Brand, newCar.YearOfProduction));

			return CreatedAtAction(nameof(Get), new { carId = newCarId }, newCarId);
		}

		/// <summary>
		/// Get infromation about car by id
		/// </summary>
		/// <param name="carId">car id</param>
		/// <returns>Returns information about car</returns>
		/// <response code="200">Returns if car information was collected</response>
		/// <response code="404">Returns when car was not found</response>
		[HttpGet("{carId}")]
		public IActionResult Get(long carId)
		{
			CarDTO car = new CarDTO(carId, "BMW", 1999);
			return Ok(car);
		}

		/// <summary>
		/// Get list of cars
		/// </summary>
		/// <returns>Returns list of cars</returns>
		/// <response code="200">Returns if cars list was collected</response>
		[HttpGet()]
		public IActionResult GetAll()
		{
			IEnumerable<CarRowDTO> cars = new List<CarRowDTO>() { new CarRowDTO(1, "BMW", 1999), new CarRowDTO(2, "Audi", 2005) };
			return Ok(cars);
		}
	}
}
