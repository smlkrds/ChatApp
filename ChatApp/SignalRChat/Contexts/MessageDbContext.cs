using Microsoft.EntityFrameworkCore;
using SignalRChat.Entities;

namespace SignalRChat.Contexts
{
    public class MessageDbContext : DbContext
    {
        public virtual DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .Property(e => e.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
