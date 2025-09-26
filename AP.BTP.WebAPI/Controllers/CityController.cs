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
        public async Task<IActionResult> GetAllCities([FromQuery] bool sortDesc = false)
        {
            var query = new GetAllCitiesQuery() { SortDescending = sortDesc };
            var cities = await mediator.Send(query);
            return Ok(cities);

        }
    }
}
