using LifeOptimizer.Core.Entities;
using LifeOptimizer.Infrastructure.Data;
using LifeOptimizer.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LifeOptimizer.Infrastructure.Repositories
{
    public class StorageElementRepository : IStorageElementRepository
    {
        private readonly AppDbContext _dbContext;

        public StorageElementRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<StorageElement> AddStorageElementAsync(StorageElement item)
        {
            _dbContext.StorageElements.Add(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }

        public async Task<List<StorageElement>> GetStorageElementsByUserIdAsync (string userId)
        {
            return await _dbContext.StorageElements
                .Where(i => i.UserId == userId)
                .Include(i => i.Items) // Eagerly load the StorageElement
                .ToListAsync();
        }

    }
}