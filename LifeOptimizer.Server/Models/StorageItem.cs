using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LifeOptimizer.Server.Models
{
    public class StorageItem
    {
        [Key]
        public int Id { get; set; } // Primary key

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } // Name of the storage item (e.g., "Kitchen Cabinet")

        [Required]
        [MaxLength(50)]
        public string Type { get; set; } // Type of storage (e.g., "Cabinet", "Refrigerator")

        [Required]
        public int RoomId { get; set; } // Foreign key to the Room

        [ForeignKey("RoomId")]
        public Room Room { get; set; } // Navigation property to the Room

        public ICollection<Drawer> Drawers { get; set; } = new List<Drawer>(); // List of drawers in the storage item

        public ICollection<Shelf> Shelves { get; set; } = new List<Shelf>(); // List of shelves in the storage item

        public ICollection<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>(); // List of items stored directly in the storage item
        public FreezerDetails FreezerDetails { get; set; } // Navigation property to FreezerDetails

    }
}

