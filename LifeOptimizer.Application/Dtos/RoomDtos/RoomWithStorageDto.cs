namespace LifeOptimizer.Application.Dtos
{
    public class RoomWithStorageDto
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public List<StorageElementDto> StorageElements { get; set; }
    }
}