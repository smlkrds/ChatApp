using Newtonsoft.Json;
using SignalRChat.Services.Interfaces;

namespace SignalRChat.Services
{
    public class RedisService(IRedisManager redisManager) : IRedisService
    {
        #region Initialization

        private readonly IRedisManager _redisManager = redisManager ?? throw new ArgumentNullException(nameof(redisManager));

        #endregion

        #region Methods

        public async Task Add(string key, string configSectionName, object data, int databaseId)
        {
            var _redisDb = _redisManager.GetDB(databaseId, configSectionName);
            await _redisDb.StringSetAsync(key, JsonConvert.SerializeObject(data));
        }

        #endregion
    }

}
