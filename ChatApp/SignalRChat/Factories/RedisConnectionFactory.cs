using StackExchange.Redis;

namespace SignalRChat.Factories
{
    public class RedisConnectionFactory(IConfiguration configuration)
    {
        #region Initialization

        private Lazy<ConnectionMultiplexer> _currentRedis;
        private readonly IConfiguration _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

        #endregion

        #region Methods

        public IDatabase GetCurrentDB(int databaseId, string configurationSectionName)
        {
            _currentRedis = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(GetRedisConnectionOptions(_configuration, configurationSectionName)));
            return _currentRedis.Value.GetDatabase(databaseId);
        }

        private static ConfigurationOptions GetRedisConnectionOptions(IConfiguration configuration, string sectionName)
        {

            var redisConfig = configuration.GetSection("RedisConnection").GetSection(sectionName);
            var host = redisConfig.GetSection("Host").Value;

            ConfigurationOptions options = ConfigurationOptions.Parse($"{host},allowAdmin=true");
            options.ClientName = "ChatApp";
            options.ConnectRetry = 3;
            options.ConnectTimeout = 100000;
            options.KeepAlive = 180;
            options.ResolveDns = false;
            options.SyncTimeout = 100000;
            options.AbortOnConnectFail = false;

            return options;
        }

        #endregion
    }
}
