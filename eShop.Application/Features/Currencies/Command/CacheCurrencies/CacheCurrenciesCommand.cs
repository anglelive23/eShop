using eShop.Application.Models.Dtos;

namespace eShop.Application.Features.Currencies.Command.CacheCurrencies
{
    public class CacheCurrenciesCommand : IRequest<List<CurrencyDto>>
    {
        public CreateCurrenciesExchangeDto CurrenciesExchangeDto { get; set; }
    }
}
