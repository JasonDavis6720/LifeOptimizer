using LifeOptimizer.Core.Entities;
using LifeOptimizer.Infrastructure.Data;
using LifeOptimizer.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LifeOptimizer.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _dbContext;

        public ItemRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Item> AddItemAsync(Item item)
        {
            _dbContext.Items.Add(item);
            await _dbContext.SaveChangesAsync();
            await _dbContext.Entry(item)
                .Reference(i => i.StorageElement)
                .LoadAsync();
            return item;
        }

        public async Task<List<Item>> GetAllItemsAsync(string userId)
        {
            return await _dbContext.Items
                .Where(i => i.UserId == userId)
                .Include(i => i.StorageElement) // Eagerly load the StorageElement
                .ToListAsync();
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            return await _dbContext.Items
                .Include(i => i.StorageElement) // Eagerly load the StorageElement
                .FirstOrDefaultAsync(i => i.ItemId == id);
        }

        public async Task<List<Item>> GetItemsByUserIdAsync(string userId)
        {
            return await _dbContext.Items
                .Where(i => i.UserId == userId)
                .Include(i => i.StorageElement) // Eagerly load the StorageElement
                .ToListAsync();
        }
    }

}

