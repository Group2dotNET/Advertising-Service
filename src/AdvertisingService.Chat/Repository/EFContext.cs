using AdvertisingService.Chat.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingService.Chat.Repository
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
        }

        public DbSet<Entities.Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
