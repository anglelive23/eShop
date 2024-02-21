using eShop.Application.Features.Currencies.Command.CacheCurrencies;

namespace eShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController(IMediator mediator) : ControllerBase
    {
        [HttpPost(nameof(CacheCurrencies))]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CacheCurrencies()
        {
            var command = await mediator
                .Send(new CacheCurrenciesCommand());
            if (!command)
                return Ok("Currencies already cached!");
            return Ok("Currencies has been cached!");
        }
    }
}
