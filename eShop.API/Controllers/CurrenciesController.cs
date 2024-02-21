namespace eShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController(IMediator mediator) : ControllerBase
    {
        #region GET
        [HttpGet(nameof(GetAllCurrencies))]
        public async Task<IActionResult> GetAllCurrencies()
        {
            var currencies = await mediator
                .Send(new GetCurrencyListQuery());
            return Ok(currencies);
        }

        [HttpGet(nameof(GetCurrencyByKey))]
        public async Task<IActionResult> GetCurrencyByKey([FromQuery] string key)
        {
            var currency = await mediator
                .Send(new GetCurrencyExchangeDetailsQuery
                {
                    Key = key
                });

            if (currency is null)
                return NotFound($"Currency with key: {key} not found!");
            return Ok(currency);
        }
        #endregion

        #region POST
        [HttpPost(nameof(AddCurrencies))]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCurrencies(CreateCurrenciesExchangeDto currenciesExchangeDto)
        {
            var currencies = await mediator
                .Send(new CacheCurrenciesCommand
                {
                    CurrenciesExchangeDto = currenciesExchangeDto
                });
            return Ok(currencies);
        }
        #endregion
    }
}
