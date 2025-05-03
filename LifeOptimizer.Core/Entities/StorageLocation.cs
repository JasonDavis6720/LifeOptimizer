using System.ComponentModel.DataAnnotations;

namespace LifeOptimizer.Core.Entities
{
    public class StorageLocation
    {
        [Key]
        public int StorageLocationId { get; set; }
        public string Type { get; set; } // e.g., "Drawer", "Shelf", "StorageElement"
        public int ReferenceId { get; set; } // ID of the specific Drawer, Shelf, or StorageElement
    }

}
