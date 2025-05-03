using LifeOptimizer.Core.Entities;
using LifeOptimizer.Core.Interfaces;
using LifeOptimizer.Application.Interfaces;

namespace LifeOptimizer.Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Item> CreateItemAsync(Item item)
        {
            // Add any business logic here (e.g., validation, default values)
            return await _itemRepository.AddItemAsync(item);
        }
    }
}
