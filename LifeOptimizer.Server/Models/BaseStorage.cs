using LifeOptimizer.Server.Enums;

namespace LifeOptimizer.Server.Models
{
    public class BaseStorage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; } // e.g., Fridge, Freezer, etc.        
        public List<InventoryItem> InventoryItems { get; set; } // List of items stored in this storage
    }
}
