namespace LifeOptimizer.Application.Dtos
{
    public class StorageElementReturnDto
    {
        public int StorageElementId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int? ParentId { get; set; }

        public string RoomName { get; set; } // Optional: name of associated room
    }
}