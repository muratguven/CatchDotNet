using StackExchange.Redis;

namespace CatchDotNet.TestConsole.cache
{
    public class RedisConnection
    {
        public async Task<ConnectionMultiplexer> Configuration()
        {
            var redisConfigurationOptions = new ConfigurationOptions { EndPoints = { "localhost" }, AllowAdmin=true };

            var connection = await ConnectionMultiplexer.ConnectAsync(redisConfigurationOptions);
            return connection;
        }
    }
}
