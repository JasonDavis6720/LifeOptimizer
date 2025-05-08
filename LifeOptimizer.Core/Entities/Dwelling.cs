using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace LifeOptimizer.Core.Entities
{

    public class Dwelling
    {
        [Key]
        public int DwellingId { get; set; }
        [Required]
        public string UserId { get; set; }
        public string Name { get; set; } // Name of the dwelling (e.g., "My House")
        public string StreetAddress { get; set; }
        public string ApartmentNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; } = "USA";
        public ICollection<Room> Rooms { get; set; }


    }
}