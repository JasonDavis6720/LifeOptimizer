using LifeOptimizer.Core.Entities;

namespace LifeOptimizer.Application.DTOs
{
    public class ItemDto
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string? Category { get; set; } // e.g., "Dairy", "Produce"
        public double? Quantity { get; set; } // e.g., 1.5 liters, 12 eggs
        public string? Unit { get; set; } // e.g., Liters, Count
        public DateTime? ExpirationDate { get; set; } // Nullable for non-perishable items
        public bool? IsExpired { get; set; } // Nullable to indicate if the expiration status is unknown
        public int? StorageElementId { get; set; } // Foreign key to the StorageElement
    }
}