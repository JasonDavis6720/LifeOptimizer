using LifeOptimizer.Server.Interfaces;
using LifeOptimizer.Server.Models;
using System.Linq;

namespace LifeOptimizer.Server.Services
{
    public class InventoryService : IInventoryService
    {
        public void AddInventoryItem(BaseStorage storage, InventoryItem item)
        {
            if (storage.InventoryItems == null)
            {
                storage.InventoryItems = new List<InventoryItem>();
            }

            // Check if the item already exists (e.g., by name or ID)
            if (storage.InventoryItems.Any(i => i.Id == item.Id))
            {
                throw new InvalidOperationException($"An inventory item with ID {item.Id} already exists.");
            }

            storage.InventoryItems.Add(item);
        }

        public void RemoveInventoryItem(BaseStorage storage, int itemId)
        {
            var item = storage.InventoryItems?.FirstOrDefault(i => i.Id == itemId);
            if (item != null)
            {
                storage.InventoryItems.Remove(item);
            }
            else
            {
                throw new InvalidOperationException($"No inventory item with ID {itemId} found.");
            }
        }

        public void UpdateInventoryItem(BaseStorage storage, InventoryItem updatedItem)
        {
            var item = storage.InventoryItems?.FirstOrDefault(i => i.Id == updatedItem.Id);
            if (item != null)
            {
                item.Name = updatedItem.Name;
                item.Category = updatedItem.Category;
                item.Quantity = updatedItem.Quantity;
                item.Unit = updatedItem.Unit;
                item.ExpirationDate = updatedItem.ExpirationDate;
                item.StorageLocation = updatedItem.StorageLocation;
                item.IsExpired = updatedItem.IsExpired;
            }
            else
            {
                throw new InvalidOperationException($"No inventory item with ID {updatedItem.Id} found.");
            }
        }
    }
}
