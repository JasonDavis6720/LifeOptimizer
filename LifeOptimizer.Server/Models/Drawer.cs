using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LifeOptimizer.Server.Models
{
    public class Drawer : BaseStorage
    {
        // Drawer number (e.g., 1, 2, 3)
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "DrawerNumber must be greater than 0.")]
        public int DrawerNumber { get; set; }

        // Label for the drawer (e.g., "Stationery", "Files")
        [MaxLength(100)] // Limit the length to 100 characters
        public string Label { get; set; }

        // Indicates whether the drawer is locked
        [Required]
        public bool IsLocked { get; set; }

        // List of items stored in this drawer
        public List<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>();

        // Foreign Key to Cabinet
        [ForeignKey("Cabinet")]
        public int CabinetId { get; set; } // Foreign key to the Cabinet

        // Navigation Property to Cabinet
        public Cabinet Cabinet { get; set; } // Navigation property to the Cabinet
    }
}
