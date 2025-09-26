using AP.BTP.Application.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AP.BTP.WebAPI.Controllers
{
    [Route("api/v1")]
    public class CityController : ControllerBase
    {
        private readonly IMediator mediator;
        
        public CityController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [Route("allCities")]
        public async Task<IActionResult> GetAllCities()
        {
            return Ok(await mediator.Send(new GetAllCitiesQuery()));

        }
    }
}
