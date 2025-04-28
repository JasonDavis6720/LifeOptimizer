using LifeOptimizer.Server.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace LifeOptimizer.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets for your entities
        public DbSet<Dwelling> Dwellings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<StorageItem> StorageItems { get; set; }
        public DbSet<FreezerDetails> FreezerDetails { get; set; } // Add this line
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<Drawer> Drawers { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Address { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            
            modelBuilder.Entity<User>()
                .HasMany(u => u.Dwellings)
                .WithOne(d => d.User)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Dwelling>()
                .HasOne(d => d.User)
                .WithMany(u => u.Dwellings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Optional: Cascade delete dwellings when a user is deleted

            // Configure Room -> Dwelling relationship
            modelBuilder.Entity<Room>()
                .HasOne(r => r.Dwelling)
                .WithMany(d => d.Rooms)
                .HasForeignKey(r => r.DwellingId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete rooms when a dwelling is deleted

            // Configure Dwelling -> Address relationship
            modelBuilder.Entity<Dwelling>()
                .HasOne(d => d.Address)
                .WithMany()
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete address when a dwelling is deleted

            // Configure StorageItem -> Room relationship
            modelBuilder.Entity<StorageItem>()
                .HasOne(si => si.Room)
                .WithMany(r => r.StorageItems)
                .HasForeignKey(si => si.RoomId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Shelf -> StorageItem relationship
            modelBuilder.Entity<Shelf>()
                .HasOne(s => s.StorageItem)
                .WithMany(si => si.Shelves)
                .HasForeignKey(s => s.StorageItemId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Drawer -> StorageItem relationship
            modelBuilder.Entity<Drawer>()
                .HasOne(d => d.StorageItem)
                .WithMany(si => si.Drawers)
                .HasForeignKey(d => d.StorageItemId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete drawers when a storage item is deleted

            // Configure StorageItem -> InventoryItem relationship
            modelBuilder.Entity<StorageItem>()
                .HasMany(si => si.InventoryItems)
                .WithOne(ii => ii.StorageItem)
                .HasForeignKey(ii => ii.StorageItemId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete inventory items when a storage item is deleted

            // Configure InventoryItem -> StorageItem relationship
            modelBuilder.Entity<InventoryItem>()
                .HasOne(ii => ii.StorageItem)
                .WithMany(si => si.InventoryItems)
                .HasForeignKey(ii => ii.StorageItemId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete inventory items when a storage item is deleted

            // Configure FreezerDetails -> StorageItem relationship
            modelBuilder.Entity<FreezerDetails>()
                .HasOne(fd => fd.StorageItem)
                .WithOne(si => si.FreezerDetails)
                .HasForeignKey<FreezerDetails>(fd => fd.StorageItemId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete FreezerDetails when a StorageItem is deleted

        }


    }
}
