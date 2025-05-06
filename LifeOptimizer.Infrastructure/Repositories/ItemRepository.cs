using LifeOptimizer.Core.Entities;
using LifeOptimizer.Infrastructure.Data;
using LifeOptimizer.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using LifeOptimizer.Application.DTOs;

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
            return item;
        }

        public async Task<List<Item>> GetAllItemsAsync()
        {
            return await _dbContext.Items
                .Include(i => i.StorageElement) // Eagerly load the StorageElement
                .ToListAsync();
        }

    }

}

