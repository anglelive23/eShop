using eShop.Application.Exceptions;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Concurrent;
using System.Text.Json;

namespace eShop.Infrastructure.Services
{
    public class CacheService : ICacheService
    {
        #region Fields and Properties
        private readonly IDistributedCache _cache;
        private static ConcurrentDictionary<string, bool> CacheKeys = new();
        #endregion

        #region Constructors
        public CacheService(IDistributedCache cache)
        {
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }
        #endregion

        #region Interface Implementation
        public async Task<T> GetAsync<T>(string cacheKey, CancellationToken cancellationToken = default)
        {
            var cachedData = await _cache.GetStringAsync(cacheKey, cancellationToken);
            if (!string.IsNullOrEmpty(cachedData))
                return JsonSerializer.Deserialize<T>(cachedData)!;

            throw new DataFailureException("Currencies not found!");
        }
        public async Task<T> GetAsync<T>(
            string key,
            Func<Task<T>> fallbackFunction,
            DistributedCacheEntryOptions options,
            CancellationToken cancellationToken = default) where T : class
        {
            var cachedData = await _cache.GetStringAsync(key, cancellationToken);
            if (!string.IsNullOrEmpty(cachedData))
                return JsonSerializer.Deserialize<T>(cachedData)!;

            var callbackData = await fallbackFunction();
            await _cache.SetStringAsync(key, JsonSerializer.Serialize(callbackData), options, cancellationToken);
            CacheKeys.TryAdd(key, true);
            return callbackData;
        }

        public async Task RemoveByPrefixAsync(string prefix, CancellationToken cancellationToken = default)
        {
            IEnumerable<Task>? tasks = CacheKeys
                .Keys
                .Where(k => k.StartsWith(prefix))
                .Select(k => RemoveAsync(k, cancellationToken));

            await Task.WhenAll(tasks);
        }

        public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
        {
            await _cache.RemoveAsync(key, cancellationToken);
        }
        #endregion
    }
}
