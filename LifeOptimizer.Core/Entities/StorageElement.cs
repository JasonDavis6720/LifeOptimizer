namespace LifeOptimizer.Core.Entities
{
    public class StorageElement
    {
        public int StorageElementId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public int? ParentId { get; set; }
        public StorageElement Parent { get; set; }

        public int? RoomId { get; set; }
        public Room Room { get; set; }

        public string UserId { get; set; }

        public ICollection<StorageElement> Children { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}

