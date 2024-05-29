using SignalRChat.Dtos;
using SignalRChat.Entities;
using SignalRChat.Services.Interfaces;
using SignalRChat.Repositories.Interfaces;

namespace SignalRChat.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task InsertMessage(MessageDto message)
        {
            await _messageRepository.InsertAsync(new Message
            {
                SenderUserName = message.SenderUserName,
                Content = message.MessageContent,
                Date = DateTime.UtcNow
            });
        }
    }
}
