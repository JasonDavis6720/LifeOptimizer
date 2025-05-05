namespace LifeOptimizer.Core.Entities
{
    public class StorageElement
    {
        public int StorageElementId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public int? ParentId { get; set; } // Foreign key to the parent StorageElement (if any)
        public StorageElement parent { get; set; } // Navigation property to the parent StorageElement (if any)

        public int? RoomId { get; set; } // Foreign key to the Room
        public Room room { get; set; } // Navigation property to the Room

        public ICollection<StorageElement> Children { get; set; } // Collection of child StorageElements (if any)
        public ICollection<Item> Items { get; set; } // Collection of items stored in this StorageElement

    }
}

