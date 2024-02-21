using eShop.Application.Models;
using eShop.Application.Models.Dtos;

namespace eShop.Application.Features.Currencies.Queries.GetCurrencyExchangeDetails
{
    public class GetCurrencyExchangeDetailsQueryHandler(ICacheService cache) : IRequestHandler<GetCurrencyExchangeDetailsQuery, CurrencyDto?>
    {
        public async Task<CurrencyDto?> Handle(GetCurrencyExchangeDetailsQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetCurrencyExchangeDetailsQueryValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var currencies = await cache.GetAsync<CreateCurrenciesExchangeDto>(Constants.CurrenciesKey, cancellationToken);
            var currency = currencies.CurrencyDtos.FirstOrDefault(c => c.Key == request.Key);
            return currency;
        }
    }
}
