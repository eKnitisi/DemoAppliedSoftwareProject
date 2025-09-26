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
    }
}
