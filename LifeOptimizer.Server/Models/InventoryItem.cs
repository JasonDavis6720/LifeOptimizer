using LifeOptimizer.Server.Enums;

namespace LifeOptimizer.Server.Models
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; } // e.g., "Milk", "Eggs"
        public string Category { get; set; } // e.g., "Dairy", "Produce"
        public double Quantity { get; set; } // e.g., 1.5 liters, 12 eggs
        public UnitOfMeasure Unit { get; set; } // e.g., Liters, Count
        public DateTime ExpirationDate { get; set; } // e.g., 2023-10-01
        public string StorageLocation { get; set; } // e.g., "Fridge", "Freezer"
        public bool IsExpired { get; set; } // e.g., true or false
    }
}
