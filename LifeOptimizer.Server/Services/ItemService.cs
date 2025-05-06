using LifeOptimizer.Core.Entities;
using LifeOptimizer.Core.Interfaces;
using LifeOptimizer.Application.Interfaces;
using LifeOptimizer.Application.DTOs;
using LifeOptimizer.Infrastructure.Data;
using AutoMapper;



namespace LifeOptimizer.Server.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ItemService(AppDbContext context, IItemRepository itemRepository, IMapper mapper)
        {
            _context = context;
            _itemRepository = itemRepository;
            _mapper = mapper;

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

        public async Task<List<ItemReturnDto>> GetAllItemsAsync()
        {
            var items = await _itemRepository.GetAllItemsAsync();
            return _mapper.Map<List<ItemReturnDto>>(items);
        }

        public async Task<ItemReturnDto> GetItemByIdAsync(int id)
        {
            var item = await _itemRepository.GetItemByIdAsync(id);
            if (item == null)
            {
                return null;
            }
            return _mapper.Map<ItemReturnDto>(item);
        }
    }
}