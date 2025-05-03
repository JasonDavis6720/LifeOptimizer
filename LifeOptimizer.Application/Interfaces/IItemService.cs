using LifeOptimizer.Core.Entities;

namespace LifeOptimizer.Application.Interfaces
{
    public interface IItemService
    {
        Task<Item> CreateItemAsync(Item item);
    }
}
