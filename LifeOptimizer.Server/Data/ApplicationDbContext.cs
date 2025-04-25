using LifeOptimizer.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeOptimizer.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Room -> Dwelling relationship
            modelBuilder.Entity<Room>()
                .HasOne(r => r.Dwelling)
                .WithMany(d => d.Rooms)
                .HasForeignKey(r => r.DwellingId)
                .OnDelete(DeleteBehavior.Restrict); // Disable cascade delete

            // Configure BaseStorage -> Room relationship
            modelBuilder.Entity<BaseStorage>()
                .HasOne(bs => bs.Location)
                .WithMany()
                .HasForeignKey(bs => bs.RoomId)
                .OnDelete(DeleteBehavior.Restrict); // Disable cascade delete

            // Configure BaseStorage -> Dwelling relationship
            modelBuilder.Entity<BaseStorage>()
                .HasOne(bs => bs.Dwelling)
                .WithMany()
                .HasForeignKey(bs => bs.DwellingId)
                .OnDelete(DeleteBehavior.Restrict); // Disable cascade delete
        }
    }
}
