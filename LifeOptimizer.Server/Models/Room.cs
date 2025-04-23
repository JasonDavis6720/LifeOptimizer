using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LifeOptimizer.Server.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; } // Primary key

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } // Name of the room (e.g., "Kitchen", "Living Room")

        [ForeignKey("DwellingId")]
        public int DwellingId { get; set; } // Foreign key to the Dwelling

        public Dwelling Dwelling { get; set; } // Navigation property to the Dwelling
    }
}
