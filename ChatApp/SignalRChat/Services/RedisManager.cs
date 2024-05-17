using SignalRChat.Factories;
using SignalRChat.Services.Interfaces;
using StackExchange.Redis;

namespace SignalRChat.Services
{
    public class RedisManager : IRedisManager
    {
        private readonly RedisConnectionFactory _redisConnectionFactory;

        public RedisManager(RedisConnectionFactory redisConnectionFactory)
        {
            _redisConnectionFactory = redisConnectionFactory ?? throw new ArgumentNullException(nameof(redisConnectionFactory));
        }

        public IDatabase GetDB(int databaseId, string configSectionName)
        {
            return _redisConnectionFactory.GetCurrentDB(databaseId, configSectionName);
        }
    }

}
