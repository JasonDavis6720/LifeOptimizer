using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LifeOptimizer.Server.Models
{
    public class InventoryItem
    {
        [Key]
        public int Id { get; set; } // Primary key

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

        public bool IsExpired { get; set; } // Indicates if the item is expired

        // Foreign Key to Drawer
        public int? DrawerId { get; set; } // Foreign key to the drawer where the item is stored

        [ForeignKey("StorageItemId")]
        public Drawer Drawer { get; set; } // Navigation property to the storage location
    }
}
