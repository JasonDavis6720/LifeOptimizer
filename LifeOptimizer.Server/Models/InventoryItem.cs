using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LifeOptimizer.Server.Models
{
    public class InventoryItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } // e.g., "Milk", "Eggs"

        [MaxLength(50)]
        public string Category { get; set; } // e.g., "Dairy", "Produce"

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Quantity must be a non-negative value.")]
        public double Quantity { get; set; } // e.g., 1.5 liters, 12 eggs

        [MaxLength(20)]
        public string Unit { get; set; } // e.g., Liters, Count

        public DateTime? ExpirationDate { get; set; } // Nullable for non-perishable items

        public bool IsExpired { get; set; } // e.g., true or false

        // Foreign Key to BaseStorage
        [ForeignKey("BaseStorage")]
        public int BaseStorageId { get; set; } // Foreign key to the storage location

        // Navigation Property to BaseStorage
        public BaseStorage BaseStorage { get; set; } // Navigation property to the storage location
    }
}
