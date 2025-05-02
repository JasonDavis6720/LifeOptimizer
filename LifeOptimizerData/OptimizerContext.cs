using LifeOptimizer.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LifeOptimizer.Data
{
    public class OptimizerContext: DbContext
    {
        public DbSet<Drawer> Drawers { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
                optionsBuilder
                    .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = OptimizerDatabase")
                    .LogTo(Console.WriteLine, LogLevel.Information);

        }
    }
}
