namespace CatchDotNet.TestConsole.cache
{
    public class CacheManager
    {
        RedisConnection Connection { get; set; }


        public CacheManager()
        {
            Connection = new RedisConnection();
            
        }


        public async Task<T> GetAsync<T>(string key)where T : class
        {
            var redis = await Connection.Configuration();
            var db = redis.GetDatabase();

            return await db.StringGetAsync(key) as T;

        }

        public async Task SetValue(string key, object value)
        {
            var redis = await Connection.Configuration();
            var db = redis.GetDatabase();
            db.StringSet(key, value.ToString());
        }
    }
}
