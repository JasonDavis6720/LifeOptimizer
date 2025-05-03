using LifeOptimizer.Core.Entities;
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
        //public DbSet<User> Users { get; set; }
        //public DbSet<Dwelling> Dwellings { get; set; }
        //public DbSet<Room> Rooms { get; set; }
        //public DbSet<StorageItem> StorageItems { get; set; }
        //public DbSet<FreezerDetails> FreezerDetails { get; set; } // Add this line
        //public DbSet<Shelf> Shelves { get; set; }
        //public DbSet<Drawer> Drawers { get; set; }
        public DbSet<Item> Items { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Drawer -> InventoryItem relationship (1:Many)
            //modelBuilder.Entity<Item>()
            //    .HasOne(ii => ii.Drawer) // Navigation property in InventoryItem
            //    .WithMany() // No Navigation property in Drawer
            //    .HasForeignKey(ii => ii.DrawerId) // Foreign key in InventoryItem
            //    .OnDelete(DeleteBehavior.SetNull); // Set DrawerId to NULL when a Drawer is deleted

            //modelBuilder.Entity<Dwelling>()
            //    .HasOne(d => d.User)
            //    .WithMany()
            //    .HasForeignKey(d => d.UserId)
            //    .OnDelete(DeleteBehavior.Cascade); // Optional: Cascade delete dwellings when a user is deleted

            //// Configure Room -> Dwelling relationship
            //modelBuilder.Entity<Room>()
            //    .HasOne(r => r.Dwelling)
            //    .WithMany()
            //    .HasForeignKey(r => r.DwellingId)
            //    .OnDelete(DeleteBehavior.Cascade); // Cascade delete rooms when a dwelling is deleted

            //// Configure StorageItem -> Room relationship
            //modelBuilder.Entity<StorageItem>()
            //    .HasOne(si => si.Room)
            //    .WithMany()
            //    .HasForeignKey(si => si.RoomId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //// Configure Shelf -> StorageItem relationship
            //modelBuilder.Entity<Shelf>()
            //    .HasOne(s => s.StorageItem)
            //    .WithMany()
            //    .HasForeignKey(s => s.StorageItemId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //// Configure Drawer -> StorageItem relationship
            //modelBuilder.Entity<Drawer>()
            //    .HasOne(d => d.StorageItem)
            //    .WithMany()
            //    .HasForeignKey(d => d.StorageItemId)
            //    .OnDelete(DeleteBehavior.Cascade); // Cascade delete drawers when a storage item is deleted

            //// Configure StorageItem -> InventoryItem relationship
            //modelBuilder.Entity<StorageItem>()
            //    .WithMany()
            //    .HasForeignKey(ii => ii.StorageItemId)
            //    .OnDelete(DeleteBehavior.Cascade); // Cascade delete inventory items when a storage item is deleted

            //// Configure InventoryItem -> StorageItem relationship
            //modelBuilder.Entity<InventoryItem>()
            //    .HasOne(ii => ii.StorageItem)
            //    .WithMany()
            //    .HasForeignKey(ii => ii.StorageItemId)
            //    .OnDelete(DeleteBehavior.Cascade); // Cascade delete inventory items when a storage item is deleted

            //// Configure FreezerDetails -> StorageItem relationship
            //modelBuilder.Entity<FreezerDetails>()
            //    .HasOne(fd => fd.StorageItem)
            //    .WithOne(si => si.FreezerDetails)
            //    .HasForeignKey<FreezerDetails>(fd => fd.StorageItemId)
            //    .OnDelete(DeleteBehavior.Cascade); // Cascade delete FreezerDetails when a StorageItem is deleted

        }


    }
}