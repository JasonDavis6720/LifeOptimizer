using LifeOptimizer.Core.Entities;

public class StorageElementDto
{
    public string Name { get; set; }
    public string Type { get; set; }

    public int? ParentId { get; set; } // Foreign key to the parent StorageElement (if any)
    public int? RoomId { get; set; } // Foreign key to the Room
}