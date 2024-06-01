using AutoMapper;
using SignalRChat.Dtos;
using SignalRChat.Entities;
using SignalRChat.Services.Interfaces;
using SignalRChat.Repositories.Interfaces;

namespace SignalRChat.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository, IMapper mapper)
        {
            _mapper = mapper;
            _messageRepository = messageRepository;
        }

        public async Task InsertMessage(MessageDto message)
        {
            var messageEntity = _mapper.Map<Message>(message);

            messageEntity.Date = DateTime.UtcNow;   

            await _messageRepository.InsertAsync(messageEntity);
        }
    }
}
