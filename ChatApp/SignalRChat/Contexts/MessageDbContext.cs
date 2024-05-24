using Microsoft.EntityFrameworkCore;
using SignalRChat.Entities;

namespace SignalRChat.Contexts
{
    public class MessageDbContext : DbContext
    {
        public virtual DbSet<Message> Messages { get; set; }
    }
}
