using AP.BTP.Application.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace AP.BTP.WebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {

        private readonly IMediator mediator;
        public CityController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCity([FromBody] CityCreateDTO city)
        {
            return Created("", await mediator.Send(new AddCommand() { City = city }));

        }
    }
}
