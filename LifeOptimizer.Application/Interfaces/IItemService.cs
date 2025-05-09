using LifeOptimizer.Core.Entities;
using LifeOptimizer.Application.Dtos;

namespace LifeOptimizer.Application.Interfaces
{
    public interface IItemService
    {
        Task<ItemReturnDto> CreateItemAsync(CreateItemDto item);
        Task<List<ItemReturnDto>> GetAllItemsAsync();
        Task<ItemReturnDto> GetItemByIdAsync(int id);
    }
}
