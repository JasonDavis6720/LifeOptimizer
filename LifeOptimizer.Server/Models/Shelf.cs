using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LifeOptimizer.Server.Models
{
    public class Shelf
    {
        [Key]
        public int Id { get; set; } // Primary key

        [Required]
        public int StorageItemId { get; set; } // Foreign key to the StorageItem

        [ForeignKey("StorageItemId")]
        public StorageItem StorageItem { get; set; } // Navigation property to the StorageItem

        [Required]
        [MaxLength(50)]
        public string Label { get; set; } // Label for the shelf (e.g., "Top Shelf")
    }
}
