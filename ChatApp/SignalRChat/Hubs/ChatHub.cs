using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using SignalRChat.Configurations;
using SignalRChat.Dtos;
using SignalRChat.Services.Interfaces;

namespace SignalRChat.Hubs
{
    public class ChatHub(IMessageService messageService, IRedisService resdisService, IOptions<ChatAppRedisConfig> chatAppRedisConfig) : Hub
    {
        #region Initialization

        private readonly IRedisService _resdisService = resdisService;
        private readonly IMessageService _messageService = messageService;
        private readonly IChatAppRedisConfig _chatAppRedisConfig = chatAppRedisConfig.Value;

        #endregion

        #region Methods

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);

            var data = new MessageDto()
            {
                MessageContent = message,
                SenderUserName = user
            };

            var key = $"MSG_{user}";

            await _resdisService.Add(key, _chatAppRedisConfig.RedisConfigSection, data, 0);
            await _messageService.InsertMessage(data);
        }

        #endregion
    }
}
