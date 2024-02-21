using eShop.Application.Models;
using eShop.Application.Models.Dtos;

namespace eShop.Application.Features.Currencies.Queries.GetCurrencyList
{
    public class GetCurrencyListQueryHandler(ICacheService cache) : IRequestHandler<GetCurrencyListQuery, List<CurrencyDto>>
    {
        public async Task<List<CurrencyDto>> Handle(GetCurrencyListQuery request, CancellationToken cancellationToken)
        {
            var currencies = await cache.GetAsync<CreateCurrenciesExchangeDto>(Constants.CurrenciesKey, cancellationToken);
            return currencies.CurrencyDtos;
        }
    }
}
