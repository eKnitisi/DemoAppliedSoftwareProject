using AP.BTP.Application.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AP.BTP.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1")]
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
        [HttpGet]
        [Route("allCities")]
        public async Task<IActionResult> GetAllCities()
        {
            return Ok(await mediator.Send(new GetAllCitiesQuery()));

        }
    }
}
