using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LifeOptimizer.Server.Models
{
    public class Dwelling
    {
        [Key]
        public int Id { get; set; } // Primary key

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } // Name of the dwelling (e.g., "My House")

        public Address Address { get; set; } // Navigation property to the Address

        [Required]
        public string UserId { get; set; } // Foreign key to the User

        [ForeignKey("UserId")]
        public User User { get; set; } // Navigation property to the User

        public ICollection<Room> Rooms { get; set; } = new List<Room>(); // List of rooms in the dwelling
    }
}
