namespace LifeOptimizer.Application.DTOs
{
    // DTO used for creating a StorageElement
    public class CreateStorageElementDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int? ParentId { get; set; }
        public int? RoomId { get; set; }
    }

    // DTO used for returning StorageElement data from the API
    public class StorageElementReturnDto
    {
        public int StorageElementId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int? ParentId { get; set; }

        public string RoomName { get; set; } // Optional: name of associated room
    }
}