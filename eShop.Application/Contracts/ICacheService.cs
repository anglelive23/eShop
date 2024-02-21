using Microsoft.Extensions.Caching.Distributed;

namespace eShop.Application.Contracts
{
    public interface ICacheService
    {
        Task<T> GetAsync<T>(string cacheKey, CancellationToken cancellationToken = default);
        Task<T> GetAsync<T>(
            string key,
            Func<Task<T>> fallbackFunction,
            DistributedCacheEntryOptions options,
            CancellationToken cancellationToken = default) where T : class;

        Task RemoveByPrefixAsync(string prefix, CancellationToken cancellationToken = default);
        Task RemoveAsync(string key, CancellationToken cancellationToken = default);
    }
}
