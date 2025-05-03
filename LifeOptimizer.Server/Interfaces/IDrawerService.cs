using LifeOptimizer.Server.Models;
using LifeOptimizer.Server.Dtos;

public interface IDrawerService
{
    Task<IEnumerable<Drawer>> GetAllDrawersAsync();
    Task<Drawer> GetDrawerByIdAsync(int id);
    Task<Drawer> CreateDrawerAsync(Drawer drawer);
    //Task<Drawer> UpdateDrawerAsync(int id, UpdateInventoryItemDto updatedItem);
    Task<ServiceResponse<InventoryItem>> AddItemToDrawerAsync(int drawerId, int itemId);
    Task<bool> DeleteDrawerAsync(int id);
    
}

