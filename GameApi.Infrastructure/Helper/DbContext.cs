using GameApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GameApi.Infrastructure.Helper
{
    public class AppDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=games.db; Cache=Shared", 
                    b => b.MigrationsAssembly("GameApi.Api"));
            }
        }
    }
}