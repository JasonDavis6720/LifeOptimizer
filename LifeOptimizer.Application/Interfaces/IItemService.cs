using LifeOptimizer.Core.Entities;
using LifeOptimizer.Application.DTOs;

namespace LifeOptimizer.Application.Interfaces
{
    public interface IItemService
    {
        Task<Item> CreateItemAsync(CreateItemDto item);
        Task<List<ItemReturnDto>> GetAllItemsAsync();
        Task<ItemReturnDto> GetItemByIdAsync(int id);
    }
}
