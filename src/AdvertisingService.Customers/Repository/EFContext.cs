using AdvertisingService.Customers.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingService.Customers.Repository
{
    public class EFContext : IdentityDbContext<Customer>
    {
        public EFContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        //public DbSet<Customer> Customers { get; set; }
    }
}
