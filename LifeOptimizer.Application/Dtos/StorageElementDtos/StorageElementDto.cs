namespace LifeOptimizer.Application.Dtos
{
    public class StorageElementDto
    {
        public int StorageElementId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public int? ParentId { get; set; }
        public string? RoomName { get; set; }
        public RoomDto Room { get; set; }
        public List<ItemDto> Items { get; set; }
        public List<StorageElementDto> Children { get; set; }
    }
}