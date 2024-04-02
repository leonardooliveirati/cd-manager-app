using Microsoft.EntityFrameworkCore;
using CDManager.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CDManager.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<CDMusic> CDs { get; set; }
        public DbSet<Music> Musics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CDMusic>()
                .HasMany(c => c.Musics)
                .WithOne(m => m.CD)
                .HasForeignKey(m => m.CDId);
        }
    }
}
