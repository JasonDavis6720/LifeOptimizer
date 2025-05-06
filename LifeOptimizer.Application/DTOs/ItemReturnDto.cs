namespace LifeOptimizer.Application.DTOs
{
    public class ItemReturnDto
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string? Category { get; set; }
        public double? Quantity { get; set; }
        public string? Unit { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool? IsExpired { get; set; }
        public int? StorageElementId { get; set; }
        public string? StorageElementName { get; set; } // Name of the associated StorageElement
    }
}
