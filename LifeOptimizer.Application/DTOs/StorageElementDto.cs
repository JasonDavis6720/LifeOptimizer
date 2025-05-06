namespace LifeOptimizer.Application.DTOs
{
    public class StorageElementDto
    {
        public int StorageElementId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public int? ParentId { get; set; }
        public List<ItemDto> Items { get; set; }

        public int? RoomId { get; set; }
        public string RoomName { get; set; }
    }
}