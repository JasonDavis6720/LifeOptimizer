using LifeOptimizer.Server.Models;

namespace LifeOptimizer.Server.Interfaces
{
    public interface IInventoryService
    {
        void AddInventoryItem(BaseStorage storage, InventoryItem item);
        void RemoveInventoryItem(BaseStorage storage, int itemId);
        void UpdateInventoryItem(BaseStorage storage, InventoryItem updatedItem);
    }
}
