using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LifeOptimizer.Server.Models
{
    public class BaseStorage
    {
        // Primary Key
        [Key]
        public int Id { get; set; } // Primary key

        // Name of the storage (e.g., "Kitchen Fridge")
        [Required]
        [MaxLength(100)] // Limit the length to 100 characters
        public string Name { get; set; }

        // Foreign Key to Room
        [ForeignKey("Room")]
        public int RoomId { get; set; } // Foreign key to the Room

        // Navigation Property to Room
        public Room Location { get; set; } // Navigation property to the Room

        // Foreign Key to Dwelling
        [ForeignKey("Dwelling")]
        public int DwellingId { get; set; } // Foreign key to the Dwelling

        // Navigation Property to Dwelling
        public Dwelling Dwelling { get; set; } // Navigation property to the Dwelling

        // List of items stored in this storage
        public List<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>(); // Initialize to avoid null

    }
}




