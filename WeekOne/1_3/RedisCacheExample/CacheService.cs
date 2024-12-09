using StackExchange.Redis;
using System.Text.Json;

namespace RedisCacheExample
{
    public class CacheService:ICacheService
    {
        private readonly IConnectionMultiplexer _redis;
        public CacheService(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }
        public async Task<T> GetAsync<T>(string key)
        {
            var db = _redis.GetDatabase();
            var value = await db.StringGetAsync(key);
            if (!value.HasValue)
            {
                return default;
            }

            return JsonSerializer.Deserialize<T>(value);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan expirationTime)
        {
            var db = _redis.GetDatabase();
            var serializedValue = JsonSerializer.Serialize(value);
            await db.StringSetAsync(key, serializedValue, expirationTime);
        }
    }
}
