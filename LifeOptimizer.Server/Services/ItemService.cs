using LifeOptimizer.Core.Entities;
using LifeOptimizer.Core.Interfaces;
using LifeOptimizer.Application.Interfaces;
using LifeOptimizer.Application.DTOs;
using LifeOptimizer.Infrastructure.Data;



namespace LifeOptimizer.Server.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly AppDbContext _context;

        public ItemService(AppDbContext context, IItemRepository itemRepository)
        {
            _context = context;
            _itemRepository = itemRepository;
            
        }

        public async Task<Item> CreateItemAsync(CreateItemDto itemDto)
        {
            // Convert DTO to domain entity
            var item = new Item
            {
                Name = itemDto.Name,
                Category = itemDto.Category,
                StorageElementId = itemDto.StorageElementId,

            };

            // Save the StorageElement
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            // Eagerly load the StorageElement navigation property
            _context.Entry(item).Reference(se => se.StorageElement).Load();

            return item;// Add any business logic here (e.g., validation, default values)
            //return await _itemRepository.AddItemAsync(item);
        }

        public async Task<List<Item>> GetAllItemsAsync()
        {
            return await _itemRepository.GetAllItemsAsync();
        }
    }
}