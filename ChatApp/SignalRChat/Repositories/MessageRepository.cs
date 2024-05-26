using SignalRChat.Contexts;
using SignalRChat.Entities;
using SignalRChat.Repositories.Interfaces;

namespace SignalRChat.Repositories
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        private readonly ChatAppDbContext _dbContext;

        public MessageRepository(ChatAppDbContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
