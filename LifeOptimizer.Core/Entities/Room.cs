namespace LifeOptimizer.Core.Entities
{
    public class Room
    {
        public int RoomId { get; set; } // Primary key
        public string Name { get; set; } // Name of the room (e.g., "Kitchen", "Living Room")
        public int? DwellingId { get; set; } // Foreign key to the Dwelling
        public Dwelling? dwelling { get; set; } // Navigation property to the Dwelling
        public ICollection<StorageElement> StorageElements { get; set; } // Collection of storage elements in the room

    }
}
