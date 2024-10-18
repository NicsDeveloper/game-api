using GameApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.Image).IsRequired();
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.Rating).IsRequired();
                entity.Property(e => e.Subtitle).IsRequired();

                var stringListConverter = new ValueConverter<List<string>, string>(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());

                var stringListComparer = new ValueComparer<List<string>>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c.ToList());

                entity.Property(e => e.Plataforms)
                    .HasConversion(stringListConverter)
                    .Metadata.SetValueComparer(stringListComparer);
            });
        }
    }
}
