using Microsoft.EntityFrameworkCore;
using SignalRChat.Entities;

namespace SignalRChat.Contexts
{
    public class ChatAppDbContext : DbContext
    {
        public ChatAppDbContext(DbContextOptions<ChatAppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .Property(e => e.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
