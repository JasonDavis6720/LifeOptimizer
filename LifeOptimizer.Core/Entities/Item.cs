using System.ComponentModel.DataAnnotations;

namespace LifeOptimizer.Core.Entities
{
    public class Item
    {

        [Key]
        public int ItemId { get; set; }
        [Required]
        public string UserId { get; set; }
        public string Name { get; set; }
        public string? Category { get; set; } // e.g., "Dairy", "Produce"
        public double? Quantity { get; set; } // e.g., 1.5 liters, 12 eggs
        public string? Unit { get; set; } // e.g., Liters, Count
        public DateTime? ExpirationDate { get; set; } // Nullable for non-perishable items
        public bool? IsExpired { get; set; } // Nullable to indicate if the expiration status is unknown
        
        public int? StorageElementId { get; set; } // Foreign key to the StorageElement
        public StorageElement? StorageElement { get; set; } // Navigation property to the StorageElement

    }

}