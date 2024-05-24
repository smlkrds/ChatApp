using SignalRChat.Contexts;
using SignalRChat.Entities;
using SignalRChat.Repositories.Interfaces;

namespace SignalRChat.Repositories
{
    public class MessageRepository(MessageDbContext context) : BaseRepository<Message>, IMessageRepository
    {
        private readonly MessageDbContext _dbContext = context;
    }
}
