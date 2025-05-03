using LifeOptimizer.Server.Models;
using LifeOptimizer.Server.Dtos;

public interface IInventoryItemService
{
    Task<IEnumerable<InventoryItem>> GetAllInventoryItemsAsync();
    Task<InventoryItem> GetInventoryItemByIdAsync(int id);
    Task<InventoryItem> CreateInventoryItemAsync(InventoryItem inventoryItem);
    Task<InventoryItem> UpdateInventoryItemAsync(int id, UpdateInventoryItemDto updatedItem);
    Task<bool> DeleteInventoryItemAsync(int id);
    
}

