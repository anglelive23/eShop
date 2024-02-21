using Microsoft.Extensions.Caching.Distributed;

namespace eShop.Application.Models
{
    public class CacheOptions
    {
        public static DistributedCacheEntryOptions DefaultExpiration => new DistributedCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1) };
    }
}
