namespace SignalRChat.Configurations
{
    public interface IChatAppRedisConfig
    {
        int RedisDbNo { get; set; }
        string Prefix { get; set; }
        string RedisConfigSection { get; set; }
    }
    public class ChatAppRedisConfig : IChatAppRedisConfig
    {
        public int RedisDbNo { get; set; }
        public string Prefix { get; set; }
        public string RedisConfigSection { get; set; }
    }
}
