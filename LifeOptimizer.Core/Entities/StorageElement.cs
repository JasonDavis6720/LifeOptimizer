namespace LifeOptimizer.Core.Entities
{
    public class StorageElement
    {
        public int StorageElementId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int? RoomId { get; set; } // Foreign key to the Room
        public List<Item> Items { get; set; } = new List<Item>();
        public List<Drawer> Drawers { get; set; } = new List<Drawer>();
        public List<Shelf> Shelves { get; set; } = new List<Shelf>();
    }
}

