namespace LifeOptimizer.Application.Dtos
{
    // DTO used for creating a StorageElement
    public class CreateStorageElementDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int? ParentId { get; set; }
        public int? RoomId { get; set; }
    }

}