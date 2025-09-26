using MediatR;
using Microsoft.AspNetCore.Mvc;
using AP.BTP.Application.CQRS;

namespace AP.BTP.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly IMediator mediator;

        public CountryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("allCountries")]
        public async Task<IActionResult> GetAllCountries()
        {
            return Ok(await mediator.Send(new GetAllCountriesQuery()));
        }
    }
}
