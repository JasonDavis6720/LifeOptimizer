using LifeOptimizer.Core.Entities;
using LifeOptimizer.Core.Interfaces;
using LifeOptimizer.Application.Interfaces;
using LifeOptimizer.Application.DTOs;
using LifeOptimizer.Infrastructure.Data;
using AutoMapper;
using Humanizer;
using Microsoft.EntityFrameworkCore;



namespace LifeOptimizer.Server.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserContextService _user;

        public ItemService(AppDbContext context, IItemRepository itemRepository, IMapper mapper, IUserContextService user)
        {
            _context = context;
            _itemRepository = itemRepository;
            _mapper = mapper;
            _user = user;
        }

        public async Task<ItemReturnDto> CreateItemAsync(CreateItemDto itemDto)
        {
            // Convert DTO to domain entity
            var userId = _user.GetCurrentUserId();
            var item = _mapper.Map<Item>(itemDto);
            item.UserId = userId;

            var savedItem = await _itemRepository.AddItemAsync(item);
            
            return _mapper.Map<ItemReturnDto>(savedItem);
        }

        public async Task<List<ItemReturnDto>> GetAllItemsAsync()
        {
            var userId = _user.GetCurrentUserId();
            var items = await _itemRepository.GetAllItemsAsync(userId);
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