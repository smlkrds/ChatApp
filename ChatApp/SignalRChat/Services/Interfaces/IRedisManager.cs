using StackExchange.Redis;

namespace SignalRChat.Services.Interfaces
{
    public interface IRedisManager
    {
        IDatabase GetDB(int databaseId, string configSectionName);
    }
}
