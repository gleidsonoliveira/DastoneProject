using Dastone.Data.Mappings;
using Dastone.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Dastone.Data.Context
{
    public class DastoneDbContext : DbContext
    {
        public DastoneDbContext(DbContextOptions<DastoneDbContext> opcoes) : base(opcoes) { }

        DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Client>(new ClientMap().Configure);
        }
    }
}
