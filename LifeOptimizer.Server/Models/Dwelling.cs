using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LifeOptimizer.Server.Models
{
    public class Dwelling
    {
        // Primary Key
        [Key]
        public int Id { get; set; } // Primary key

        // Foreign Key
        //[ForeignKey("UserId")]
        public string UserId { get; set; } // Foreign key to the User

        // Navigation Property to User Object
        public User User { get; set; } // Navigation property to the User

        // Navigation Property to list of Room Objects
        public List<Room> Rooms { get; set; } = new List<Room>();

        // Other Properties
        //Dwelling Name, e.g. "My House"
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } // Name of the dwelling

        // Dwelling Address, e.g. "123 Main St, Springfield, IL 62704"
        [Required]
        public Address Address { get; set; } // Complex address object

    }
}

