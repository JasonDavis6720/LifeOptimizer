using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LifeOptimizer.Core.Entities
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Name { get; set; }

        public int? DwellingId { get; set; }

        [ForeignKey(nameof(DwellingId))]
        public Dwelling? Dwelling { get; set; }

        public ICollection<StorageElement> StorageElements { get; set; } = new List<StorageElement>();
    }
}