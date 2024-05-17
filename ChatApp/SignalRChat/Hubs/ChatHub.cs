using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using SignalRChat.Configurations;
using SignalRChat.Dtos;
using SignalRChat.Services.Interfaces;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IRedisService _resdisService;
        private readonly IChatAppRedisConfig _chatAppRedisConfig;
        public ChatHub(IRedisService resdisService, IOptions<ChatAppRedisConfig> chatAppRedisConfig)
        {
            _resdisService = resdisService;
            _chatAppRedisConfig = chatAppRedisConfig.Value;
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);

            var data = new MessageDto()
            {
                MessageContent = message,
                Sender = user
            };

            var key = $"MSG_{user}";

            await _resdisService.Add(key, _chatAppRedisConfig.RedisConfigSection, data, 0);
        }
    }
}
