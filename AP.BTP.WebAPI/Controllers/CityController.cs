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

        [HttpPost]
        [Route("addCities")]
        public async Task<IActionResult> CreateCity([FromBody] CityCreateDTO city)
        {
            return Created("", await mediator.Send(new AddCommand() { City = city }));
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCity(int id)
        {
            var removedCity = await mediator.Send(new RemoveCommand() { Id = id });

            if (removedCity == null)
                return NotFound(new { Message = $"City with ID {id} not found." });

            return Ok(removedCity);
        }
        
        [HttpGet("allCities")]
        public async Task<IActionResult> GetAllCities()
        {
            return Ok(await mediator.Send(new GetAllCitiesQuery()));

        }
    }
}
