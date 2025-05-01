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

        public FreezerDetails FreezerDetails { get; set; } // Navigation property to FreezerDetails

    }
}

