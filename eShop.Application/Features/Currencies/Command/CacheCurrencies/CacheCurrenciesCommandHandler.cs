using eShop.Application.Models;
using eShop.Application.Models.Dtos;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;

namespace eShop.Application.Features.Currencies.Command.CacheCurrencies
{
    public class CacheCurrenciesCommandHandler(ICacheService cache, IConfiguration configuration) : IRequestHandler<CacheCurrenciesCommand, List<CurrencyDto>>
    {
        public async Task<List<CurrencyDto>> Handle(CacheCurrenciesCommand request, CancellationToken cancellationToken)
        {
            var validator = new CacheCurrenciesCommandValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var defaultExpireDateConfig = configuration
                .GetSection(Constants.DefaultExpireConfig).Value;
            double.TryParse(defaultExpireDateConfig, out var expireDate);

            var currencies = await cache
                .GetAsync(Constants.CurrenciesKey,
                 () =>
                {
                    return Task.FromResult(request.CurrenciesExchangeDto);
                }, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(expireDate) }
                , cancellationToken);

            return currencies.CurrencyDtos;
        }
    }
}
