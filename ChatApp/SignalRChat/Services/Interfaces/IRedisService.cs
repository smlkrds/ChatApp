using StackExchange.Redis;

namespace SignalRChat.Services.Interfaces
{
    public interface IRedisService
    {
        Task Add(string key, string configSectionName, object data, int databaseId);
    }
}
