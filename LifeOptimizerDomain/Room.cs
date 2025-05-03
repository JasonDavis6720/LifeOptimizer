namespace LifeOptimizer.Domain
{
    public class Room
    {
        public int RoomId { get; set; } // Primary key
        public string Name { get; set; } // Name of the room (e.g., "Kitchen", "Living Room")
        public int DwellingId { get; set; } // Foreign key to the Dwelling
        public List<StorageElement> StorageContainers { get; set; } = new List<StorageElement>();
        public List<Item> Items { get; set; } = new List<Item>();
    }
}
