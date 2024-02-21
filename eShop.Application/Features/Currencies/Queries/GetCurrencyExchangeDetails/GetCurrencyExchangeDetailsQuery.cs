using eShop.Application.Models.Dtos;

namespace eShop.Application.Features.Currencies.Queries.GetCurrencyExchangeDetails
{
    public class GetCurrencyExchangeDetailsQuery : IRequest<CurrencyDto?>
    {
        public string Key { get; set; }
    }
}
