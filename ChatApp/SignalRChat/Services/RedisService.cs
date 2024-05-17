using Newtonsoft.Json;
using SignalRChat.Services.Interfaces;

namespace SignalRChat.Services
{
    public class RedisService : IRedisService
    {
        private readonly IRedisManager _redisManager;
        public RedisService(IRedisManager redisManager)
        {
            _redisManager = redisManager ?? throw new ArgumentNullException(nameof(redisManager));
        }

        #region CRUD

        public async Task Add(string key, string configSectionName, object data, int databaseId)
        {
            var _redisDb = _redisManager.GetDB(databaseId, configSectionName);
            await _redisDb.StringSetAsync(key, JsonConvert.SerializeObject(data));
        }

        #endregion
    }

}
