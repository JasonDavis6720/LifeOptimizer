using LifeOptimizer.Server.Models;

public interface IInventoryItemService
{
    Task<IEnumerable<InventoryItem>> GetAllInventoryItemsAsync();
    Task<InventoryItem> GetInventoryItemByIdAsync(int id);
    Task<InventoryItem> CreateInventoryItemAsync(InventoryItem inventoryItem);
    Task<InventoryItem> UpdateInventoryItemAsync(int id, InventoryItem updatedItem);
    Task<bool> DeleteInventoryItemAsync(int id);
    
}

