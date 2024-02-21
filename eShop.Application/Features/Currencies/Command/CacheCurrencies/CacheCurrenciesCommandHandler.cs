using eShop.Application.Models;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace eShop.Application.Features.Currencies.Command.CacheCurrencies
{
    public class CacheCurrenciesCommandHandler(IDistributedCache cache, IConfiguration configuration) : IRequestHandler<CacheCurrenciesCommand, bool>
    {
        public async Task<bool> Handle(CacheCurrenciesCommand request, CancellationToken cancellationToken)
        {
            var cachedItems = await cache.GetStringAsync(Constants.CurrenciesKey, cancellationToken);
            if (!string.IsNullOrEmpty(cachedItems))
                return false;

            var exchangeRates = configuration.GetSection("Currencies:ExchangeRates");
            var currencies = new List<object>();
            currencies.AddRange(exchangeRates.GetChildren().Select(x => new
            {
                Key = x.Key,
                Value = x.Value,
            }));

            var defaultExpireDateConfig = configuration
                .GetSection(Constants.DefaultExpireConfig).Value;
            double.TryParse(defaultExpireDateConfig, out var expireDate);

            await cache.SetStringAsync(Constants.CurrenciesKey,
            JsonSerializer.Serialize(currencies),
                 new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(expireDate) },
                cancellationToken);
            return true;
        }
    }
}
