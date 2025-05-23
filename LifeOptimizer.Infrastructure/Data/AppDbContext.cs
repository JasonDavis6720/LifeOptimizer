﻿using LifeOptimizer.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LifeOptimizer.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Dwelling> Dwellings { get; set; }
        public DbSet<StorageElement> StorageElements { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
                optionsBuilder
                    .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = OptimizerDatabase")
                    .LogTo(Console.WriteLine, LogLevel.None);

        }
    }
}
