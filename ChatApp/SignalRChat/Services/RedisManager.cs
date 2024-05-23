using SignalRChat.Factories;
using SignalRChat.Services.Interfaces;
using StackExchange.Redis;

namespace SignalRChat.Services
{
    public class RedisManager(RedisConnectionFactory redisConnectionFactory) : IRedisManager
    {
        #region Initialization

        private readonly RedisConnectionFactory _redisConnectionFactory = redisConnectionFactory ?? throw new ArgumentNullException(nameof(redisConnectionFactory));

        #endregion

        #region Methods
        
        public IDatabase GetDB(int databaseId, string configSectionName)
        {
            return _redisConnectionFactory.GetCurrentDB(databaseId, configSectionName);
        }

        #endregion
    }

}
