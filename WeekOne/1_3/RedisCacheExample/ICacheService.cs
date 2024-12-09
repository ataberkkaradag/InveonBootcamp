namespace RedisCacheExample
{
    public interface ICacheService
    {
        Task SetAsync<T>(string key, T value, TimeSpan expirationTime);


        Task<T> GetAsync<T>(string key);
    }
}
