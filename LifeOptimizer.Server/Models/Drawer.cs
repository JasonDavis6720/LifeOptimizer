using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LifeOptimizer.Server.Models
{
    public class Drawer
    {
        [Key]
        public int Id { get; set; } // Primary key

        [Required]
        public int StorageItemId { get; set; } // Foreign key to the StorageItem

        [ForeignKey("StorageItemId")]
        public StorageItem StorageItem { get; set; } // Navigation property to the StorageItem

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "DrawerNumber must be greater than 0.")]
        public int DrawerNumber { get; set; } // Drawer number (e.g., 1, 2, 3)

        [MaxLength(100)]
        public string Label { get; set; } // Label for the drawer (e.g., "Stationery", "Files")

        [Required]
        public bool IsLocked { get; set; } // Indicates whether the drawer is locked

    }
}
