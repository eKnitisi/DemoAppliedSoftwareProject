using AP.BTP.Application.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AP.BTP.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly IMediator mediator;
        
        public CityController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("allCities")]
        public async Task<IActionResult> GetAllCities()
        {
            return Ok(await mediator.Send(new GetAllCitiesQuery()));

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            var city = await mediator.Send(new GetCityByIdQuery(id));
            if (city == null)
                return NotFound();
            return Ok(city);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCity(int id, [FromBody] UpdateCityCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            var result = await mediator.Send(command);
            if (!result)
                return NotFound();

            return NoContent();
        }


    }
}
